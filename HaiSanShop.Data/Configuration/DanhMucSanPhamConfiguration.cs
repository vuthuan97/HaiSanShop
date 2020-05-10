using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    public class DanhMucSanPhamConfiguration : EntityTypeConfiguration<DanhMucSanPham>
    {
        public DanhMucSanPhamConfiguration()
        {
            this.ToTable("DanhMucSanPham");
            this.HasKey(x => x.MaDM);
            this.Property(x => x.MaDM).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(x => x.TenDanhMuc).HasMaxLength(200);
          
        }
    }
}
