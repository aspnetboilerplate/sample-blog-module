using System.Reflection;
using Abp.Modules;

namespace Abp.Samples.Blog
{
    [DependsOn(typeof(AbpSampleBlogCoreModule))]
    public class AbpSampleBlogApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}