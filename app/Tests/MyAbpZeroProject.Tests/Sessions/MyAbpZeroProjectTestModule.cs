using Abp.Modules;
using Abp.TestBase;

namespace MyAbpZeroProject.Tests.Sessions
{
    [DependsOn(
         typeof(AbpTestBaseModule),
         typeof(MyAbpZeroProjectApplicationModule),
         typeof(MyAbpZeroProjectDataModule)
     )]
    public class MyAbpZeroProjectTestModule : AbpModule
    {
        
    }
}