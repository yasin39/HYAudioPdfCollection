using HYAudioPdfCollection;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HYAudioPdfCollection.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Ana HTML'e bağlan
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<MediaService>();

await builder.Build().RunAsync();
