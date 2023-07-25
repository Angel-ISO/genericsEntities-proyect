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
}