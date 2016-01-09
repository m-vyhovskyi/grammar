using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVision.Language.Definitions
{
    public interface IDefinition
    {
        void Enter(ParserRuleContext context, IDefinition parent);
        void Exit();
    }
}
