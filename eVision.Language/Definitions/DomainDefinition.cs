using System;
using System.Collections.Generic;
using System.Linq;

using eVision.Language.Definitions.Descriptor;
using eVision.Language.Grammar;

namespace eVision.Language.Definitions
{
    public class DomainDefinition : Definition<DomainParser.DomainContext>
        , IApplyDefinition<DescriptorDefinition>
    {
        public DefinitionList Definitions { get; private set; }

        public DomainDefinition(): base()
        {
            Definitions = new DefinitionList("definitions");
        }

        public IEnumerable<DescriptorDefinition> Descriptors { get { return Definitions.Cast<DescriptorDefinition>(); } }

        public override string ToString()
        {
            return String.Format("domain {0} {{ {1} }}",Id, Definitions);
        }

        public void Apply(DescriptorDefinition definition)
        {
            Definitions.Add(definition);
        }
    }
}
