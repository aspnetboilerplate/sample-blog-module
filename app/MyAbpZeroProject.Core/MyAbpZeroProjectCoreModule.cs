using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace MyAbpZeroProject
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class MyAbpZeroProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = true;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
