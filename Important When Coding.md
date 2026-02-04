# .Net

## Steps when we use Code First Approach

### Step-1
- install 3 packages in your application
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Tools
3. Microsoft.EntityFrameworkCore.Design

### Step-2
- Create 'DBContextClass' and Inherited this class with 'DbContext'.
- this class manages the database connection and is used to retrive and store data in database.
```
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}
```
-  DbSet < T > is a collection that represent a table in  the database.
- it allows us to perform database operation CURD.

### Step-3
- Create Connection string in appsettings.json file
```
"ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-K0LK76T\\SQLEXPRESS;Database=CodeFirstApproach;Trusted_Connection=true;TrustServerCertificate=true"
}	
```
### Step-4
- Registering connection string in Program.cs file
```
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

### Step-5
- Add migration and run two commands
```
add-migration

update-database
```

## Steps when we use Database First Approach

### Step-1
- Create Database and tables in database

### Step-2
- install 3 packages in your application
1. Microsoft.EntityFrameworkCore.SqlServer
2. Microsoft.EntityFrameworkCore.Tools
3. Microsoft.EntityFrameworkCore.Design

### Step-3
- execute a command in Package Manager Console for scaffold DbContext
```
Scaffold-DbContext "Server=DESKTOP-K0LK76T\SQLEXPRESS;Database=DatabaseName;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```
- this command will generate model class and DbContext class automatically.
- IF you want to update your database then make changes in database save that changes and run this command
```
Scaffold-DbContext "Server=DESKTOP-K0LK76T\SQLEXPRESS;Database=DatabaseName;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
```

### Step-4
- Move connection string from DbContext class to appsettings.json file
```
"ConnectionStrings": {
    "DefaultConnection": "server=DESKTOP-K0LK76T\\SQLEXPRESS; database=DatabaseFirstApproach; trusted_connection=true; TrustServerCertificate=True;"
}
```

### Step-4
- Register connection string in Program.cs
```
builder.Services.AddDbContext<DatabaseFirstApproachContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

## Important
- If you want to add automatically Home Controller, View of all action methods, all code necessary code in action methods, 
    - then first you need to delete HomeController.cs file, 
    - then delete Home Views / Home Folder 
    - Right click on Controller folder -> 
    - Add -> 
    - Controller -> 
    - MVC controller with views, using Entity Framework
    - Click Add.

## Important
## How to display ModelState.AddModelError errors in try catch block.
- when i perform any action if error occur it will display error msg on perticullar view file according to action method.
- but in view i need to write some code that display error msg. 
- do this...

✅ Step 1: Create a Partial View for Error Messages
- Create a new file: 📂 Views/Shared/_ErrorMessages.cshtml
- Add this code inside _ErrorMessages.cshtml:
```
@if (!ViewData.ModelState.IsValid)
{
    <div class="alert alert-danger">
        @foreach (var error in ViewData.ModelState.Values.SelectMany(v => v.Errors))
        {
            <p>@error.ErrorMessage</p>
        }
    </div>
}
```
- This will display all error messages added using ModelState.AddModelError()

✅ Step 2: Include This Partial View in Every View File 
- Now, add the following line at the top of each view file where you want to show errors:
```
<partial name="_ErrorMessages" />
```
- Example usage in Create.cshtml, Edit.cshtml, etc. :
```
@model _30_Admin_Panel_Project.Models.Student

@{
    ViewData["Title"] = "Create";
}

<h1>Create Student</h1>

<partial name="_ErrorMessages" /> <!-- ✅ Include Error Messages Here -->

<form asp-action="Create">
    <div class="form-group">
        <label asp-for="Name"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    <br />
    <input type="submit" value="Create" class="btn btn-primary" />
</form>
```
✅ Now, You Only Need to Add This Once in Each View

- if you add this in your view
    ```
    <partial name="_ErrorMessages" /> <!-- ✅ Include Error Messages Here -->
    ```
    
    then remove
```
<div asp-validation-summary="ModelOnly" class="text-danger"></div>
```

## When you add Identity framework in you application.
### if you want to add Admin and its role bydefault use this method.
### -  Prefer sencond way
- in program.cs file
1. way 
```
// Seed roles and default admin user
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Roles to add
    string[] roles = { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Default Admin user
    string adminEmail = "admin@gmail.com";
    string adminPassword = "Admin@123"; // Change this later

    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = "Aniket",
            LastName = "Supekar",
            EmailConfirmed = true,
            DateAndTime = DateTime.Now
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
```

- 2-way
- in program.cs file
```
// Seed roles & default admin
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Ensure roles exist
    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Read admin details from appsettings.json
    var adminConfig = builder.Configuration.GetSection("AdminUser");
    string adminEmail = adminConfig["Email"];
    string adminPassword = adminConfig["Password"];
    string firstName = adminConfig["FirstName"];
    string lastName = adminConfig["LastName"];

    // Find existing admin
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        // Create new Admin
        adminUser = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = firstName,
            LastName = lastName,
            EmailConfirmed = true,
            DateAndTime = DateTime.Now
        };

        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
    else
    {
        // Update details if changed
        bool updateNeeded = false;

        if (adminUser.FirstName != firstName) { adminUser.FirstName = firstName; updateNeeded = true; }
        if (adminUser.LastName != lastName) { adminUser.LastName = lastName; updateNeeded = true; }

        if (updateNeeded)
        {
            await userManager.UpdateAsync(adminUser);
        }

        // Update password if different
        var passwordValid = await userManager.CheckPasswordAsync(adminUser, adminPassword);
        if (!passwordValid)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(adminUser);
            await userManager.ResetPasswordAsync(adminUser, token, adminPassword);
        }

        // Ensure Admin role
        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}

```

- in appSettings.json file
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },

  "AdminUser": {
    "Email": "admin@gmail.com",
    "Password": "Admin@123",
    "FirstName": "Aniket",
    "LastName": "Supekar"
  },

  "AllowedHosts": "*",

  "ConnectionStrings": {
    "ApplicationDBContextConnection": "Server=DESKTOP-K0LK76T\\SQLEXPRESS;Database=ExpenseManager;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

## When we use Identity in our application, it creates a User table bydefault, this model class in Areas folder, but normaly model class in Model folder.

### Why UserManager instead of DbContext?
- Identity has special rules
    - Users are not just plain database rows.
    - They have hashed passwords, security stamps, lockout settings, roles, claims, etc.
    - These are maintained internally by Identity, not just stored in the AspNetUsers table.

- UserManager provides APIs to handle all this correctly
    - Example: FindByIdAsync, CreateAsync, DeleteAsync, UpdateAsync.
    - When you call DeleteAsync(user), Identity takes care of removing the user and also cleaning up related records in AspNetUserRoles, AspNetUserClaims, etc.
    - If you delete directly with DbContext.Users.Remove(user), you'd break relationships and may leave orphaned data.

- Behind the scenes UserManager still uses DbContext
    - UserManager<ApplicationUser> is a wrapper around your ApplicationDbContext + Identity logic.
    - It protects you from messing up sensitive fields like password hashes or security tokens.

### When to use what?

- For Identity Users (ApplicationUser) => Use UserManager
    - CreateAsync => adds user with password & hash.
    - UpdateAsync => updates user safely.
    - DeleteAsync => removes user and related records.

- For your own entities (Category, Expense, etc.) => Use ApplicationDbContext
    - They dont need special security rules.
    - You can do normal dbContext.Categories.Add(...), dbContext.SaveChanges(). 

Ex - 
```
namespace ExpenseManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // List all users
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
    }
}
```

## How to send Email ?

1. Enable the 2-Step Verification - On, on your google account.

2. Then search App Password, then create your app password and save it in text file.

3. Create a Helper Folder in your application.
 
4. Create a class called EmailHelper.
```
using System.Net;
using System.Net.Mail;

namespace _42_Email_Sender.Helper
{
    public class EmailHelper
    {
        private readonly IConfiguration _config;

        public EmailHelper(IConfiguration configuration)
        {
            _config = configuration;
        }

        public bool SendEmail(string email, string subject, string body)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.From = new MailAddress(_config["EmailSettings:FromEmail"]);
            message.To.Add(email);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(
                            _config["EmailSettings:FromEmail"],
                            _config["EmailSettings:AppPassword"]
                        );
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtpClient.Send(message);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
```
5. add your details in appsettings.json file
```
"EmailSettings": {
  "FromEmail": "supekarsupekar4@gmail.com",
  "AppPassword": "bofc sxol zumq gqvw"
},
```
this app passwrd from google app password.

5. Create object of this class in Controller class
```
private readonly EmailHelper _emailHelper;
```
and then add in constructor.
```
[HttpPost]
public IActionResult SendEmail(string email, string subject, string message)
{
    bool response = _emailHelper.SendEmail(email, subject, message);

    if (response)
        TempData["Message"] = "Email sent successfully!";
    else
        TempData["Message"] = "Failed to send email.";

    return RedirectToAction("Index");
}
```
6. Add this service in program.cs file
```
builder.Services.AddTransient<EmailHelper>();
``` 

## 


