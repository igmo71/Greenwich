using Microsoft.JSInterop;

namespace RazorClassLibrary.Components.ThemeSwitcher
{
    public class ThemeSwitcherJsInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public ThemeSwitcherJsInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/RazorClassLibrary/theme-switcher.js").AsTask());
        }

        public async Task InitializeAsync()
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("initializeTheme");
        }

        internal Task SetAutoThemeAsync() => SetThemeAsync("system");

        internal Task SetDarkThemeAsync() => SetThemeAsync("dark");

        internal Task SetLightThemeAsync() => SetThemeAsync("light");

        internal async Task SetThemeAsync(string themeName)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setTheme", themeName);
        }


        public async ValueTask DisposeAsync()
        {
            try
            {
                if (moduleTask.IsValueCreated)
                {
                    var module = await moduleTask.Value;
                    await module.DisposeAsync();
                }
            }
            catch (JSDisconnectedException)
            {
                // do nothing
            }
        }
    }
}
