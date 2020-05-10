
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    public class ChiTietDonDatHangConfiguration:EntityTypeConfiguration<ChiTietDonDatHang>
    {
        public ChiTietDonDatHangConfiguration()
        {
            this.ToTable("ChiTietDonDatHang");
            this.HasKey(c => c.MaChiTietDDH).Property(c => c.MaChiTietDDH).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.MaDDH).IsRequired();
            this.Property(c => c.MaSP).IsRequired();
            this.HasRequired<DonDatHang>(c => c.DonDatHangs).WithMany(c => c.ChiTietDonDatHangs).HasForeignKey(c => c.MaDDH);
            this.HasRequired<SanPham>(c => c.SanPhams).WithMany(c => c.ChiTietDonDatHangs).HasForeignKey(c => c.MaSP);
        }
    }
}
