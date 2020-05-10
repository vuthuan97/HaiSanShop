using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    class KhachHangConfiguation:EntityTypeConfiguration<KhachHang>
    {
        public KhachHangConfiguation()
        {
            
            this.ToTable("KhachHang");
            this.HasKey(c => c.MaKH);
            this.Property(c => c.TenKH).HasMaxLength(50);
            this.Property(c => c.DiaChi).HasMaxLength(255);
            this.Property(c => c.SoDienThoai).HasMaxLength(12);
            this.HasRequired<ThanhVien>(c => c.ThanhVienS).WithMany(c => c.KhachHangs).HasForeignKey(c => c.MaTV);
        }
    }
}
