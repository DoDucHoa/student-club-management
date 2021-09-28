using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class TaskTypeService
    {
        private readonly ITaskTypeRepository _repository;

        public TaskTypeService(ITaskTypeRepository repository)
        {
            _repository = repository;
        }

        public List<TaskType> Get() => _repository.GetAll().ToList();

        public TaskType GetById(string id) => _repository.GetAll().Where(x => x.Id.Equals(id)).FirstOrDefault();

        public void Create(TaskType _object)
        {
            _repository.Add(_object);
            _repository.SaveDbChange();
        }
        public void Delete(TaskType _object)
        {
            _repository.Remove(_object);
            _repository.SaveDbChange();
        }

        public void Update(TaskType _object)
        {
            _repository.Update(_object);
            _repository.SaveDbChange();
        }
    }
}
