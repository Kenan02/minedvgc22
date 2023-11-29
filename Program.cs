using Generic_Employee_Dashboard;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<EmployeeRepoOptions>(options =>
{
    options.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
});


// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<EmployeeRepo>();
builder.Services.AddTransient<EmployeeInfoRepo>();

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
    pattern: "{controller=EmployeeController}/{action=Index}/{id?}");




app.MapFallbackToFile("index.html");

app.Run();
