using Abp.Web.Mvc.Authorization;
using Abp.Web.Mvc.Controllers;
using MultiPageProject.MyTask;
using MultiPageProject.MyTask.DTOs;
using MultiPageProject.Users;
using MultiPageProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiPageProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class TasksController : AbpController {

        private readonly ITaskAppService _taskAppService;
        private readonly IUserAppService _userAppService;

        public TasksController(ITaskAppService taskAppService, IUserAppService userAppService) {
            _taskAppService = taskAppService;
            _userAppService = userAppService;
        }

        // GET: Tasks
        public ActionResult Index(GetTasksInput input)
        {
            var output = _taskAppService.GetTasks(input);

            var model = new IndexViewModel(output.Tasks) {
                SelectedTaskState = input.State

            };
            return View(model);
        }

        // GET : Create
        [ChildActionOnly]
        public PartialViewResult Create() {
            var userList = _userAppService.GetUsers2();
            ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name");
            return PartialView("_CreateTask");
        }

        // POST : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTaskInput task) {
            var id = _taskAppService.CreateTask(task);

            var input = new GetTasksInput();
            var output = _taskAppService.GetTasks(input);

            return PartialView("_List", output.Tasks);
        }

        public PartialViewResult Edit(int id) {
            var task = _taskAppService.GetTaskById(id);

            var updateTaskDto = AutoMapper.Mapper.Map<UpdateTaskInput>(task);

            var userList = _userAppService.GetUsers2();
            ViewBag.AssignedPersonId = new SelectList(userList.Items , "Id", "Name", updateTaskDto.AssignedPersonId);

            return PartialView("_EditTask", updateTaskDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateTaskInput updateTaskDto) {
            _taskAppService.UpdateTask(updateTaskDto);

            var input = new GetTasksInput();
            var output = _taskAppService.GetTasks(input);

            return PartialView("_List", output.Tasks);
        }

        public PartialViewResult GetList(GetTasksInput input) {
            var output = _taskAppService.GetTasks(input);
            return PartialView("_List", output.Tasks);
        }

        public ActionResult Json() {

            return View();
        }

    }
}