using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolver.Autofac;
using Business.Mapping;
using Business.Validation.EntityValidator;
using Core.Extension;
using FluentValidation.AspNetCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Format("{0}{1}", Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddMemoryCache(x => x.ExpirationScanFrequency = TimeSpan.FromMinutes(30));

// Add services to the container.
builder.Services.AddMemoryCache(x => x.ExpirationScanFrequency = TimeSpan.FromMinutes(30));
builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddFluentValidation(x => 
{
    x.RegisterValidatorsFromAssemblyContaining<UserValidator>();
    x.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.Stop;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.IntegrateSwagger();
builder.Services.JwtSettings(builder.Configuration);
builder.Services.AddDbContext(builder.Configuration);
builder.Services.GetConfiguration(builder.Configuration);
builder.Services.InjectServices();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Logging.ClearProviders();
builder.Host.UseNLog();

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
