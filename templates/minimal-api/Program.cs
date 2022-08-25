var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

public partial class Program {
   // Expose the Program class for use with WebApplicationFactory<T>
 }