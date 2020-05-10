
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
   public class ChiTietPhieuNhapConfiguration:EntityTypeConfiguration<ChiTietPhieuNhap>
    {
        public ChiTietPhieuNhapConfiguration()
        {
            this.ToTable("ChiTietPhieuNhap");
            this.HasKey(c => c.MaChiTietPN).Property(c => c.MaChiTietPN).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.MaPN).IsRequired();
            this.Property(c => c.MaSP).IsRequired();
            this.HasRequired<SanPham>(c => c.SanPhams).WithMany(c => c.ChiTietPhieuNhaps).HasForeignKey(c => c.MaSP);

        }
    }
}
