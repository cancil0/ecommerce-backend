using Core.Abstract;
using Core.Attributes;
using Core.Extension;
using Infrastructure.Concrete;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.Middleware
{
    public class DbContextHandler : IMiddleware
    {
        private Context dbContext;
        private readonly ILoggerService loggerService;
        public DbContextHandler(Context dbContext, ILoggerService loggerService)
        {
            this.dbContext = dbContext;
            this.loggerService = loggerService;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var unitOfWorkController = context.GetEndpoint().Metadata.GetMetadata<UnitofWorkAttribute>();
            if (unitOfWorkController != null)
            {
                await dbContext.Database.BeginTransactionAsync();
            }
            
            await next(context);

            if (unitOfWorkController != null)
            {
                dbContext.SaveChangesFailed += DbContext_SaveChangesFailed;
                dbContext.SavedChanges += DbContext_SavedChanges;

                var entries = dbContext.ChangeTracker.Entries();

                if (!context.Items.TryGetValue("userName", out var userName))
                {
                    userName = Environment.MachineName;
                }

                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Added && entry.Properties.Any(x => x.Metadata.Name == "CreatedDate"))
                    {
                        entry.Property("CreatedDate").CurrentValue = DateTime.Now.DateToInt();
                        entry.Property("CreatedTime").CurrentValue = DateTime.Now.TimeToInt();
                        entry.Property("CreatedBy").CurrentValue = userName;
                    }
                    else if (entry.State == EntityState.Modified && entry.Properties.Any(x => x.Metadata.Name == "UpdatedDate"))
                    {
                        entry.Property("UpdatedDate").CurrentValue = DateTime.Now.DateToInt();
                        entry.Property("UpdatedTime").CurrentValue = DateTime.Now.TimeToInt();
                        entry.Property("UpdatedBy").CurrentValue = userName;
                    }
                    else if (entry.State == EntityState.Deleted && entry.Properties.Any(x => x.Metadata.Name == "IsDeleted"))
                    {
                        if(entry.Property("IsDeleted").CurrentValue != null)
                        {
                            entry.State = EntityState.Modified;
                            entry.Property("IsDeleted").CurrentValue = true;
                        }
                        
                        entry.Property("UpdatedDate").CurrentValue = DateTime.Now.DateToInt();
                        entry.Property("UpdatedTime").CurrentValue = DateTime.Now.TimeToInt();
                        entry.Property("UpdatedBy").CurrentValue = userName;
                    }

                }
                try
                {
                    await dbContext.SaveChangesAsync();
                    await dbContext.Database.CommitTransactionAsync();
                }
                catch (DbUpdateException exception)
                {
                    dbContext.ChangeTracker.Entries().ForEach(x => x.State = EntityState.Unchanged);
                    throw exception;
                }
            }
            
        }

        private void DbContext_SavedChanges(object sender, SavedChangesEventArgs e)
        {
            loggerService.LogDebug("DbContext.CommitedSuccessfully", dbContext.ContextId.ToString());
        }

        private void DbContext_SaveChangesFailed(object sender, SaveChangesFailedEventArgs e)
        {
            loggerService.LogDebug("DbContext.NotCommitedSuccessfully", dbContext.ContextId.ToString());
        }
    }
}
