using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceEmail.BLL.Interfaces
{
    public interface IApiInfo
    {
        public string GetApiInfo(TaskInfoBLL task);
    }
}
