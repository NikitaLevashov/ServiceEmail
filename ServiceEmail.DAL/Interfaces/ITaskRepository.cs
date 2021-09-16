using ServiceEmail.DAL.Models.TaskInfoDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.DAL.Interfaces
{
    public interface ITaskRepository
    {
        void Create(TaskInfoDAL item);
        void Update(TaskInfoDAL item);
        void Delete(TaskInfoDAL id);
    }
}
