using CoreContext;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using testDD;
using testDD.Context;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddDbContext<YourDbContext>(options =>
{
    options.UseNpgsql("Host=127.0.0.1;Port=5432;Database=testWEB;Username=postgres;Password=123");
});

builder.Services.AddScoped<HelperDB>();

await builder.Build().RunAsync();
