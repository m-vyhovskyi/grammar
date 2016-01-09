using eVision.Language.Grammar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eVision.Language.Definitions.Descriptor
{
    public class DescriptorDefinition : BasedOnNameDefinition<DomainParser.DefineDescriptorContext>,
        IApplyDefinition<DescriptorItemDefinition>
    {
        public List<DescriptorItemDefinition> Items { get; set; }

        public DescriptorDefinition()
        {
            Items = new List<DescriptorItemDefinition>();
        }

        public override string ToString()
        {
            return String.Format("descriptor {0}{1}; ",Id, !string.IsNullOrWhiteSpace(BasedOn)?" inherits from "+BasedOn:String.Empty);
        }

        public override void Exit()
        {
            (Parent as IApplyDefinition<DescriptorDefinition>).Apply(this);
        }
        public void Apply(DescriptorItemDefinition definition)
        {
            Items.Add(definition);
        }
    }
}