using BlazorContextMenu.RazorComponentsTestApp.App.Services;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorContextMenu.RazorComponentsTestApp.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Since Blazor is running on the server, we can use an application service
            // to read the forecast data.
            services.AddSingleton<SampleDataService>();

            services.AddBlazorContextMenu(options =>
            {
                options.ConfigureTemplate(defaultTemplate =>
                {
                    defaultTemplate.MenuCssClass = "my-menu";
                    defaultTemplate.MenuItemCssClass = "my-menu-item";
                    defaultTemplate.SeperatorCssClass = "my-menu-seperator";
                });

                options.ConfigureTemplate("red", template =>
                {
                    template.MenuCssClass = "red-menu";
                    template.MenuItemCssClass = "red-menu-item";
                    template.MenuItemDisabledCssClass = "red-menu-item--disabled";
                    template.SeperatorHrCssClass = "red-menu-seperator-hr";
                    template.MenuItemWithSubMenuCssClass = "red-menu-item--with-submenu";
                    template.Animation = Animation.FadeIn;
                });

                options.ConfigureTemplate("dark", template =>
                {
                    template.MenuCssClass = "dark-menu";
                    template.MenuItemCssClass = "dark-menu-item";
                    template.MenuItemDisabledCssClass = "dark-menu-item--disabled";
                    template.SeperatorHrCssClass = "dark-menu-seperator-hr";
                    template.MenuItemWithSubMenuCssClass = "dark-menu-item--with-submenu";
                });
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
