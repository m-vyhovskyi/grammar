using System;
using System.Collections.Generic;
using System.Linq;

using eVision.Language.Definitions.Descriptor;

namespace eVision.Language.Definitions
{
    public class DomainDefinition : Definition
    {
        private readonly DefinitionList definitions = new DefinitionList("definitions");

        public void AddDefinition(Definition definition)
        {
            definitions.Add(definition);
        }

        public IEnumerable<DescriptorDefinition> Descriptors { get { return definitions.Cast<DescriptorDefinition>(); } }

        public override string ToString()
        {
            return String.Format("domain {0} {{ {1} }}",Id,definitions);
        }
    }
}
