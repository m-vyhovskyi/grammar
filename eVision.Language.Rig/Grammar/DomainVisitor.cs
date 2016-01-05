using System;
using System.Collections.Generic;

using eVision.Language.Grammar;

namespace eVision.Language.Rig.Grammar
{
    public class DomainVisitor:DomainBaseVisitor<int>
    {
        public static readonly Dictionary<string,int> variables = new Dictionary<string, int>(); 

        public override int VisitAssign(DomainParser.AssignContext context)
        {
            string id = context.ID().GetText();
            var value = Visit(context.expr());
            if (variables.ContainsKey(id))
            {
                variables[id] = value;
            }
            else
            {
                variables.Add(id, value);
            }
            return value;
        }

        public override int VisitPrintExpr(DomainParser.PrintExprContext context)
        {
            var value = Visit(context.expr());
            Console.WriteLine(value);
            return 0;
        }

        public override int VisitInt(DomainParser.IntContext context)
        {
            return Int32.Parse(context.INT().GetText());
        }

        public override int VisitId(DomainParser.IdContext context)
        {
            string id = context.ID().GetText();
            if (variables.ContainsKey(id))
                return variables[id];
            return 0;
        }

        public override int VisitMuldiv(DomainParser.MuldivContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));
            if (context.op.Type == DomainParser.MUL)
                return left * right;
            return left / right;
        }

        public override int VisitAddSub(DomainParser.AddSubContext context)
        {
            int left = Visit(context.expr(0));
            int right = Visit(context.expr(1));
            if (context.op.Type == DomainParser.ADD)
                return left + right;
            return left - right;
        }

        public override int VisitParens(DomainParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
