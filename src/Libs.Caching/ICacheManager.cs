using System;
using System.Collections.Generic;

namespace Libs.Caching
{
    public interface ICacheManager : IDisposable
    {
        IReadOnlyList<ICache> GetAllCaches();

        ICache GetCache(string name);
    }
}
