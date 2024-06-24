using HNG.Abstractions.Helpers;
using IPinfo;
using IPinfo.Models;
using Microsoft.Extensions.Caching.Memory;

namespace HNG.Api.Client.Extensions
{
    /// <summary>
    /// IpInfo Service  Extension
    /// </summary>
    public class IpInfoService
    {
        private readonly IPinfoClient _ipInfoClient;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(30);
        private const int PrefixLength = 24;

        /// <summary>
        /// constructor
        /// </summary>
        public IpInfoService(IPinfoClient ipInfoClient, IMemoryCache cache)
        {
            _ipInfoClient = ipInfoClient;
            _cache = cache;
        }

        /// <summary>
        /// Get ip address information based on provided ip address
        /// </summary>
        public async Task<IPResponse?> GetIpInfoAsync(string ip)
        {
            var ipRange = IpRangeHelper.GetIpRange(ip, PrefixLength);

            if (_cache.TryGetValue(ipRange, out IPResponse? cachedResponse))
            {
                return cachedResponse;
            }

            var response = await _ipInfoClient.IPApi.GetDetailsAsync(ip);
            _cache.Set(ipRange, response, _cacheDuration);
            return response;
        }
    }
}
