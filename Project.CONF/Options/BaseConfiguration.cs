﻿using Project.ENTITES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CONF.Options
{
    public abstract class BaseConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseConfiguration()      
        {
            Property(x => x.CreatedDate).HasColumnName("OluşturulmaTarihi");
            Property(x => x.ModifiedDate).HasColumnName("GüncellenmeTarihi");
            Property(x => x.DeletedDate).HasColumnName("SiilinmeTarihi");
            Property(x => x.Status).HasColumnName("VeriDurumu");
        }
    }
}
