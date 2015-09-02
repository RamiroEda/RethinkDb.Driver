








//AUTOGENERATED, DO NOTMODIFY.
//Do not edit this file directly.

#pragma warning disable 1591
// ReSharper disable CheckNamespace

using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Proto;
using System.Collections.Generic;

namespace RethinkDb.Driver.Ast {
    public class Random : ReqlQuery {
    
    
        public Random (object arg) : this(new Arguments(arg), null) {
        }
        public Random (Arguments args, OptArgs optargs) : this(null, args, optargs) {
        }
        public Random (ReqlAst prev, Arguments args, OptArgs optargs)
             : this(prev, TermType.RANDOM, args, optargs) {
        }

    protected Random (ReqlAst previous, TermType termType, Arguments args, OptArgs optargs) : base(previous, termType, args, optargs)
    {
    }


    

    /* Static Factories */

        public static Random FromArgs(params object[] args){
         return new Random (new Arguments(args), null);
        }


    

    


    
    }
}