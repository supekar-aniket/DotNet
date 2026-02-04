var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("/home", () => "Hello World - This https method works on all mapping methods!!!");
//app.MapGet("/home", () => "Hello World - MapGet() method used for get the data!!!");
//app.MapPost("/home", () => "Hello World - MapPost() method used for post the data!!!");
//app.MapPut("/home", () => "Hello World - MapPut() method used for update the data!!!");
//app.MapDelete("/home",() => "Hello World - MapDelete() method used for delete the data!!!");

// better way to write a http methods

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/Home",async (context) =>
    {
        await context.Response.WriteAsync("This is home page - Get");
    });

    endpoints.MapPost("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page - Post");
    });

    endpoints.MapPut("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page - Put");
    });

    endpoints.MapDelete("/Home", async (context) =>
    {
        await context.Response.WriteAsync("This is home page - Delete");
    });
});


app.Run();
