using Phram.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.Repository.GenericRepository
{
    public class GRepository<T> where T : class
    {
        protected PharmContext BuildSession = null;
        protected DbSet<T> DbObject { get; set; }
        public GRepository(bool lazy)
        {
            BuildSession = new PharmContext();
            DbObject = BuildSession.Set<T>();
            if (lazy)
                BuildSession.Configuration.LazyLoadingEnabled = true;
            else
                BuildSession.Configuration.LazyLoadingEnabled = false;
        }
        public IList<T> GetAll()
        {
            return DbObject.ToList<T>();
        }
        public T GetById(int Id)
        {
            return DbObject.Find(Id);
        }
        public T FindWithClause(Func<T, bool> predicate)
        {
            var _result = DbObject.Where(predicate).FirstOrDefault();
            return _result;
        }
        public void SaveChanges()
        {
            BuildSession.SaveChanges();
        }
        public void Add(T entity)
        {
            DbObject.Add(entity);
        }
        public List<T> GetByPagination(int pageIndex, int pageSize)
        {
            var _list = new List<T>();
            _list = DbObject.ToList<T>().Skip(pageIndex * pageSize).Take(pageSize).ToList<T>();
            return _list;
        }
    }
}
