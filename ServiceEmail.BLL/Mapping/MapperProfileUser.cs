using AutoMapper;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.User;
using ServiceEmail.DAL.Models.TaskInfoDAL;
using ServiceEmail.DAL.Models.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.Mapping
{
    public static class MapperProfileUser
    {
        public static UserBLL MapToBLLUser(this UserDAL userDAL)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskInfoDAL, TaskInfoBLL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserDAL, UserBLL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.taskInfo, opt => opt.MapFrom(c => c.taskInfo));

            }).CreateMapper();

            var userBLL = mapper.Map<UserDAL, UserBLL>(userDAL);

            return userBLL;
        }

        public static UserDAL MapToUserDAL(this UserBLL userBLL)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<TaskInfoBLL, TaskInfoDAL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserBLL, UserDAL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.taskInfo, opt => opt.MapFrom(c => c.taskInfo));

            }).CreateMapper();

            var userDAL = mapper.Map<UserBLL, UserDAL>(userBLL);

            return userDAL;
        }
    }
}
