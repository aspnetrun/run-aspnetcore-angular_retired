using System.Collections.Generic;

namespace AspnetRunAngular.Core.Providers
{
    public interface ISequenceProvider
    {
        string GetValue(Sequence.Sequence sequence);

        IList<Sequence.Sequence> GetSequences();
    }
}
