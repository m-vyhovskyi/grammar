using Antlr4.Runtime;
namespace eVision.Language.Definitions
{
    public class BasedOnNameDefinition<C> : NameDefinition<C> where C : ParserRuleContext
    {
        public string BasedOn { get; set; }
    }
}