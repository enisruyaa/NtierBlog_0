using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITES.Models
{
    public class Author : BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        // Ralational Properties

        public virtual AuthorProfile AuthorProfile { get; set; }

        public virtual List<Article> Articles { get; set; }
    }
}
