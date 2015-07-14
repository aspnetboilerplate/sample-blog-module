using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Abp.Collections;
using Abp.Modules;
using Abp.Samples.Blog.EntityFramework;
using Abp.Samples.Blog.Tests.Data;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using EntityFramework.DynamicFilters;

namespace Abp.Samples.Blog.Tests
{
    public abstract class SampleBlogTestBase : AbpIntegratedTestBase
    {
        protected SampleBlogTestBase()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );

            //Seed initial data
            UsingDbContext(context => new DefaultTenantRoleAndUserBuilder(context).Build());
            UsingDbContext(context => new BlogTestDataBuilder(context).Build());
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);

            //Adding testing modules. Depended modules of these modules are automatically added.
            modules.Add<AbpSampleBlogApplicationModule>();
            modules.Add<AbpSampleBlogEntityFrameworkModule>();
        }

        public void UsingDbContext(Action<SampleBlogDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SampleBlogDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<SampleBlogDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SampleBlogDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
