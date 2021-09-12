using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceEmail.BLL.ModelBLL;

namespace ServiceEmail.BLL.ModelBLL.User
{
    public class UserBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TaskInfoBLL.TaskInfoBLL> taskInfo { get; set; }
    }
}
