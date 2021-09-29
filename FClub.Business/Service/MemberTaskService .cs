using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FClub.Business.Service
{
    public class MemberTaskService
    {
        private readonly IMemberTaskRepository _memberTaskRepository;

        public MemberTaskService(IMemberTaskRepository memberTaskRepository)
        {
            _memberTaskRepository = memberTaskRepository;
        }


        public void Add(MemberTask memberTask)
        {
            _memberTaskRepository.Add(memberTask);
            _memberTaskRepository.SaveDbChange();
           
        }

        public void Update(MemberTask memberTask)
        {
                _memberTaskRepository.Update(memberTask);
                _memberTaskRepository.SaveDbChange();
        }

        public bool DeleteById(int id)
        {
            var objFromDb = _memberTaskRepository.Get(id);
            if(objFromDb == null)
            {
                return false;
            }
            _memberTaskRepository.Remove(id);
            _memberTaskRepository.SaveDbChange();
            return true;
        }

        public MemberTask GetMemberTaskById(int id)
        {
            var memberTask = _memberTaskRepository.Get(id);
            return memberTask;
        }

        public IEnumerable<MemberTask> GetList()
        {
            var memberTaskList = _memberTaskRepository.GetAll();
            return memberTaskList;
        }
    }
}
