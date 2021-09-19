using ServiceEmail.DAL.Models.TaskInfoDAL;
using ServiceEmail.DAL.Models.UserDAL;
using System.Collections.Generic;

namespace ServiceEmail.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserDL> GetAll();
        void Create(UserDL item);
        UserDL GetUser(UserDL userDAL);
    }
}
