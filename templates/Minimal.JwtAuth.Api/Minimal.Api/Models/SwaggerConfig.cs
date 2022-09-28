using Swashbuckle.AspNetCore.SwaggerGen;

public class SwaggerConfig
{
  public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
  {
    OpenApiInfo info = GetInfo();
    swaggerGenOptions.SwaggerDoc(info.Version, info);
    OpenApiSecurityScheme securityScheme = GetSecurityScheme();
    swaggerGenOptions.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    swaggerGenOptions.AddSecurityRequirement(GetSecurityRequirement(securityScheme));
  }

  public static OpenApiInfo GetInfo() => new OpenApiInfo()
  {
    Version = "v1",
    Title = "Minimal.Api - JWT Authentication with Swagger",
    Description = "Implementing JWT Authentication in Minimal API",
    TermsOfService = new Uri("https://github.com/Johnz86/DotnetMinimalApi"),
    License = new OpenApiLicense
    {
      Name = "Free License",
      Url = new Uri("https://github.com/Johnz86/DotnetMinimalApi")
    },
    Contact = new OpenApiContact
    {
      Name = "Jan Jakubcik",
      Email = "jan.jakubcik@siemens-healthineers.com",
      Url = new Uri("https://github.com/Johnz86/DotnetMinimalApi")
    }
  };

  public static OpenApiSecurityScheme GetSecurityScheme() => new OpenApiSecurityScheme()
  {
    Name = HeaderNames.Authorization,
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = JwtBearerDefaults.AuthenticationScheme,
    BearerFormat = "JWT",
    Description = "JSON Web Token based security. Put **_ONLY_** token in textbox below!",
    Reference = new OpenApiReference
    {
      Id = JwtBearerDefaults.AuthenticationScheme,
      Type = ReferenceType.SecurityScheme
    }
  };

  public static OpenApiSecurityRequirement GetSecurityRequirement(OpenApiSecurityScheme scheme) =>
    new OpenApiSecurityRequirement { { scheme, Array.Empty<string>() } };

}