using System.Collections.Generic;
using ServiceEmail.BLL.ModelBLL.UserBLL;

namespace ServiceEmail.BLL.ModelBLL.User
{
    public class UserBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleBLL Role { get; set; }
        public List<TaskInfoBLL.TaskInfoBLL> TaskInfo { get; set; }
    }
}
