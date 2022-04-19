using Core.Base.Abstract;
using Core.IoC;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Globalization;

namespace Core.Base.Concrete
{
    public class LocalizerService : ILocalizerService
    {
        private readonly IMemoryCache cache;
        public LocalizerService()
        {
            cache = Provider.Resolve<IMemoryCache>();
        }

        public bool DoesCultureExist(string cultureName)
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                                .Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
        }
        public string GetTranslatedValue(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            List<string> keys = new();
            keys.AddRange(key.Split("."));
            var resources = GetResourcesFromJson();

            if (!resources.TryGetValue(keys.First(), out object firstLevelOfResource))
            {
                return key;
            }

            var secondLevelOfResource = JsonConvert.DeserializeObject<Dictionary<string, string>>(firstLevelOfResource.ToString());

            if (!secondLevelOfResource.TryGetValue(keys.Last(), out string resource))
            {
                return key;
            }
            return resource;
        }
        public Dictionary<string, object> GetResourcesFromJson()
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
    }
}
