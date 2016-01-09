using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eVision.Language.Grammar;
using eVision.Language.Definitions;
using eVision.Language.Definitions.Descriptor;
using Antlr4.Runtime;
using eVision.Language.Definitions.Common;

namespace eVision.Language
{
    public class DomainListener: IParseTreeListener
    {
        private Dictionary<RuleContext, IDefinition> Definitions = new Dictionary<RuleContext, IDefinition>();

        public DomainDefinition domain = new DomainDefinition();

        private IDefinition GetParentFor(RuleContext ctx)
        {
            var parent = ctx.parent;
            while (!Definitions.ContainsKey(parent) && parent != null)
            {
                parent = parent.parent;
            }
            return Definitions[parent];
        }

        public void EnterEveryRule(Antlr4.Runtime.ParserRuleContext ctx)
        {
            Console.WriteLine("Entering rule {0}",ctx);
            // try to resolve a definition to handle the context visit
            if (ctx is DomainParser.DomainContext)
            {
                domain.Enter(ctx as DomainParser.DomainContext, null);
                Definitions.Add(ctx, domain);
            }
            else if (ctx is DomainParser.DefineDescriptorContext)
            {
                var definition = new DescriptorDefinition();
                definition.Enter(ctx as DomainParser.DefineDescriptorContext, GetParentFor(ctx));
                Definitions.Add(ctx, definition);
            }
            else if (ctx is DomainParser.DefDescriptorItemContext)
            {
                var definition = new DescriptorItemDefinition();                
                definition.Enter(ctx as DomainParser.DefDescriptorItemContext, GetParentFor(ctx));
                Definitions.Add(ctx, definition);
            }
            else if (ctx is DomainParser.RankContext)
            {
                var definition = new RankDefinition();
                definition.Enter(ctx as DomainParser.RankContext, GetParentFor(ctx));
                Definitions.Add(ctx, definition);
            }
        }

        public void ExitEveryRule(Antlr4.Runtime.ParserRuleContext ctx)
        {
            Console.WriteLine("Exiting rule {0}", ctx);
            if (ctx is DomainParser.DomainContext)
            {
                domain.Exit();
            }
            else if (ctx is DomainParser.DefineDescriptorContext)
            {
                var definition = Definitions[ctx];
                definition.Exit();
            }
            else if (ctx is DomainParser.DescriptorItemContext)
            {
                var definition = Definitions[ctx];
                definition.Exit();
            }
            else if (ctx is DomainParser.RankContext)
            {
                var definition = Definitions[ctx];
                definition.Exit();
            }

        }

        public void VisitErrorNode(IErrorNode node)
        {
            Console.WriteLine("Error node {0}", node);
        }

        public void VisitTerminal(ITerminalNode node)
        {
            Console.WriteLine("Entering terminal {0}", node);
        }
    }
}
