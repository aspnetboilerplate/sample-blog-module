using Abp.Application.Navigation;
using Abp.Localization;

namespace Abp.Samples.Blog.Web.Navigation
{
    public class BlogNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "SampleBlog.AdminPage",
                        new FixedLocalizableString("Blog"),
                        url: "#/blog",
                        icon: "fa fa-list"
                        )
                );
        }
    }
}
