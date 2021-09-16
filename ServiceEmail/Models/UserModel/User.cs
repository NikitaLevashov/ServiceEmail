using ServiceEmail.UI.Models.TaskModel;
using System.Collections.Generic;

namespace ServiceEmail.UI.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TaskInfo> taskInfo { get; set; }
        public Role Role { get; set; }
        public int? RoleId { get; set; }
    }
}
