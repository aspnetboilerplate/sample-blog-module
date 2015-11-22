using Abp.Modules;
using SampleApplication;

namespace Abp.Samples.Blog.Tests
{
    [DependsOn(typeof(SampleApplicationModule))]
    public class BlogTestModule : AbpModule
    {
        
    }
}