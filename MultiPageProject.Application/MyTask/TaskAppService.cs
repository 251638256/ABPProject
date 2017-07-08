using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPageProject.MyTask.DTOs;
using Abp.Domain.Repositories;
using Abp.Timing;
using Abp.AutoMapper;
using AutoMapper;
using MultiPageProject.Tasks.IRepositories;
using Abp.Authorization;
using Microsoft.AspNet.Identity;
using MultiPageProject.Users;
using MultiPageProject.Users.Dto;

namespace MultiPageProject.MyTask {
    [AbpAuthorize("Administration")]
    public class TaskAppService : MultiPageProjectAppServiceBase, ITaskAppService {

        private readonly IRepository<MyTasks.Task> _taskRepository;
        private readonly IBackendTaskRepository _myTaskRepository;
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public TaskAppService(IRepository<MyTasks.Task> taskRepository, IBackendTaskRepository myTaskRepository,
            UserManager userManager, IPermissionManager permissionManager) {
            _taskRepository = taskRepository;
            _myTaskRepository = myTaskRepository;
            _userManager = userManager;
            _permissionManager = permissionManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input) {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        public GetTasksOutput GetTasks(GetTasksInput input) {
            var query = _taskRepository.GetAll();

            if (input.AssignedPersonId.HasValue) {
                query = query.Where(t => t.AssignedPersonId == input.AssignedPersonId.Value);
            }

            if (input.State.HasValue) {
                query = query.Where(t => t.State == input.State.Value);
            }

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput {
                Tasks = Mapper.Map<List<TaskDto>>(query.ToList())
            };
        }

        public async Task<TaskDto> GetTaskByIdAsync(int taskId) {
            //Called specific GetAllWithPeople method of task repository.
            var task = await _taskRepository.GetAsync(taskId);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return task.MapTo<TaskDto>();
        }

        public TaskDto GetTaskById(int taskId) {
            var task = _taskRepository.Get(taskId);

            return task.MapTo<TaskDto>();
        }

        public void UpdateTask(UpdateTaskInput input) {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a task for input: " + input);

            //Retrieving a task entity with given id using standard Get method of repositories.
            var task = _taskRepository.Get(input.Id);

            //Updating changed properties of the retrieved task entity.

            if (input.State.HasValue) {
                task.Title = input.Title;
                task.Description = input.Description;
                task.State = input.State.Value;
            }

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }

        public int CreateTask(CreateTaskInput input) {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            //Creating a new Task entity with given input's properties
            var task = new MyTasks.Task {
                Description = input.Description,
                Title = input.Title,
                State = input.State,
                CreationTime = Clock.Now
            };

            //Saving entity with standard Insert method of repositories.
            return _taskRepository.InsertAndGetId(task);
        }

        public void DeleteTask(int taskId) {
            var task = _taskRepository.Get(taskId);
            if (task != null) {
                _taskRepository.Delete(task);
            }
        }

        public List<TaskDto> GetAll() {
            // 通用的回话管理(不是浏览器的Session) 存储当前的登录用户,租户以及其他信息
            var userid = AbpSession.UserId.Value;

            // 通用的设置管理 针对程序,租户,用户三个级别
            var waiter = SettingManager.GetSettingValueAsync("IsReadOnly").GetAwaiter();
            waiter.OnCompleted(() => {
                // 异步执行完成的回调方法
            });

            return _taskRepository.GetAll().MapTo<List<TaskDto>>();
        }

        public List<TaskDto> GetcompletedTasks() {
            var completed = _myTaskRepository.GetCompleteTasks();
            return completed.MapTo<List<TaskDto>>();
        }
    }
}
