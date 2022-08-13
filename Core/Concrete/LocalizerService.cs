using Core.Abstract;
using Core.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace Core.Concrete
{
    public class LocalizerService : ILocalizerService
    {
        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;
        public LocalizerService(IMemoryCache cache, IConfiguration configuration)
        {
            this.cache = cache;
            this.configuration = configuration;
        }
        public bool DoesCultureExist(string cultureName)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
        }
        public string GetResource(string key, params string[] args)
        {
            var isThrowException = configuration.GetValue<bool>("Exceptions:ThrowException:NotFoundResourceKey");

            if (string.IsNullOrEmpty(key))
            {
                if (isThrowException)
                {
                    throw new AppException("Localization.KeyCanNotBeNull");
                }

                key = "Localization.KeyIsNull";
            }

            List<string> keys = new();
            keys.AddRange(key.Split("."));
            var resources = GetResources();

            if (!resources.TryGetValue(keys.First(), out object firstLevelOfResource))
            {
                return isThrowException
                    ? throw new AppException("Localization.KeyNotFound", HttpStatusCode.NotFound.ToString(), key)
                    : string.Format(key, args);
            }

            var secondLevelOfResource = JsonConvert.DeserializeObject<Dictionary<string, string>>(firstLevelOfResource.ToString());

            if (!secondLevelOfResource.TryGetValue(keys.Last(), out string resource))
            {
                return isThrowException
                    ? throw new AppException("Localization.KeyNotFound", HttpStatusCode.NotFound.ToString(), key)
                    : string.Format(key, args);
            }

            return string.Format(resource, args);
        }
        public Dictionary<string, object> GetResources()
        {
            string fileName = GetResourceFileName();
            if (!cache.TryGetValue(fileName, out Dictionary<string, object> resources))
            {
                var path = Path.Combine(GetResourcePath(), fileName);
                using StreamReader reader = new(path);
                string json = reader.ReadToEnd();
                resources = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                cache.Set(fileName, resources);
            }
            return resources;
        }

        public void SetLanguage(HttpContext context)
        {
            string cultureKey;
            if (context.Request.Headers.TryGetValue("Accept-Language", out var acceptLang))
            {
                cultureKey = acceptLang.ToString().Split(",").First();
            }
            else
            {
                cultureKey = "en-US";
            }

            if (DoesCultureExist(cultureKey))
            {
                var culture = new CultureInfo(cultureKey);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            GetResources();
        }

        #region Private Methods
        private static string GetResourceFileName()
        {
            string cultureKey = CultureInfo.CurrentCulture.TwoLetterISOLanguageName ?? "en";
            return string.Format("{0}.json", cultureKey.ToString());
        }

        private static string GetResourcePath()
        {
            var path = Path.Combine(Path.GetDirectoryName(Environment.CurrentDirectory), "Resources");
            return path;
        }

        #endregion
    }
}
