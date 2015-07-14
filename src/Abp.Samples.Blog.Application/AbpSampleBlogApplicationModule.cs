using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Abp.Samples.Blog
{
    [DependsOn(typeof(AbpSampleBlogCoreModule), typeof(AbpAutoMapperModule))]
    public class AbpSampleBlogApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}