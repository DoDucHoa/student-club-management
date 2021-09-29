using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
using System.Linq.Expressions;
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
using System.Text;
using System.Threading.Tasks;

namespace FClub.Data.Interface
{
<<<<<<< HEAD
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);
        public void Update(T _object);
        public IEnumerable<T> GetAll();
        public T GetById(int Id);
        public void Delete(T _object);
=======
    public interface IRepository<T> where T : class
    {
        //Get theo Id
        T Get(string id);

        T Get(int id);
        //Get theo dạng list có sort, filter và includeProperties
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //Get thằng đầu tiên thấy có filter, incldueProperties
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );
        void Add(T entity);
        //Remove theo Id
        void Remove(String id);
        void Remove(int id);
        //Update theo entity
        void Update(T entity);
        //Remove theo entity
        void Remove(T entity);
        //Remove một chuỗi entity
        void RemoveRange(IEnumerable<T> entity);
        bool SaveDbChange();
>>>>>>> 06a398bc00f9aa0ce962b0e5e1661707d5b1dde6
    }
}
