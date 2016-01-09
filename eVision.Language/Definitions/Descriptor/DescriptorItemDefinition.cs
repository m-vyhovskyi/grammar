using eVision.Language.Definitions.Common;
using eVision.Language.Grammar;

namespace eVision.Language.Definitions.Descriptor
{
    public class DescriptorItemDefinition : Definition<DomainParser.DefDescriptorItemContext>
        , IApplyDefinition<RankDefinition>
    {
        public RankDefinition Rank { get; set; }

        public override void Exit()
        {
            Id = Context.ID().GetText();
             (Parent as IApplyDefinition<DescriptorItemDefinition>).Apply(this);
        }

        public void Apply(RankDefinition definition)
        {
            Rank = definition;
        }
    }
}