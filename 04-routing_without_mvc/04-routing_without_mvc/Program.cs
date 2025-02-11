var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // this is important if we want to use Convention based Routing and attribute based routing
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.MapDefaultControllerRoute();    // this method call Home controllers Index view() method

////// this is used for Convention based routing
//// access HomeController -> Index
//app.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}" //  this method call Home controllers Index view() method
//    );

//// access UserController -> Index
//app.MapControllerRoute(
//        name:"default",
//        pattern:"{controller=User}/{action=Index}" //  this method call User controllers Index view() method
//    );

//// access HomeController -> About
//app.MapControllerRoute(
//        name:"default",
//        pattern: "{controller=Home}/{action=About}" //  this method call Home controllers About view() method
//    );

// access HomeController -> Details
//app.MapControllerRoute(
//        name:"default",
//        pattern:"{controller=Home}/{action=Details}/{id?}" // id is optional, ? -> optional parameter
//    );

// This is used for Attribute based routing
app.MapControllers();


app.Run();
