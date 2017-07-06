using MultiPageProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPageProject.Migrations.SeedData {
    public class DefaultTestDataForTask {
        private readonly MultiPageProjectDbContext _context;

        private static readonly List<MultiPageProject.MyTasks.Task> _tasks;

        public DefaultTestDataForTask(MultiPageProjectDbContext context) {
            _context = context;
        }

        static DefaultTestDataForTask() {
            _tasks = new List<MultiPageProject.MyTasks.Task>()
            {
              new MyTasks.Task("Learning ABP deom", "Learning how to use abp framework to build a MPA application."),
              new MyTasks.Task("Make Lunch", "Cook 2 dishs")
          };
        }

        public void Create() {
            foreach (var task in _tasks) {
                if (_context.Tasks.FirstOrDefault(t => t.Title == task.Title) == null) {
                    _context.Tasks.Add(task);
                }
                _context.SaveChanges();
            }
        }

    }
}
