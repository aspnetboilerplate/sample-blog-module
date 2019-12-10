using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace MyAbpZeroProject
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MyAbpZeroProjectApplicationModule))]
    public class MyAbpZeroProjectWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MyAbpZeroProjectApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
