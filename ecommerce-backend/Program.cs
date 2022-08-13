using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolver.Autofac;
using Business.Mapping;
using Core.Extension;
using DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.SetBuilder();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
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
