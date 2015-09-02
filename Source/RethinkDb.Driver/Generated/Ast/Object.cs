








//AUTOGENERATED, DO NOTMODIFY.
//Do not edit this file directly.

#pragma warning disable 1591
// ReSharper disable CheckNamespace

using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Proto;
using System.Collections.Generic;

namespace RethinkDb.Driver.Ast {
    public class Object : ReqlQuery {
    
    
        public Object (object arg) : this(new Arguments(arg), null) {
        }
        public Object (Arguments args, OptArgs optargs) : this(null, args, optargs) {
        }
        public Object (ReqlAst prev, Arguments args, OptArgs optargs)
             : this(prev, TermType.OBJECT, args, optargs) {
        }

    protected Object (ReqlAst previous, TermType termType, Arguments args, OptArgs optargs) : base(previous, termType, args, optargs)
    {
    }


    

    /* Static Factories */

        public static Object FromArgs(params object[] args){
         return new Object (new Arguments(args), null);
        }


    

    


    
    }
}