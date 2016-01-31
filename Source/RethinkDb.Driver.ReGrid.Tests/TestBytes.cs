﻿using System.Linq;

namespace RethinkDb.Driver.ReGrid.Tests
{
    public static class TestBytes
    {
        public static byte[] HalfChunk;

        public static byte[] OneHalfChunk;
        public static byte[] OneHalfChunkReversed;
        public static byte[] NoChunks = new byte[0];

        static TestBytes()
        {
            OneHalfChunk = Generate((1024 * 255) + (1024 * 128));// 1.5 chunks
            OneHalfChunkReversed = OneHalfChunk.Reverse().ToArray();

            HalfChunk = Generate(1024 * 128);
        }

        public static byte[] Generate(int amount)
        {
            return Enumerable.Range(0, amount)
                .Select(i => (byte)(i % 256))
                .ToArray();
        }
    }
}