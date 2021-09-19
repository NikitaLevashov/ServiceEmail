using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.Mapping;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.BLL.ModelBLL.User;
using ServiceEmail.DAL.Interfaces;
using System.Collections.Generic;

namespace ServiceEmail.BLL.Service
{
    public class UserService : IUserService
    {
        IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public void Create(UserBLL user) => _repository.Create(user.MapToUserDAL());
        public IEnumerable<UserBLL> GetAll()
            =>  _repository.GetAll().MapToEnumerableBLLUsers();
        public UserBLL GetUser(UserBLL user) => _repository.GetUser(user.MapToUserDAL()).MapToBLLUser();
    }
}
