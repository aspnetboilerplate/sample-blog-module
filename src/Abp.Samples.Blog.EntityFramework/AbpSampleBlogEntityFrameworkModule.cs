using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace Abp.Samples.Blog.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(AbpSampleBlogCoreModule))]
    public class AbpSampleBlogEntityFrameworkModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
