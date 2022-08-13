using Microsoft.AspNetCore.Http;

namespace Core.Abstract
{
    public interface ILocalizerService
    {
        bool DoesCultureExist(string cultureName);
        string GetResource(string key, params string[] args);
        Dictionary<string, object> GetResources();
        void SetLanguage(HttpContext context);
    }
}
