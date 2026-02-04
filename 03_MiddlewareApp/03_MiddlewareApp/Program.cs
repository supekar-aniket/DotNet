var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// by default middleware

//app.MapGet("/", () => "Hello World!");

// When we want to use only one middleware then use Run() method.

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Welcome to ASP.NET Core 8...");
//});

// When we want to use multiple middleware then we want to use Use() method.

app.Use(async (context,next) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core 8...\n");
    await next(context);
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Welcome to ASP.NET Core 9...");
});

// Remember this --> does not execete any middleware after Run() method.

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Welcome to ASP.NET Core 8...\n");
//    await next(context);
//});

app.Run();
