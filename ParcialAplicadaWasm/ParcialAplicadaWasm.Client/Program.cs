using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ParcialAplicadaWasm.Client.Services;
using Shared.Interfaces;
using Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IClientService<Articulos>, ArticulosService>();

await builder.Build().RunAsync();