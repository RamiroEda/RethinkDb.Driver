﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Net;
using RethinkDb.Driver.Utils;

namespace RethinkDb.Driver.ReGrid
{
    public partial class Bucket
    {
        private static readonly RethinkDB r = RethinkDB.r;

        internal readonly IConnection conn;
        private readonly BucketConfig config;
        private Db db;
        private string databaseName;

        private string chunkTableName;
        internal string chunkIndexName;

        private string fileTableName;
        internal string fileIndexPath;

        private object tableOpts;
        internal Table fileTable;
        internal Table chunkTable;

        public bool Mounted { get; set; }

        public Bucket(IConnection conn, string databaseName, string bucketName = "fs", BucketConfig config = null)
        {
            this.conn = conn;

            this.databaseName = databaseName;
            this.db = r.db(this.databaseName);

            config = config ?? new BucketConfig();

            this.tableOpts = config.TableOptions;

            this.fileTableName = $"{bucketName}_{config.FileTableName}";
            this.fileTable = this.db.table(fileTableName);
            this.fileIndexPath = config.FileIndexPath;

            this.chunkTableName = $"{bucketName}_{config.ChunkTable}";
            this.chunkTable = this.db.table(chunkTableName);
            this.chunkIndexName = config.ChunkIndex;
        }
        

        private void ThrowIfNotMounted()
        {
            if( !this.Mounted )
                throw new InvalidOperationException($"Please call {nameof(Mount)} before performing any operation.");
        }

        public void Mount()
        {
            MountAsync().WaitSync();
        }

        public async Task MountAsync()
        {
            if (this.Mounted)
                return;

            var filesTableResult = await EnsureTable(this.fileTableName)
                .ConfigureAwait(false);

            if( filesTableResult.TablesCreated == 1 )
            {
                //index the file paths of completed files and status
                await CreateIndex(this.fileTableName, this.fileIndexPath,
                    row => r.array(row[FileInfo.StatusJsonName], row[FileInfo.FileNameJsonName], row[FileInfo.FinishedDateJsonName]))
                    .ConfigureAwait(false);
            }

            var chunkTableResult = await EnsureTable(this.chunkTableName)
                .ConfigureAwait(false);

            if( chunkTableResult.TablesCreated == 1 )
            {
                //Index the chunks and their parent [fileid, n].
                await CreateIndex(this.chunkTableName, this.chunkIndexName,
                    row => r.array(row[Chunk.FilesIdJsonName], row[Chunk.NumJsonName]))
                    .ConfigureAwait(true);
            }

            this.Mounted = true;
        }



        protected internal async Task<JArray> CreateIndex(string tableName, string indexName, ReqlFunction1 indexFunc)
        {
            await this.db.table(tableName)
                .indexCreate(indexName, indexFunc).runAtomAsync<JObject>(conn)
                .ConfigureAwait(false);

            return await this.db.table(tableName)
                .indexWait(indexName).runAtomAsync<JArray>(conn)
                .ConfigureAwait(false);
        }

        protected internal async Task<Result> EnsureTable(string tableName)
        {
            return await this.db.tableList().contains(tableName)
                .do_(tableExists =>
                    r.branch(tableExists, new {tables_created = 0}, db.tableCreate(tableName)[this.tableOpts])
                ).runResultAsync(this.conn)
                .ConfigureAwait(false);
        }
    }
}
