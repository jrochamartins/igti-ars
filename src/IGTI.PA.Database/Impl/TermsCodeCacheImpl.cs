using IGTI.PA.UseCases.Adapters.Database;
using System;
using System.Collections.Generic;

namespace IGTI.PA.Database.Impl
{
    public class TermsCodeCacheImpl : TermsCodeCache
    {
        private readonly IDictionary<string, Guid> _cache;

        public TermsCodeCacheImpl()
        {
            _cache = new Dictionary<string, Guid>();
        }

        public void Add(string uid, Guid code)
        {
            if (_cache.ContainsKey(uid))
                _cache[uid] = code;
            else
                _cache.Add(uid, code);
        }

        public Guid Get(string uid)
        {
            if (!_cache.ContainsKey(uid))
                throw new Exception("Invalid code.");
            return _cache[uid];
        }
    }
}
