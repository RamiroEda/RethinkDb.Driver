








//AUTOGENERATED, DO NOTMODIFY.
//Do not edit this file directly.

#pragma warning disable 1591
// ReSharper disable CheckNamespace

using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Proto;
using System.Collections.Generic;

namespace RethinkDb.Driver.Ast {
    public class OrderBy : ReqlQuery {
    
    
        public OrderBy (object arg) : this(new Arguments(arg), null) {
        }
        public OrderBy (Arguments args, OptArgs optargs) : this(null, args, optargs) {
        }
        public OrderBy (ReqlAst prev, Arguments args, OptArgs optargs)
             : this(prev, TermType.ORDER_BY, args, optargs) {
        }

    protected OrderBy (ReqlAst previous, TermType termType, Arguments args, OptArgs optargs) : base(previous, termType, args, optargs)
    {
    }


    

    /* Static Factories */

        public static OrderBy FromArgs(params object[] args){
         return new OrderBy (new Arguments(args), null);
        }


    

    


    
    }
}