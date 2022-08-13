using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolver.Autofac;
using Core.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.SetBuilder();
builder.Services.AddAutofacContainer();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(x =>
{
    x.RegisterModule(new AutofacBusinessModule());
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.ConfigSwagger();
app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.AddCustomMiddlewares();
app.MapControllers();

app.Run();
