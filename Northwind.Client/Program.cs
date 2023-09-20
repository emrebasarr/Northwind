var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/",  async context =>
{
    var index = System.IO.File.ReadAllText("wwwroot/index.html");
    await context.Response.WriteAsync(index);
});

app.Run();
