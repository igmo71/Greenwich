using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RazorClassLibrary.Components.ThemeSwitcher;

namespace BlazorApp.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddAuthorizationCore();
        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddAuthenticationStateDeserialization();

        builder.Services.AddScoped<ThemeSwitcherJsInterop>();

        await builder.Build().RunAsync();
    }
}
