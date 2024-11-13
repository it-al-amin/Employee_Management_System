using Employee_Management_System.Repositories;
using Employee_Management_System.Services;
using Microsoft.EntityFrameworkCore;
using Employee_Management_System;

var builder = WebApplication.CreateBuilder(args);

// Configure services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add MVC controllers with views
    services.AddControllersWithViews();

    // Configure the SQLite database context
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

    // Register the repository and service with dependency injection
    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddScoped<IEmployeeService, EmployeeService>();
}

void ConfigureMiddleware(WebApplication app)
{
    // Error handling (for production
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Employee/Error"); // Handle errors in the Employee controller (if required)
        app.UseHsts(); // HTTP Strict Transport Security for production
    }
    else
    {
        app.UseDeveloperExceptionPage(); // Developer exception page for debugging in development
    }

    // Serve static files like CSS, JS, and images
    app.UseStaticFiles();

    // Enable routing
    app.UseRouting();

    // Add authorization (authentication middleware can be added if needed)
    app.UseAuthorization();

    // Configure the default route to render Employee/Index first
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Employee}/{action=Index}/{id?}"); // Default route to Employee/Index
}
