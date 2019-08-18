using System;

namespace IGTI.PA.UseCases.Adapters.Database
{
    public interface TermsCodeCache
    {
        void Add(string uid, Guid code);
        Guid Get(string uid);
    }
}
