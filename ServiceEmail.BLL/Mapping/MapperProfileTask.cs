using AutoMapper;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.DAL.Models.TaskInfoDAL;
using System;

namespace ServiceEmail.BLL.Mapping
{
    public static class MapperProfileTask
    {
        public static TaskInfoDAL MapToDALTask(this TaskInfoBLL taskBLL)
        {
            var mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<TaskInfoBLL, TaskInfoDAL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => Convert.ToDateTime(s.LastDateTime)))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => Convert.ToDateTime(s.MomentTaskStarts)))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask))
                   .ForMember(d => d.UserId, d => d.MapFrom(s => s.UserId));

            }).CreateMapper();

            var taskDAL = mapper.Map<TaskInfoBLL, TaskInfoDAL>(taskBLL);

            return taskDAL;
        }
    }
}
