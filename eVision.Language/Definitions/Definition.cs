using Antlr4.Runtime;
using System;

namespace eVision.Language.Definitions
{
    public class Definition<C>: IDefinition where C : ParserRuleContext
    {
        public string Id { get; set; }

        protected C Context { get; private set; }
        protected IDefinition Parent { get; private set; }

        public override string ToString()
        {
            return string.Format("[{0}]",Id);
        }

        public virtual void Enter(C context, IDefinition parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        public virtual void Exit()
        {

        }
    }

    public class NameDefinition<C> : Definition<C> where C : ParserRuleContext
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}",Name, base.ToString());
        }
    }
}