using eVision.Language.Grammar;
namespace eVision.Language.Definitions.Common
{
    public class RankDefinition: Definition<DomainParser.RankContext>
    {
        public override void Exit()
        {
            Id = Context.INT().GetText();
            (Parent as IApplyDefinition<RankDefinition>).Apply(this);
        }
    }
}