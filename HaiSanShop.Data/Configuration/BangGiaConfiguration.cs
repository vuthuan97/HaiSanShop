using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    public class BangGiaConfiguration:EntityTypeConfiguration<BangGia>
    {
        public BangGiaConfiguration()
        {
            this.ToTable("BangGia");
            this.HasKey(c => c.Ma);
            this.Property(c => c.TenSanPham).HasMaxLength(255);
        }
    }
}
