using Antlr4.Runtime;
using eVision.Language.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eVision.Language
{
    public static class TypeLocator
    {
        public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType)
        {
            return from x in Assembly.GetExecutingAssembly().GetTypes()
                   from z in x.GetInterfaces()
                   let y = x.BaseType
                   where
                   (y != null && y.IsGenericType &&
                   openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
                   (z.IsGenericType &&
                   openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition()))
                   select x;
        }

        public static Type GetHandleType<C>(C context) where C: ParserRuleContext 
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x=>!x.IsAbstract)
                .Where(x=>x.GetInterfaces().Contains(typeof(IDefinition)));
            var t = allTypes.FirstOrDefault(x =>
            {
                var args = x.BaseType.GenericTypeArguments;
                if (args.Length > 0)
                {
                    return args[0] == context.GetType();
                }
                return false;
            });
            return t;
        }
    }
}
