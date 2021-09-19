using AutoMapper;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.User;
using ServiceEmail.BLL.ModelBLL.UserBLL;
using ServiceEmail.DAL.Models.TaskInfoDAL;
using ServiceEmail.DAL.Models.UserDAL;
using System;
using System.Collections.Generic;

namespace ServiceEmail.BLL.Mapping
{
    public static class MapperProfileUser
    {
        public static UserBLL MapToBLLUser(this UserDL userDAL)
        {
            var mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<RoleDL, RoleBLL>().
                 ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                 ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfoDAL, TaskInfoBLL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => Convert.ToDateTime(s.LastDateTime)))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => Convert.ToDateTime(s.MomentTaskStarts)))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserDL, UserBLL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

            }).CreateMapper();

            var userBLL = mapper.Map<UserDL, UserBLL>(userDAL);
            if (userBLL == null)
                return null;

            foreach (var r in userBLL.TaskInfo)
                r.UserId = userDAL.Id;

            return userBLL;
        }

        public static UserDL MapToUserDAL(this UserBLL userBLL)
        {
            var mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<RoleBLL, RoleDL>().
                 ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                 ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfoBLL, TaskInfoDAL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime.ToString()))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts.ToString()))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserBLL, UserDL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

            }).CreateMapper();

            var userDAL = mapper.Map<UserBLL, UserDL>(userBLL);

            foreach (var r in userDAL.TaskInfo)
                r.UserId = userBLL.Id;

            return userDAL;
        }

        public static IEnumerable<UserDL> MapToEnumerableUsersDAL(this IEnumerable<UserBLL> userBLL)
        {
            var mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<RoleBLL, RoleDL>().
                 ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                 ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfoBLL, TaskInfoDAL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => s.LastDateTime.ToString()))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => s.MomentTaskStarts.ToString()))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserBLL, UserDL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));

            }).CreateMapper();

            var usersDAL = mapper.Map<IEnumerable<UserBLL>, IEnumerable<UserDL>>(userBLL);

            return usersDAL;
        }

        public static IEnumerable<UserBLL> MapToEnumerableBLLUsers(this IEnumerable<UserDL> usersDAL)
        {
            var mapper = new MapperConfiguration(cfg => {

                cfg.CreateMap<RoleDL, RoleBLL>().
                 ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                 ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name));

                cfg.CreateMap<TaskInfoDAL, TaskInfoBLL>()
                   .ForMember(d => d.AppSettings, d => d.MapFrom(s => s.AppSettings))
                   .ForMember(d => d.DataOfTask, d => d.MapFrom(s => s.DataOfTask))
                   .ForMember(d => d.Description, d => d.MapFrom(s => s.Description))
                   .ForMember(d => d.FreeApi, d => d.MapFrom(s => s.FreeApi))
                   .ForMember(d => d.Id, d => d.MapFrom(s => s.Id))
                   .ForMember(d => d.LastDateTime, d => d.MapFrom(s => Convert.ToDateTime(s.LastDateTime)))
                   .ForMember(d => d.MomentTaskStarts, d => d.MapFrom(s => Convert.ToDateTime(s.MomentTaskStarts)))
                   .ForMember(d => d.Name, d => d.MapFrom(s => s.Name))
                   .ForMember(d => d.PeriodicityTask, d => d.MapFrom(s => s.PeriodicityTask));

                cfg.CreateMap<UserDL, UserBLL>().
                  ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id)).
                  ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name)).
                  ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName)).
                  ForMember(dest => dest.Password, opt => opt.MapFrom(c => c.Password)).
                  ForMember(dest => dest.Email, opt => opt.MapFrom(c => c.Email)).
                  ForMember(dest => dest.TaskInfo, opt => opt.MapFrom(c => c.TaskInfo)).
                  ForMember(dest => dest.Role, opt => opt.MapFrom(c => c.Role));               

            }).CreateMapper();

            var userBLLs = mapper.Map<IEnumerable<UserDL>, IEnumerable<UserBLL>>(usersDAL);

            foreach(var t in userBLLs)
            {
                foreach(var r in t.TaskInfo)
                {
                    r.UserId = t.Id;
                }
            }
            
            return userBLLs;
        }
    }
}
