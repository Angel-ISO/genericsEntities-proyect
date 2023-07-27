using AspNetCoreRateLimit;
using CoreInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Infrastructure.Repositories;
using Core.Interfaces;
using Infrastructure.UnitOfWork;

namespace API.Extensions;
public static  class AplicationServiceExtension
{ public static void ConfigureCors(this IServiceCollection services)=>
  services.AddCors(options =>
  {
    options.AddPolicy("CorsPolicy", Builder => 
      Builder.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());
  });
     public static void AddAplicationService(this IServiceCollection services)
     {
        // services.AddScoped<IMoviesInterface, MovieRepository>();
        // services.AddScoped<IGenreInterface, GenreRepository>();
        // services.AddScoped<IDirectorInterface, DirectorRepository>();
         services.AddScoped<IUnitOfWork, UnitOfWork>();
     }


   public static void ConfigureRateLimiting(this IServiceCollection services)
   {
    services.AddMemoryCache();
    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    services.AddInMemoryRateLimiting();
    services.Configure<IpRateLimitOptions>(options =>{
      
      options.EnableEndpointRateLimiting = true;
      options.StackBlockedRequests = false;
      options.HttpStatusCode = 429;
      options.RealIpHeader = "localhost";
      options.GeneralRules = new List<RateLimitRule> 
        {
          new RateLimitRule
          {
            Endpoint = "*",
            Period  ="10s",
            Limit = 2
          }
        };
    });
   }

   public static void ConfigureApiVersioning(this IServiceCollection services)
   {
    services.AddApiVersioning (Options => {
       

       Options.DefaultApiVersion = new ApiVersion(1, 0);
       Options.AssumeDefaultVersionWhenUnspecified = true;
       Options.ApiVersionReader = new QueryStringApiVersionReader("v");

    });
   }

}