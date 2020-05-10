using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    class LoaiThanhVienConfiguration : EntityTypeConfiguration<LoaiThanhVien>
    {
        public LoaiThanhVienConfiguration()
        {
            this.ToTable("LoaiThanhVien");
            this.HasKey(c => c.MaLoaiTV).Property(c => c.MaLoaiTV).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.TenLoai).HasMaxLength(200);
             
        }
    }
}
