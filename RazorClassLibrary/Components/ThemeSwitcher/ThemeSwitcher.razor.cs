using Microsoft.AspNetCore.Components;

namespace RazorClassLibrary.Components.ThemeSwitcher
{
    public partial class ThemeSwitcher
    {
        [Inject] private ThemeSwitcherJsInterop ThemeSwitcherJsInterop { get; set; } = default!;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await ThemeSwitcherJsInterop.InitializeAsync();
        }

        internal Task SetAutoTheme() => ThemeSwitcherJsInterop.SetAutoThemeAsync();

        internal Task SetDarkTheme() => ThemeSwitcherJsInterop.SetDarkThemeAsync();

        internal Task SetLightTheme() => ThemeSwitcherJsInterop.SetLightThemeAsync();
    }
}
