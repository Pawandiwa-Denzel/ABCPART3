using ABC_RetailApp.Services;

namespace ABC_RetailApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<DatabaseService>();


            // Register IHttpClientFactory for FunctionService
            builder.Services.AddHttpClient<FunctionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); // serve wwwroot content
            app.UseRouting();
            app.UseAuthorization();

            // Map controller routes - set default to Home/Index
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
