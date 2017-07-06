using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using MultiPageProject.EntityFramework;

namespace MultiPageProject
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(MultiPageProjectCoreModule))]
    public class MultiPageProjectDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MultiPageProjectDbContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MultiPageProjectDbContext, Migrations.Configuration>());
            
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
