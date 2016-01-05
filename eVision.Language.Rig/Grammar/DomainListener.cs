using System;

using Antlr4.Runtime;

using eVision.Language.Grammar;

namespace eVision.Language.Rig.Grammar
{
    public class DomainListener : DomainBaseListener
    {
        private readonly DomainParser parser;

        public DomainListener(DomainParser parser)
        {
            this.parser = parser;
        }

        public override void EnterAssign(DomainParser.AssignContext context)
        {
            Console.WriteLine("entering assign {0}",context.ID().GetText());
            var res = new DomainVisitor().VisitAssign(context);
            Console.WriteLine(res);
        }
    }
}