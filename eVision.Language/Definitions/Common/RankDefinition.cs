using eVision.Language.Grammar;
namespace eVision.Language.Definitions.Common
{
    public class RankDefinition: Definition<DomainParser.RankContext>
    {
        protected override void Handle()
        {
            Id = Context.INT().GetText();
        }
    }
}