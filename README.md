# Minimal Web APIs in .Net



## Reference

- [Minimal APIs Fundamentals in .Net](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
- [Tutorials Minimal APIs for ASPCore.Net](https://docs.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio-code)
- [Real World Minimal Apis: Video](https://docs.microsoft.com/en-gb/events/dotnetconf-2021/real-world-minimal-apis)

Minimal Web API are based used on [Vertical Slice Architecture](https://garywoodfine.com/implementing-vertical-slice-architecture/). 

More articles for [Awesome Architecture of Vertical Slices](https://awesome-architecture.com/vertical-slice-architecture/)

Here is an example [of more comprehensive solution in .Net for Minimal API](https://github.com/isaacOjeda/MinimalApiArchitecture)

# Example command

```shell
dotnet new webapi -minimal -o TodoApi
cd TodoApi
code -r ../TodoApi
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

# Differences between minimal APIs and APIs with controllers

-  No support for filters: For example, no support for IAsyncAuthorizationFilter, IAsyncActionFilter, IAsyncExceptionFilter, IAsyncResultFilter, and IAsyncResourceFilter.
-  No support for model binding, i.e. IModelBinderProvider, IModelBinder. Support can be added with a custom binding shim.
-  No support for binding from forms. This includes binding IFormFile. We plan to add support for IFormFile in the future.
-  No built-in support for validation, i.e. IModelValidator
-  No support for application parts or the application model. There's no way to apply or build your own conventions.
-  No built-in view rendering support. We recommend using Razor Pages for rendering views.
-  No support for JsonPatch
-  No support for OData
-  No support for ApiVersioning. See this issue for more details.
