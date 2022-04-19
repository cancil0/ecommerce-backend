using Core.IoC;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Globalization;

namespace Core.Base.Abstract
{
    public interface ILocalizerService
    {
        bool DoesCultureExist(string cultureName);
        string GetTranslatedValue(string key);
        Dictionary<string, object> GetResourcesFromJson();
        string GetResourceFileName();
    }

}
