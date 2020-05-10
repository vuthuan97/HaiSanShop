using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    public class DonDatHangConfiguration:EntityTypeConfiguration<DonDatHang>
    {
        public DonDatHangConfiguration()
        {
            this.ToTable("DonDatHang");
            this.HasKey(c => c.MaDDH).Property(c => c.MaDDH)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.MaKH).IsRequired();
            this.HasRequired<KhachHang>(c => c.KhachHangs).WithMany(c => c.DonDatHangs).HasForeignKey(c => c.MaKH);
        }
    }
}
