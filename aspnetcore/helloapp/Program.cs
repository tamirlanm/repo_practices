var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/about", () => "This web-application is about 'The Beginning of the my development in .NET World Development'.");
DateTime current = DateTime.Now;
app.MapGet("/time", () => $"This is our time in current time: {current}");

app.Run();
