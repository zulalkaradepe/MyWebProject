//using Autofac;
//using Autofac.Extensions.DependencyInjection;
//using Business.Abstract;
//using Business.Concrete;
//using Business.DependencyResolvers.Autofac;
//using Core.DependencyResolvers;
//using Core.Utilities.IoC;
//using Core.Utilities.Security.Encryption;
//using Core.Utilities.Security.JWT;
//using DataAccess.Abstract;
//using DataAccess.Concrete.EntityFramework;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidIssuer = tokenOptions.Issuer,
//            ValidAudience = tokenOptions.Audience,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//        };
//    });
//ServiceTool.Create(services);

//builder.Services.AddDependencyResolvers(new ICoreModule[] {

//    new CoreModule()
//});

////builder.Services.AddSingleton<IProductService, ProductManager>();
////builder.Services.AddSingleton<IProductDal, EfProductDal>();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
//    .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); });

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}