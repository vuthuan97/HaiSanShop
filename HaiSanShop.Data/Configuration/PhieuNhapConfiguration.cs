using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    public class PhieuNhapConfiguration:EntityTypeConfiguration<PhieuNhap>
    {
        public PhieuNhapConfiguration()
        {
            this.ToTable("PhieuNhap");
            this.HasKey(c => c.MaPN).Property(c => c.MaPN).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.MaDM).IsRequired();

            this.HasRequired<DanhMucSanPham>(c => c.DanhMucSanPhams).WithMany(c => c.PhieuNhaps).HasForeignKey(c => c.MaDM);
            this.HasMany(c => c.ChiTietPhieuNhaps).WithRequired(c => c.PhieuNhaps).HasForeignKey(c => c.MaPN);
        }
    }
}
