using CRUD_Game.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri (builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<IGameServices, GameServices>();
await builder.Build().RunAsync();
