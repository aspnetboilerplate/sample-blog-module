using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Samples.Blog;

namespace MyAbpZeroProject
{
    [DependsOn(
        typeof(MyAbpZeroProjectCoreModule), 
        typeof(AbpSampleBlogApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class MyAbpZeroProjectApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
