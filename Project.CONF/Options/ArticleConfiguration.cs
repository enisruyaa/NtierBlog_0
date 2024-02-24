using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    public class ArticleConfiguration : BaseConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            ToTable("Makaleler");
        }
    }
}
