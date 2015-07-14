using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MyAbpZeroProject.EntityFramework;

namespace MyAbpZeroProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(MyAbpZeroProjectCoreModule))]
    public class MyAbpZeroProjectDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
