using ServiceEmail.BLL.Interfaces;
using ServiceEmail.BLL.Mapping;
using ServiceEmail.BLL.ModelBLL.TaskInfoBLL;
using ServiceEmail.DAL.Interfaces;

namespace ServiceEmail.BLL.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }
        public void Delete(TaskInfoBLL task) => _repository.Delete(task.MapToDALTask());
        public void Create(TaskInfoBLL task) => _repository.Create(task.MapToDALTask());
        public void Update(TaskInfoBLL task) => _repository.Update(task.MapToDALTask());
    }
}
