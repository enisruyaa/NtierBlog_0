using Project.BLL.DesignPatterns.GenericRepository.EFBaseRep;
using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    public class CategoryRepository : BaseRepository<Category>
    {
        /// <summary>
        /// Bu metod  seçilen kaatgorinin makalelerine 2 adet makale ekler ve Güncellenmiş olan makaleleri Listeleyecek 
        /// </summary>
        /// <param name="item"></param>
        public void SpecialAdd(Category item)
        {
            Article a = new Article
            {
                Title = "Korku",            
            };

            Article b = new Article
            {
                Title = "Macera"
            };
            item.Articles.Add(a);
            item.Articles.Add(b);
            _db.Categories.Add(item);
            Save();
        }
    }
}
