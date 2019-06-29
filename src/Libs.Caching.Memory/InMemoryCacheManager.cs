namespace Libs.Caching.Memory
{
    public class InMemoryCacheManager : CacheManagerBase
    {
        protected override ICache CreateCache(string name)
        {
            return new InMemoryCache(name);
        }
    }
}
