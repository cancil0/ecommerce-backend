using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolver.Autofac;
using Business.Validation.EntityValidator;
using Core.Extension;
using Core.IoC;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache(x => x.ExpirationScanFrequency = TimeSpan.FromMinutes(30));
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>()) //Fluent Validation
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);//Fixes Json loop issue

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.IntegrateSwagger();
builder.Services.JwtSettings(builder.Configuration);

//Localization Middleware yapýlýyor
//builder.Services.SetCulture();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
var containerBuilder = new ContainerBuilder();
AutofacRegistration.Populate(containerBuilder, builder.Services);
containerBuilder.RegisterModule(new AutofacBusinessModule());
Provider.Container = containerBuilder.Build();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
    options.DefaultModelExpandDepth(-1);
    options.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Example);
});

app.UseHttpsRedirection();

app.UseRequestLocalization();
app.UseStaticFiles();

app.UseCors(builder => builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});

app.UseRouting();
//Custom Middleware

app.UseLocalizationHandler();

app.UseResponseHandler();
app.UseErrorHandler();
app.UseJwtHandler();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
