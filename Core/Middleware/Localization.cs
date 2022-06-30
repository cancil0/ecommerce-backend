using Core.Abstract;
using Microsoft.AspNetCore.Http;

namespace Core.Middleware
{
    public class Localization : IMiddleware
    {
        private readonly ILocalizerService localizerService;
        public Localization(ILocalizerService localizerService)
        {
            this.localizerService = localizerService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            localizerService.SetLanguage(context);

            await next(context);
        }

    }
}
