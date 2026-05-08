var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();
//app.UseToken("555555");
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RoutingMiddleware>();
//app.Run(async(context) => await context.Response.WriteAsync("Hello world!"));

app.Run();

/*
app.UseWhen(
    context => context.Request.Path == "/time",
    appBuilder =>
    {
        //log data - output to on console app
        appBuilder.Use(async (context, next) =>
        {
            var time = DateTime.Now.ToShortTimeString();
            Console.WriteLine($"Time: {time}");
            await next(); //call next middleware
        });

        // send response
        appBuilder.Run(async (context) =>
        {
           var time = DateTime.Now.ToShortTimeString();
           await context.Response.WriteAsync($"Time: {time}"); 
        });
    }
);

app.Run(async (context)=>
{
   await context.Response.WriteAsync("Hello World!"); 
});

app.Run();
*/
/*
string date = "";

app.Use(async (context, next) =>
{
    //Console.WriteLine("Before");
    string? path = context.Request.Path.Value?.ToLower();
    if(path == "/date")
    {
        await context.Response.WriteAsync($"Date: {DateTime.Now.ToShortDateString()}");
    }
    else
    {
        await next.Invoke();
    }
    //date = DateTime.Now.ToShortDateString();
    //await next.Invoke(context); // call middleware from app.Run()
    //Console.WriteLine($"Current date: {date}");
    //await Task.Delay(1000);
    //Console.WriteLine("After");
});


app.Run(async(context) => await context.Response.WriteAsync($"Hello My World"));
//app.Run(async(context) => await context.Response.WriteAsync("Terminal response."));

app.Run();
*/