using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
   public  class PhanQuyenConfiguration:EntityTypeConfiguration<PhanQuyen>
    {
        public PhanQuyenConfiguration()
        {
            this.ToTable("PhanQuyen");
            this.HasKey(c => new { c.MaQuyen, c.MaLoaiTV });
            this.Property(c => c.GhiChu).HasMaxLength(200);
            this.HasRequired(c => c.LoaiThanhViens).WithMany(c => c.PhanQuyens).HasForeignKey(c => c.MaLoaiTV);
            this.HasRequired(c => c.Quyens).WithMany(c => c.PhanQuyens).HasForeignKey(c => c.MaQuyen);
        }
    }
}
