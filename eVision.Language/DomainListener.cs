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

        public IDefinition RootDefinition { get; set; }

        private IDefinition GetParentFor(RuleContext ctx)
        {
            var parent = ctx.parent;
            while (parent != null && !Definitions.ContainsKey(parent))
            {
                parent = parent.parent;
            }
            if (parent != null)
            {
                return Definitions[parent];
            }
            return null;
        }

        private IDefinition GetDefinitionFor(ParserRuleContext ctx)
        {
            var handleType = TypeLocator.GetHandleType(ctx);
            if (handleType != null)
            {
                return Activator.CreateInstance(handleType) as IDefinition;
            }
            return null;
        }

        public void EnterEveryRule(ParserRuleContext ctx)
        {
            Console.WriteLine("Entering rule {0}",ctx);
            var definition = GetDefinitionFor(ctx);
            if (definition != null)
            {
                if (RootDefinition == null)
                {
                    RootDefinition = definition;
                }
                var parentDefinition = GetParentFor(ctx);
                definition.Enter(ctx, parentDefinition);
                Definitions.Add(ctx, definition);
            }
        }

        public void ExitEveryRule(Antlr4.Runtime.ParserRuleContext ctx)
        {
            Console.WriteLine("Exiting rule {0}", ctx);
            if (Definitions.ContainsKey(ctx))
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
