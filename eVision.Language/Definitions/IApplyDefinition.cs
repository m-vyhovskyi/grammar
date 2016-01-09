using System;

namespace eVision.Language.Definitions
{
    public interface IApplyDefinition<T> where T: IDefinition
    {
        void Apply(T definition);
    }
}
