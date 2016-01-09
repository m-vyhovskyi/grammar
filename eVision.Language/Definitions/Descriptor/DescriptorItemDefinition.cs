using eVision.Language.Definitions.Common;
using eVision.Language.Grammar;

namespace eVision.Language.Definitions.Descriptor
{
    public class DescriptorItemDefinition : Definition<DomainParser.DefDescriptorItemContext>
        , IApplyDefinition<RankDefinition>
        , IApplyDefinition<TranslationRuleDefinition>
    {
        public RankDefinition Rank { get; set; }

        protected override void Handle()
        {
            Id = Context.ID().GetText();
        }

        public void Apply(RankDefinition definition)
        {
            Rank = definition;
        }

        public void Apply(TranslationRuleDefinition definition)
        {
            Translations.Add(definition);
        }

    }
}