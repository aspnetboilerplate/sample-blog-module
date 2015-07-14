using System.Reflection;
using Abp.Modules;
using Abp.Samples.Blog.EntityFramework;
using Abp.Zero.EntityFramework;

namespace MyAbpZeroProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(MyAbpZeroProjectCoreModule), typeof(AbpSampleBlogEntityFrameworkModule))]
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
