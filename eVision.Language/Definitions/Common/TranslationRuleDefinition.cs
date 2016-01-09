using eVision.Language.Grammar;
namespace eVision.Language.Definitions.Common
{
    public class TranslationRuleDefinition: Definition<DomainParser.TranslationRuleContext>
    {
        public string Translation { get; private set; }
        protected override void Handle()
        {
            Id = Context.LANGID().GetText();
            Translation = Context.STRING().GetText();
        }
    }
}