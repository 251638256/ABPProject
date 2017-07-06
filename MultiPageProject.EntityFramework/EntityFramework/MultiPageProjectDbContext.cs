using System.Data.Common;
using Abp.Zero.EntityFramework;
using MultiPageProject.Authorization.Roles;
using MultiPageProject.MultiTenancy;
using MultiPageProject.Users;
using System.Data.Entity;
using MultiPageProject.Tasks;
using System.Data.Entity.Migrations;

namespace MultiPageProject.EntityFramework
{


    public class MultiPageProjectDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public IDbSet<MyTasks.Task> Tasks { get; set; }
        public IDbSet<MyTasks.Customer> Customers { get; set; }

        public MultiPageProjectDbContext()
            : base("Default")
        {
            
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MultiPageProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MultiPageProjectDbContext since ABP automatically handles it.
         */
        public MultiPageProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MultiPageProjectDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MultiPageProjectDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            
            base.OnModelCreating(modelBuilder);
        }

    }

}
