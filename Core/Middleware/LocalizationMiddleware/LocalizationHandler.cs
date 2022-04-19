using Core.Base.Abstract;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Core.Middleware.LocalizationMiddleware
{
    public class LocalizationHandler : IMiddleware
    {
        private readonly ILocalizerService localizerService;
        public LocalizationHandler()
        {
            localizerService = Provider.Resolve<ILocalizerService>();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            SetLanguage(context);
            await next(context);
        }

        private void SetLanguage(HttpContext context)
        {
            string cultureKey = null;
            if (context.Request.Headers.TryGetValue("Accept-Language", out var acceptLang))
            {
                cultureKey = acceptLang;
            }
            else
            {
                cultureKey = "en-US";
            }

            if (localizerService.DoesCultureExist(cultureKey))
            {
                var culture = new CultureInfo(cultureKey);
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;
            }

            localizerService.GetResourcesFromJson();
        }
        
    }
}
