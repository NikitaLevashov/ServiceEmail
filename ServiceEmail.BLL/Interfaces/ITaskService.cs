using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;

namespace ServiceEmail.BLL.Interfaces
{
    public interface ITaskService
    {
        void Create(TaskInfoBLL item);
        void Update(TaskInfoBLL item);
        void Delete(TaskInfoBLL task);
    }
}
