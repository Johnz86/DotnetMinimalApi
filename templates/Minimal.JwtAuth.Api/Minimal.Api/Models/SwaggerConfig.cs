using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerConfig
{
  public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
  {
    swaggerGenOptions.SwaggerDoc("v1", GetInfo());
    swaggerGenOptions.AddSecurityDefinition("Bearer", GetSecurityScheme());
    swaggerGenOptions.AddSecurityRequirement(GetSecurityRequirement());    
  }

  public static OpenApiInfo GetInfo()
  {
    return new OpenApiInfo()
    {
      Version = "v1",
      Title = "Minimal API - JWT Authentication with Swagger demo",
      Description = "Implementing JWT Authentication in Minimal API",
      TermsOfService = new Uri("https://github.com/Johnz86/DotnetMinimalApi"),
      Contact = GetContact(),
      License = GetLicense()
    };
  }

  public static OpenApiContact GetContact()
  {
    return new OpenApiContact()
    {
      Name = "Jan Jakubcik",
      Email = "jan.jakubcik@siemens-healthineers.com",
      Url = new Uri("https://github.com/Johnz86/DotnetMinimalApi")
    };
  }

  public static OpenApiLicense GetLicense()
  {
    return new OpenApiLicense()
    {
      Name = "Free License",
      Url = new Uri("https://github.com/Johnz86/DotnetMinimalApi")
    };
  }

  public static OpenApiSecurityScheme GetSecurityScheme()
  {
    return new OpenApiSecurityScheme()
    {
      Name = HeaderNames.Authorization,
      In = ParameterLocation.Header,
      Type = SecuritySchemeType.ApiKey,
      Scheme = JwtBearerDefaults.AuthenticationScheme,
      BearerFormat = "JWT",
      Description = "JSON Web Token based security. Insert the token with the 'Bearer ' prefix.",
    };
  }

  public static OpenApiSecurityRequirement GetSecurityRequirement()
  {
    return new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[] {}
        }
    };
  }
}