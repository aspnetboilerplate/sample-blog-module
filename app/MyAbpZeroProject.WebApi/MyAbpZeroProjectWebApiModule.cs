using System.Reflection;
using Abp.Application.Services;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;

namespace MyAbpZeroProject
{
    [DependsOn(typeof(AbpWebApiModule), typeof(MyAbpZeroProjectApplicationModule))]
    public class MyAbpZeroProjectWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(MyAbpZeroProjectApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
