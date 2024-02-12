using Northwind.EntityModels;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNorthwindContext();
builder.Services.AddRazorPages();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;
    if (rep is not null)
    {
        WriteLine($"Endpoint name: {rep.DisplayName}");
        WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}");

    }

    if (context.Request.Path == "/bonjour")
    {
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    await next();
});
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();    
app.MapGet("/hello", () => $"Environment is {app.Environment.EnvironmentName}");

app.Run();
