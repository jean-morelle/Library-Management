using Library_Management;
using Library_Manager.Core.Interface;
using Library_Manager.Core.ServiceProvider;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IUserServices, UserServices>();

builder.Services.AddScoped<IAlertServices, AlerteServices>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7047") });

await builder.Build().RunAsync();
