using Abp.Samples.Blog.EntityFramework.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace Abp.Samples.Blog.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Abp.Samples.Blog.EntityFramework.SampleBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpSampleBlogModule";
        }

        protected override void Seed(SampleBlogDbContext context)
        {
            context.DisableAllFilters();
            new BlogTestDataBuilder(context).Build();
        }
    }
}
