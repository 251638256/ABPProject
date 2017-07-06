using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using MultiPageProject.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace MultiPageProject.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MultiPageProject.EntityFramework.MultiPageProjectDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "MultiPageProject";
        }

        protected override void Seed(MultiPageProject.EntityFramework.MultiPageProjectDbContext context)
        {
            context.DisableAllFilters();

            new DefaultTestDataForTask(context).Create();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
