using System.Data.Entity.Migrations;
using MyAbpZeroProject.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MyAbpZeroProject.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyAbpZeroProject.EntityFramework.MyAbpZeroProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyAbpZeroProject";
        }

        protected override void Seed(MyAbpZeroProject.EntityFramework.MyAbpZeroProjectDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}
