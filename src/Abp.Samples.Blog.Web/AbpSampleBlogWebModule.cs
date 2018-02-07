using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Samples.Blog.Posts;
using Abp.Samples.Blog.Web.Navigation;
using Abp.Web.Mvc;
using Abp.WebApi;

namespace Abp.Samples.Blog.Web
{
    [DependsOn(
        typeof(AbpSampleBlogApplicationModule), 
        typeof(AbpWebApiModule), 
        typeof(AbpWebMvcModule))
    ]
    public class AbpSampleBlogWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<BlogNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(PostAppService).Assembly, "blog")
                .Build();
        }
    }
}
