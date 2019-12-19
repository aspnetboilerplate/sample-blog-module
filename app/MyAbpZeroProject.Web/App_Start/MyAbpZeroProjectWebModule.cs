using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Samples.Blog.EntityFramework;
using Abp.Samples.Blog.Web;
using Abp.Web.Mvc;

namespace MyAbpZeroProject.Web
{
    [DependsOn(
        typeof(MyAbpZeroProjectDataModule),
        typeof(MyAbpZeroProjectApplicationModule),
        typeof(MyAbpZeroProjectWebApiModule),
        typeof(AbpSampleBlogWebModule),
        typeof(AbpSampleBlogEntityFrameworkModule),
        typeof(AbpWebMvcModule)
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
                new DictionaryBasedLocalizationSource(
                    MyAbpZeroProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyAbpZeroProjectWebModule).GetAssembly(),
                        HttpContext.Current.Server.MapPath("~/Localization/MyAbpZeroProject")
                    )
                ));

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
