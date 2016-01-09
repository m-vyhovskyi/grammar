using Antlr4.Runtime;
using eVision.Language.Definitions.Common;
using System;
using System.Collections.Generic;

namespace eVision.Language.Definitions
{
    public abstract class Definition<C>: IDefinition where C : ParserRuleContext
    {
        public string Id { get; set; }

        protected C Context { get; private set; }
        protected IDefinition Parent { get; private set; }
        public List<TranslationRuleDefinition> Translations { get; private set; }

        public Definition()
        {
            Translations = new List<TranslationRuleDefinition>();
        }

        public void Enter(ParserRuleContext ctx, IDefinition parent)
        {
            this.Context = (C)ctx;
            this.Parent = parent;
        }

        private void ApplyToParent()
        {
            if (Parent != null)
            {
                Type definitionApplyType = typeof(IApplyDefinition<>).MakeGenericType(new Type[] { this.GetType() });
                var method = definitionApplyType.GetMethod("Apply");
                method.Invoke(Parent, new[] { this });
            }
        }

        public void Exit()
        {
            Handle();
            ApplyToParent();
        }

        protected virtual void Handle() {}

        public override string ToString()
        {
            return string.Format("[{0}]", Id);
        }

    }

    public abstract class NameDefinition<C> : Definition<C> where C : ParserRuleContext
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}",Name, base.ToString());
        }
    }
}