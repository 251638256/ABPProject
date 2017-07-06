using Abp.EntityFramework;
using MultiPageProject.EntityFramework;
using MultiPageProject.EntityFramework.Repositories;
using MultiPageProject.Tasks.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPageProject.MyTasks;
using Abp.Domain.Uow;

namespace MultiPageProject.MyTask.Repositories {
    public class BackendTaskRepository : MultiPageProjectRepositoryBase<MultiPageProject.MyTasks.Task>, IBackendTaskRepository {
        public BackendTaskRepository(IDbContextProvider<MultiPageProjectDbContext> dbContextProvider) : base(dbContextProvider) {
        }

        /// <summary>
        /// 获取已完成的任务
        /// </summary>
        /// <returns></returns>
        public List<MyTasks.Task> GetCompleteTasks() {
            return GetAll().Where(c => c.State == TaskState.Completed).ToList();
        }

        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId">用户Id</param>
        /// <returns>任务列表</returns>
        [UnitOfWork(IsDisabled = false)]
        public List<MyTasks.Task> GetTaskByAssignedPersonId(long personId) {
            var query = GetAll();

            if (personId > 0) {
                query = query.Where(t => t.AssignedPersonId == personId);
            }

            return query.ToList();
        }

        public MyTasks.Task GetSingle() {
            var query = GetAll(); // 
            var queryableWithCondations = GetAll().Where(c => c.State == TaskState.Open);
            var list = GetAllList(c => c.State == TaskState.Open); // 不会有延迟查询了??
            return Load(0);
        }
    }
}
