using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public List<Task> Get() => _repository.GetAll().ToList();

        public Task GetById(int id) => _repository.GetAll().Where(x => x.Id == id).FirstOrDefault();

        public void Create(Task _object)
        {
            _repository.Add(_object);
            _repository.SaveDbChange();
        }
        public void Delete(Task _object)
        {
            _repository.Remove(_object);
            _repository.SaveDbChange();
        }

        public void Update(Task _object)
        {
            _repository.Update(_object);
            _repository.SaveDbChange();
        }
    }
}
