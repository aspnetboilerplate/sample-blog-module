using System;
using System.Data.Common;
using Abp.Collections;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Samples.Blog.Auth;
using Abp.Samples.Blog.EntityFramework;
using Abp.Samples.Blog.EntityFramework.Migrations.SeedData;
using Abp.Samples.Blog.Tests.Data;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using Effort;
using EntityFramework.DynamicFilters;

namespace Abp.Samples.Blog.Tests
{
    public abstract class SampleBlogTestBase : AbpIntegratedTestBase
    {
        protected SampleBlogTestBase()
        {
            //Seed initial data
            UsingDbContext(context => new DefaultTenantRoleAndUserBuilder(context).Build());
            UsingDbContext(context => new BlogTestDataBuilder(context).Build());
        }

        protected override void PreInitialize()
        {
            base.PreInitialize();

            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
                );
        }

        protected override void AddModules(ITypeList<AbpModule> modules)
        {
            base.AddModules(modules);

            //Adding testing modules. Depended modules of these modules are automatically added.
            modules.Add<BlogTestModule>();
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
