using System.Collections.Generic;
using System.Text;

namespace eVision.Language.Definitions
{
    public class DefinitionList : List<IDefinition>
    {
        private readonly string name;

        public DefinitionList(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendFormat("{0} {{ ", name);
            foreach (var item in this)
            {
                builder.Append(item);
            }
            builder.Append(" }");
            return builder.ToString();
        }
    }
}