using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.Samples.Blog.Posts;
using Abp.Samples.Blog.Web.Navigation;
using Abp.Web.Mvc;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace Abp.Samples.Blog.Web
{
    [DependsOn(typeof(AbpSampleBlogApplicationModule), typeof(AbpWebApiModule), typeof(AbpWebMvcModule))]
    public class AbpSampleBlogWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<BlogNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof (PostAppService).Assembly, "blog")
                .Build();
        }
    }
}
