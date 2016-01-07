using System;

using Antlr4.Runtime.Tree;

using eVision.Language.Definitions;
using eVision.Language.Definitions.Descriptor;
using eVision.Language.Grammar;

namespace eVision.Language.Rig.Grammar
{
    public class DomainVisitor : DomainBaseVisitor<Definition>
    {
        private T Visit<T>(IParseTree tree) where T: Definition
        {
            return (T)Visit(tree);
        }

        public override Definition VisitDomainDecl(DomainParser.DomainDeclContext context)
        {
            return new DomainDefinition { Id = context.ID().GetText() };
        }

        public override Definition VisitDomain(DomainParser.DomainContext context)
        {
            var domain = Visit<DomainDefinition>(context.domainDecl());

            foreach (var defineContext in context.define())
            {
                var model = Visit<Definition>(defineContext);
                domain.AddDefinition(model);
            }
            return domain;
        }

        public override Definition VisitDefDescriptor(DomainParser.DefDescriptorContext context)
        {
            var definition = new DescriptorDefinition
            {
                Id = context.ID().GetText()
            };

            var basedOn = context.basedOn();
            if (basedOn != null) definition.BasedOn = basedOn.ID().GetText();

            foreach (DomainParser.DefDescriptorItemContext itemContext in context.descriptorBody().descriptorItem())
            {
                definition.AddItemDefinition(VisitDefDescriptorItem(itemContext));
            }
            
            return definition;
        }

        
        public override Definition VisitDefDescriptorItem(DomainParser.DefDescriptorItemContext context)
        {
            var definition = new DescriptorItemDefinition
            {
                Id = context.ID().GetText()
            };

            var descriptorWith = context.descriptorWith();
            if (descriptorWith != null)
            {
                Visit(descriptorWith);  
            }
            return definition;
        }

        public override Definition VisitDescriptorWith(DomainParser.DescriptorWithContext context)
        {
            foreach (var translationContext in context.translation())
            {
                Visit(translationContext);
            }
            return null;
        }

        public override Definition VisitTransRule(DomainParser.TransRuleContext context)
        {
            foreach (var rule in context.translationRule())
            {
                Console.WriteLine("translated to {0} as {1}",rule.LANGID().GetText(),rule.STRING().GetText());                
            }
            return null;
        }
    }
}