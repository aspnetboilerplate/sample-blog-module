using Abp.Modules;
using Abp.TestBase;
using SampleApplication;

namespace Abp.Samples.Blog.Tests
{
    [DependsOn(typeof(SampleApplicationModule), typeof(AbpTestBaseModule))]
    public class BlogTestModule : AbpModule
    {
        
    }
}