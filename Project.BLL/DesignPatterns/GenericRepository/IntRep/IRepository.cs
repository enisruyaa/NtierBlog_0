using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T : BaseEntity
    {
        // List Commands

        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetModifieds();
        List<T> GetAll();

        //ModifyCommmands

        void Add(T item);
        void AddRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        // Linq Commands

        List<T> Where(Expression<Func<T, bool>> exp);
        T FirstOrDefult(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        List<MyModel> SelectVia<MyModel>(Expression<Func<T, MyModel>> exp) where MyModel : class;

        //Find 
        T Find(int id);

        //Get Last Datas
        List<T> GetLastDatas(int count);

        //Get First Datas 
        List<T> GetFirstDatas(int count);

        //GetDatas
        List<T> GetDatas(int count);

    }
}
