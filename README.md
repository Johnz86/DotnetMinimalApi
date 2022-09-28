# Minimal Web APIs in .Net

Minimal APIs are architected to create HTTP APIs with minimal code footprint. 
They include only the minimum files, features, and dependencies. 
In .Net world it usually means Web APIs without use of MVC Controller subclass.

## Reference

- [Minimal APIs Overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
- [Minimal APIs Fundamentals in .Net](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
- [Tutorials Minimal APIs for ASPCore.Net](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio-code)
- [Real World Minimal Apis: Video](https://docs.microsoft.com/en-gb/events/dotnetconf-2021/real-world-minimal-apis)

## Start from scratch with Minimal API

Following commands will get you started from scratch
```
dotnet new sln
dotnet new webapi --use-minimal-apis -o Weatherforecast.Api
dotnet new xunit -o Weatherforecast.Tests
dotnet sln add .\Weatherforecast.Api\ .\Weatherforecast.Tests\
```

In case you get certificate warning execute: 
```
dotnet dev-certs https --trust
```

Add dependencies if you want persistance layer
```
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
```

### Use Custom Templates for Minimal API in .Net

Templates which scaffold projects with Minimal API and Unit tests in .Net
```
dotnet new --install .\templates\
```
Then you can create new projects with:
```
dotnet new miniapihello -o HelloFeature
dotnet new miniapitodo -o TodoFeature
```
If you want to remove these project examples do:
```
dotnet new --uninstall .\templates\
```

## Differences between minimal APIs and APIs with Controller subclass

-  No support for filters: For example, no support for IAsyncAuthorizationFilter, IAsyncActionFilter, IAsyncExceptionFilter, IAsyncResultFilter, and IAsyncResourceFilter.
-  No support for model binding, i.e. IModelBinderProvider, IModelBinder. Support can be added with a custom binding shim.
-  No support for binding from forms. This includes binding IFormFile. We plan to add support for IFormFile in the future.
-  No built-in support for validation, i.e. IModelValidator
-  No support for application parts or the application model. There's no way to apply or build your own conventions.
-  No built-in view rendering support. We recommend using Razor Pages for rendering views.
-  No support for JsonPatch
-  No support for OData
-  No support for ApiVersioning. See this issue for more details.


## Usage in the wilds

Minimal Web API are commonly used on 
- [Vertical Slice Architecture](https://awesome-architecture.com/vertical-slice-architecture/), 
- [Microservice Architecture](https://awesome-architecture.com/microservices/microservices/), 
- [Clean Architecture](https://awesome-architecture.com/clean-architecture/), 
- [IoT Edge devices](https://en.wikipedia.org/wiki/Internet_of_things) 
- or any infrastructure components with small APIs.

Here is an example [of more complex solution in .Net for Minimal API](https://github.com/isaacOjeda/MinimalApiArchitecture)

Usage of [minimal apis by packt publishing](https://github.com/PacktPublishing/Minimal-APIs-in-ASP.NET-Core-6)
