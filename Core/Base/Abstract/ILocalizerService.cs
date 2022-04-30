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
