using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.User;
using System;
using System.Collections.Generic;

namespace ServiceEmail.BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserBLL> GetAll();
        void Create(UserBLL item);
        public UserBLL GetUser(UserBLL user);
    }
}
