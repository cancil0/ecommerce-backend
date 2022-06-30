using Core.Abstract;
using Core.ExceptionHandler;
using Core.Extension;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace Core.Concrete
{
    public class LocalizerService : ILocalizerService
    {
        private readonly IMemoryCache cache;
        public LocalizerService(IMemoryCache cache)
        {
            this.cache = cache;
        }
        public bool DoesCultureExist(string cultureName)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
        }
        public string GetResource(string key, params string[] args)
        {
            var isThrowException = Provider.Configuration["Exceptions:ThrowException:NotFoundResourceKey"].ToBoolean();

            if (string.IsNullOrEmpty(key))
            {
                return isThrowException
                    ? throw new AppException("Localization.KeyCanNotBeNull")
                    : key;
            }

            List<string> keys = new();
            keys.AddRange(key.Split("."));
            var resources = GetResources();

            if (!resources.TryGetValue(keys.First(), out object firstLevelOfResource))
            {
                return isThrowException
                    ? throw new AppException("Localization.KeyNotFound", HttpStatusCode.NotFound.ToString(), key)
                    : key;
            }

            var secondLevelOfResource = JsonConvert.DeserializeObject<Dictionary<string, string>>(firstLevelOfResource.ToString());

            if (!secondLevelOfResource.TryGetValue(keys.Last(), out string resource))
            {
                return isThrowException
                    ? throw new AppException("Localization.KeyNotFound", HttpStatusCode.NotFound.ToString(), key)
                    : key;
            }

            return string.Format(resource, args);
        }
        public Dictionary<string, object> GetResources()
        {
            string fileName = GetResourceFileName();
            if (!cache.TryGetValue(fileName, out Dictionary<string, object> resources))
            {
                string baseDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                using StreamReader reader = new(string.Format("{0}\\Core\\Resources\\{1}", baseDirectory, fileName));
                string json = reader.ReadToEnd();
                resources = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                cache.Set(fileName, resources);
            }
            return resources;
        }

        public string GetResourceFileName()
        {
            string cultureKey = CultureInfo.CurrentCulture.TwoLetterISOLanguageName ?? "en";
            return string.Format("{0}.json", cultureKey.ToString());
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
    }
}
