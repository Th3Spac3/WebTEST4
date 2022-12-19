var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
IConfigurationRoot Configuration;
Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

var confBuilder = new ConfigurationBuilder().SetBasePath("\\Users\\thesp\\source\\repos\\WebTEST4\\WebTEST4\\").AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddJsonFile($"appsettings.Development.json", optional: true).AddEnvironmentVariables();
Configuration = confBuilder.Build();
builder.Services.Add(new ServiceDescriptor(typeof(WebTEST4.Models.AppContext), new WebTEST4.Models.AppContext(Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();