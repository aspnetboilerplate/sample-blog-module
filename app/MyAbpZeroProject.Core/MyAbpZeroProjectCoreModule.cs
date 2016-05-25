using System.Reflection;
using Abp.Modules;
using Abp.Samples.Blog;
using Abp.Zero;
using Abp.Zero.Configuration;
using MyAbpZeroProject.Authorization.Roles;
using MyAbpZeroProject.MultiTenancy;
using MyAbpZeroProject.Users;

namespace MyAbpZeroProject
{
    [DependsOn(
        typeof(AbpZeroCoreModule),
        typeof(AbpSampleBlogCoreModule)
        )]
    public class MyAbpZeroProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Remove the following line to disable multi-tenancy.
            //Configuration.MultiTenancy.IsEnabled = true;

            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
