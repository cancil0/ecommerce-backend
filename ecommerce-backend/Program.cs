using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolver.Autofac;
using Business.Validation.EntityValidator;
using Core.Extension;
using FluentValidation.AspNetCore;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Format("{0}{1}", Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddMemoryCache(x => x.ExpirationScanFrequency = TimeSpan.FromMinutes(30));
builder.Services.AddControllers()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
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
builder.Services.AddAutofacContainer();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(x => x.RegisterModule(new AutofacBusinessModule()));
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
