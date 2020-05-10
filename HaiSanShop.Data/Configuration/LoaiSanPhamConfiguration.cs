using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HaiSanShop.Data.Configuration
{
   public class LoaiSanPhamConfiguration:EntityTypeConfiguration<LoaiSanPham>
    {
        public LoaiSanPhamConfiguration()
        {
            this.ToTable("LoaiSanPham");
            this.HasKey(x => x.MaLoaiSP);
            this.Property(x => x.MaLoaiSP).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.TenLoai).HasMaxLength(200);
            
        }
    }
}
