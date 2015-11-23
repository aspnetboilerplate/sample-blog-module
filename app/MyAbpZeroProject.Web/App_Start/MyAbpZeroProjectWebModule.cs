using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using Abp.Samples.Blog.EntityFramework;
using Abp.Samples.Blog.Web;

namespace MyAbpZeroProject.Web
{
    [DependsOn(
        typeof(MyAbpZeroProjectDataModule), 
        typeof(MyAbpZeroProjectApplicationModule), 
        typeof(MyAbpZeroProjectWebApiModule),
        typeof(AbpSampleBlogWebModule),
        typeof(AbpSampleBlogEntityFrameworkModule)
        )]
    public class MyAbpZeroProjectWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "简体中文", "famfamfam-flag-cn"));

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    MyAbpZeroProjectConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/MyAbpZeroProject")
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<MyAbpZeroProjectNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
