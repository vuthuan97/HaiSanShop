using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using HaiSanShop.Data.Entites;
using System.ComponentModel.DataAnnotations.Schema;


namespace HaiSanShop.Data.Configuration
{
    public class SanPhamCongfiguration : EntityTypeConfiguration<SanPham>
    {
        public SanPhamCongfiguration()
        {
            this.ToTable("SanPham");
            this.HasKey(x => x.MaSP);
            this.Property(x => x.MaSP).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.TenSP).IsOptional().HasMaxLength(200);
            this.Property(x => x.MaDM).IsOptional();
            this.Property(x => x.MaLoaiSP).IsOptional();
            this.Property(x => x.SoLanMua).IsOptional();
            this.Property(x => x.SoLuongTon).IsOptional();
            this.Property(x => x.GiaNhap).IsOptional();
            this.Property(x => x.DonGia).IsOptional();
            this.Property(x => x.MoTa).IsOptional().HasMaxLength(10000);
            this.Property(x => x.HinhAnh).IsOptional().HasMaxLength(255);
            this.HasRequired<DanhMucSanPham>(e => e.DanhMucSanPhams).WithMany(p => p.sanPhams).HasForeignKey<int>(e => e.MaDM);
            this.HasRequired<LoaiSanPham>(e => e.LoaiSanPhams).WithMany(p => p.SanPhams).HasForeignKey<int>(e => e.MaLoaiSP);

        }
    }
       
    
}
