using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace Abp.Samples.Blog
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpSampleBlogCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}