using MultiPageProject.DTOMappping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MultiPageProject.MyTask.DTOs;

namespace MultiPageProject.MyTask {
    public class TaskDtoMapping : IDtoMapping {
        public void CreateMapping(IMapperConfigurationExpression mapperConfig) {
            //定义单向映射
            mapperConfig.CreateMap<CreateTaskInput, Task>();
            mapperConfig.CreateMap<UpdateTaskInput, Task>();
            mapperConfig.CreateMap<TaskDto, UpdateTaskInput>();

            //自定义映射
            var taskDtoMapper = mapperConfig.CreateMap<MyTasks.Task, TaskDto>();
            taskDtoMapper.ForMember(dto => dto.AssignedPersonName, map => map.MapFrom(m => m.AssignedPerson.FullName));
        }
    }
}
