using ServiceEmail.DAL.Models.TaskInfoDAL;
using ServiceEmail.DAL.Models.UserDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserDL> GetAll();
        //UserDAL GetById(int id);
        void Create(UserDL item);
        //void Update(UserDAL item);
        //void Delete(TaskInfoDAL id);
    }
}
