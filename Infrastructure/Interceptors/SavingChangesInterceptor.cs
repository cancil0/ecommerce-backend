using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors
{
    public class SavingChangesInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            /*eventData.Context.Set<ApiLog>().Add(new ApiLog 
            {
                Request = requestData,
                Response = responseData,
                StatusCode = context.Response.StatusCode,
                ServiceName = context.Request.Path.HasValue  context.Request.Path.Value.Split("/")[3] : null,
                RouteUrl = context.Request.Path,
                Method = context.Request.Method,
                Duration = stopwatch.ElapsedMilliseconds,
                UserName = "savingchangesdeneme"
            });*/
            Console.WriteLine(eventData.Context.ChangeTracker.DebugView.LongView);
            return new InterceptionResult<int>();
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
           DbContextEventData eventData,
           InterceptionResult<int> result,
           CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine(eventData.Context.ChangeTracker.DebugView.LongView);
            return new ValueTask<InterceptionResult<int>>(result);
        }
    }
}
