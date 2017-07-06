using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MultiPageProject.EntityFramework;

namespace MultiPageProject.Migrator
{
    [DependsOn(typeof(MultiPageProjectDataModule))]
    public class MultiPageProjectMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MultiPageProjectDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}