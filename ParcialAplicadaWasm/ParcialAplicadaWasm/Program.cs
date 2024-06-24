using ParcialAplicadaWasm.Client.Pages;
using ParcialAplicadaWasm.Client.Services;
using ParcialAplicadaWasm.Components;
using Shared.Interfaces;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped<IClientService<Articulos>, ArticulosService>();

        builder.Services.AddScoped(a =>
        new HttpClient
        {
            BaseAddress = new Uri((builder.Configuration.GetSection("Url")!.Value)!)
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ParcialAplicadaWasm.Client._Imports).Assembly).AddInteractiveWebAssemblyRenderMode();

app.Run();


