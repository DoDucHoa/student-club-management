using FClub.Data.Database;
using FClub.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FClub.Business.Service
{
    public class MemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public List<Member> Get() => _repository.GetAll().ToList();

        public Member GetById(int id) => _repository.GetAll().Where(x => x.Id == id).FirstOrDefault();

        public void Create(Member _object)
        {
            _repository.Add(_object);
            _repository.SaveDbChange();
        }
        public void Delete(Member _object)
        {
            _repository.Remove(_object);
            _repository.SaveDbChange();
        }

        public void Update(Member _object)
        {
            _repository.Update(_object);
            _repository.SaveDbChange();
        }
    }
}
