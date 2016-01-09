using Antlr4.Runtime;
namespace eVision.Language.Definitions
{
    public abstract class BasedOnNameDefinition<C> : NameDefinition<C> where C : ParserRuleContext
    {
        public string BasedOn { get; set; }
    }
}