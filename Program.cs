using Generic_Employee_Dashboard.EmployeeMap;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<EmployeeOverviewRepoOptions>(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
});


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<EmployeeOverviewRepo>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeOverviewController}/{action=Index}/{id?}");




app.MapFallbackToFile("index.html");

app.Run();
