using Project.BLL.DesignPatterns.GenericRepository.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.ContextClass;
using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.EFBaseRep
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MyContext _db; //Özelleştirmek istediğimiz farklı bir repository'de kullanılabilmek için protected yaptık.

        public BaseRepository()
        {
            _db = DBTool.DbInstance; // Database Görevi yapcağı için DbInstance'i alınması gerekiyor DbInstance almazsak malsef yapamayız.
        }

        protected void Save()
        {
            _db.SaveChanges();
        }

        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
            _db.Set<T>().AddRange(list);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = ENTITES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach(T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public T Find(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public T FirstOrDefult(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != ENTITES.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
           return _db.Set<T>().ToList();
        }

        public List<T> GetDatas(int count)
        {
            return _db.Set<T>().Take(count).ToList();
        }

        public List<T> GetFirstDatas(int count)
        {
            return _db.Set<T>().OrderBy(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetLastDatas(int count)
        {
            return _db.Set<T>().OrderByDescending(x => x.CreatedDate).Take(count).ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITES.Enums.DataStatus.Update);
        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == ENTITES.Enums.DataStatus.Deleted);
        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public List<MyModel> SelectVia<MyModel>(Expression<Func<T, MyModel>> exp) where MyModel : class
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        public void Update(T item)
        {
            item.Status = ENTITES.Enums.DataStatus.Update;
            item.ModifiedDate = DateTime.Now;
            T orginaldata = Find(item.ID);
            _db.Entry(orginaldata).CurrentValues.SetValues(item);
            Save();
        }

        public void UpdateRange(List<T> list)
        {
            foreach(T item in list) Update(item);
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }
    }
}
