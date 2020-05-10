using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    class QuyenConfiguration:EntityTypeConfiguration<Quyen>
    {
        public QuyenConfiguration()
        {
            this.ToTable("Quyen");
            this.HasKey(c =>c.MaQuyen).Property(c=>c.MaQuyen).HasMaxLength(50);
            this.Property(c => c.TenQuyen).HasMaxLength(150);

        }
    }
}
