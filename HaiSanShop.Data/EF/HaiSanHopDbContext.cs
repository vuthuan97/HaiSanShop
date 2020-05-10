
using HaiSanShop.Data.Configuration;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanSamSon.Data.EF
{
    public class HaiSanHopDbContext : DbContext
    {
        public HaiSanHopDbContext() : base("name = haisanshopConnectString")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new SanPhamCongfiguration());
            modelBuilder.Configurations.Add(new LoaiSanPhamConfiguration());
            modelBuilder.Configurations.Add(new DanhMucSanPhamConfiguration());
            modelBuilder.Configurations.Add(new DonDatHangConfiguration());
            modelBuilder.Configurations.Add(new ChiTietDonDatHangConfiguration());
            modelBuilder.Configurations.Add(new PhieuNhapConfiguration());
            modelBuilder.Configurations.Add(new ChiTietPhieuNhapConfiguration());
            modelBuilder.Configurations.Add(new LoaiThanhVienConfiguration());
            modelBuilder.Configurations.Add(new ThanhVienConfiguration());
            modelBuilder.Configurations.Add(new QuyenConfiguration());
            modelBuilder.Configurations.Add(new PhanQuyenConfiguration());
            modelBuilder.Configurations.Add(new KhachHangConfiguation());
            modelBuilder.Configurations.Add(new BangGiaConfiguration());
            modelBuilder.Configurations.Add(new BlogConfiguration());
        }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<DonDatHang> dondathangs { get; set; }
        public DbSet<ChiTietDonDatHang> chitietdondathangs { get; set; }
        public DbSet<PhieuNhap> phieunhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> chitietphieunhaps { get; set; }
        public DbSet<LoaiThanhVien> loaithanhviens { get; set; }
        public DbSet<ThanhVien> thanhviens { get; set; }
        public DbSet<Quyen> quyens { get; set; }
        public DbSet<PhanQuyen> phanquyens { get; set; }
        public DbSet<BangGia> BangGias { get; set; }
        public DbSet<Blog> Blogs { get; set; }


    }
}
