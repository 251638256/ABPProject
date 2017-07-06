using MultiPageProject.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MultiPageProject.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MultiPageProjectDbContext _context;

        public InitialHostDbBuilder(MultiPageProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
