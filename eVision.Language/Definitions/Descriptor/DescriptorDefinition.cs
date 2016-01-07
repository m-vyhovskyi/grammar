using System;
using System.Collections.Generic;
using System.Linq;

namespace eVision.Language.Definitions.Descriptor
{
    public class DescriptorDefinition : BasedOnNameDefinition
    {
        private readonly List<Definition> itemDefinitions = new List<Definition>();
        
        public void AddItemDefinition(Definition itemDefinition)
        {
            itemDefinitions.Add(itemDefinition);
        }

        public IEnumerable<DescriptorItemDefinition> Items { get { return itemDefinitions.Cast<DescriptorItemDefinition>(); } }

        public override string ToString()
        {
            return String.Format("descriptor {0}{1}; ",Id, !string.IsNullOrWhiteSpace(BasedOn)?" inherits from "+BasedOn:String.Empty);
        }
    }
}