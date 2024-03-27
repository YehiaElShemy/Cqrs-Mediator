using Cqrs_Mediator.Application.Abstractions;
using Cqrs_Mediator.Application.Abstractions.HttpClientServices;
using Cqrs_Mediator.InfraStructure.HttpClientRepositry;
using Microsoft.Net.Http.Headers;

namespace Cqrs_Mediator.presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          
            builder.Services.AddHttpClient<IHttpClientServeices, HttpClientServeices>();
            builder.Services.AddHttpClient("MyHttpClient", client =>
            {
                // Configure the HttpClient here if needed
                client.BaseAddress = new Uri("https://localhost:7072/");
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                
            });
            // Add services to the container.
            builder.Services.AddControllersWithViews();
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}