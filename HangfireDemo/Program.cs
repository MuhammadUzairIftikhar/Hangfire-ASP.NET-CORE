using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Hangfire services.
builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage(); // Use in-memory storage for simplicity.
});
builder.Services.AddHangfireServer(); // Add Hangfire processing server.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map Hangfire Dashboard
app.UseHangfireDashboard(); // Adds the Hangfire dashboard middleware.

// Map routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
