using System;

namespace eVision.Language.Definitions
{
    public class Definition
    {
        public string Id { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}]",Id);
        }
    }

    public class NameDefinition : Definition
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}",Name, base.ToString());
        }
    }
}