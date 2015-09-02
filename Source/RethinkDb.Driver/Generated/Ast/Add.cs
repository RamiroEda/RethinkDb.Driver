








//AUTOGENERATED, DO NOTMODIFY.
//Do not edit this file directly.

#pragma warning disable 1591
// ReSharper disable CheckNamespace

using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Proto;
using System.Collections.Generic;

namespace RethinkDb.Driver.Ast {
    public class Add : ReqlQuery {
    
    
        public Add (object arg) : this(new Arguments(arg), null) {
        }
        public Add (Arguments args, OptArgs optargs) : this(null, args, optargs) {
        }
        public Add (ReqlAst prev, Arguments args, OptArgs optargs)
             : this(prev, TermType.ADD, args, optargs) {
        }

    protected Add (ReqlAst previous, TermType termType, Arguments args, OptArgs optargs) : base(previous, termType, args, optargs)
    {
    }


    

    /* Static Factories */

        public static Add FromArgs(params object[] args){
         return new Add (new Arguments(args), null);
        }


    

    


    
    }
}