using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITES.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public string Disciption { get; set; }

        public int? ArticleID { get; set; }

        // Relational Properties

        public virtual List<Article> Articles { get; set; }


    }
}
