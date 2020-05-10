using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HaiSanShop.Data.Configuration
{
    class ThanhVienConfiguration:EntityTypeConfiguration<ThanhVien>
    {
        public ThanhVienConfiguration()
        {
            this.ToTable("ThanhVien");
            this.HasKey(c => c.MaTV).Property(c=>c.MaTV).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            this.Property(c => c.TaiKhoan).IsRequired().HasMaxLength(200);
            this.Property(c => c.MatKhau).IsRequired().HasMaxLength(100);
            this.Property(c => c.HoTen).HasMaxLength(50);
            this.Property(c => c.SDT).HasMaxLength(12);
            this.Property(c => c.DiaChi).HasMaxLength(255);
            this.Property(c => c.MaLoaiTV).IsRequired();
            this.HasRequired<LoaiThanhVien>(c => c.LoaiThanhViens).WithMany(c => c.ThanhViens).HasForeignKey(c => c.MaLoaiTV);

        }
    }
}
