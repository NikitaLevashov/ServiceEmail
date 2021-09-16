using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.DAL.Models.UserDAL
{
    public class RoleDL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDL> Users { get; set; }
    }
}
