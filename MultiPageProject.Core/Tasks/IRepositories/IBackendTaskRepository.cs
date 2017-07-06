using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiPageProject.Tasks.IRepositories {
    public interface IBackendTaskRepository : IRepository<MyTasks.Task> {
        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId">用户Id</param>
        /// <returns>任务列表</returns>
        List<MyTasks.Task> GetTaskByAssignedPersonId(long personId);

        List<MyTasks.Task> GetCompleteTasks();
    }
}
