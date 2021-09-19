using ServiceEmail.BLL.ModelBLL.User;
using ServiceEmail.UI.Models.TaskModel;
using ServiceEmail.UI.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using AutoMapper;
using ServiceEmail.BLL.ModelBLL.UserBLL;

namespace ServiceEmail.UI.Mapping
{
    public static class MapperProfileUser
    {
        public static UserBLL MapToBLLUser(this User user)
        {
             var mapper = new MapperConfiguration(cfg => {

                 cfg.CreateMap<Role, RoleBLL>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                 cfg.CreateMap<TaskInfo, TaskInfoBLL>()
                    .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                    .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                    .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                    .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                    .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                    .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime))
                    .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts))
                    .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                    .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                 cfg.CreateMap<User, UserBLL>().
                   ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                   ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                   ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                   ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                   ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                   ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                   ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

             }).CreateMapper();

            var userBLL = mapper.Map<User, UserBLL>(user);

            return userBLL;          
        }

        public static User MapToUser(this UserBLL userBLL)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleBLL, Role>().
                   ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                   ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfoBLL, TaskInfo>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserBLL, User>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

            }).CreateMapper();

            var user = mapper.Map<UserBLL, User>(userBLL);

            return user;
        }

        public static IEnumerable<User> MapToEnumerableUsers(this IEnumerable<UserBLL> usersBLL)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<RoleBLL, Role>().
                   ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                   ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfoBLL, TaskInfo>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserBLL, User>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

            }).CreateMapper();

            var users = mapper.Map<IEnumerable<UserBLL>, IEnumerable<User>>(usersBLL);

            foreach (var t in users)
            {
                foreach (var r in t.TaskInfo)
                {
                    r.UserId = t.Id;
                }
            }

            return users;
        }

        public static IEnumerable<UserBLL> MapToEnumerableUsersBLL(this IEnumerable<User> users)
        {
            var mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<Role, RoleBLL>().
               ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
               ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfo, TaskInfoBLL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<User, UserBLL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

            }).CreateMapper();

            var usersBL = mapper.Map<IEnumerable<User>, IEnumerable<UserBLL>>(users);

            return usersBL;
        }
    }
}
