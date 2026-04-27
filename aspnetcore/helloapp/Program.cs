var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async(context)=>
{
    var response = context.Response;
    response.ContentType = "text/html; charset=utf-8";
    await response.WriteAsync("<h2>HOLA MI GUSTO</h2><h3>Welcomde to ASP.NET Core</h3>");
});
app.Run();