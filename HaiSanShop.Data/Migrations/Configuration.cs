namespace HaiSanShop.Data.Migrations
{
    using HaiSanShop.Data.Entites;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HaiSanSamSon.Data.EF.HaiSanHopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HaiSanSamSon.Data.EF.HaiSanHopDbContext context)
        {
            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method
            ////  to avoid creating duplicate seed data.
            //context.loaithanhviens.AddOrUpdate(
            //  x => x.MaLoaiTV,
            //  new LoaiThanhVien() { TenLoai = "QuanTri", UuDai = 0 },
            //  new LoaiThanhVien() { TenLoai = "QuanLy", UuDai = 0 },
            //  new LoaiThanhVien() { TenLoai = "NhanVien", UuDai = 0 },
            //  new LoaiThanhVien() { TenLoai = "KhachHangThuong", UuDai = 5 },
            //  new LoaiThanhVien() { TenLoai = "KhachHangVip", UuDai = 10 }
            //  );
            //context.quyens.AddOrUpdate(
            //    new Quyen() { MaQuyen = "QLSanPham", TenQuyen = "Quản Lý Sản Phẩm" },
            //    new Quyen() { MaQuyen = "QLDonDatHang", TenQuyen = "Quản Lý Đơn Đặt Hàng" },
            //    new Quyen() { MaQuyen = "QLNhapHang", TenQuyen = "Quản Lý Nhập Hàng" },
            //    new Quyen() { MaQuyen = "QLThanhVien", TenQuyen = "Quản Lý Thành Viên" }
            //    );
            //context.LoaiSanPhams.AddOrUpdate(
            //    x => x.MaLoaiSP,
            //          new LoaiSanPham() { TenLoai = "Đồ Khô" },
            //          new LoaiSanPham() { TenLoai = "Đồ Tươi" },
            //          new LoaiSanPham() { TenLoai = "Sản Phẩm Đã Chế Biến" },
            //          new LoaiSanPham() { TenLoai = "Sản Phẩm Có Vỏ", }
            //    );
            //context.DanhMucSanPhams.AddOrUpdate(
            //    x => x.MaDM,
            //         new DanhMucSanPham() { TenDanhMuc = "Cá" },
            //         new DanhMucSanPham() { TenDanhMuc = "Mực" },
            //         new DanhMucSanPham() { TenDanhMuc = "Tôm -Tép" },
            //          new DanhMucSanPham() { TenDanhMuc = "Cua-Ghẹ" },
            //         new DanhMucSanPham() { TenDanhMuc = "Mực-Bạch Tuộc" },
            //         new DanhMucSanPham() { TenDanhMuc = "Hàu -Sò Điệp" },
            //         new DanhMucSanPham() { TenDanhMuc = "Ngao -Nghêu" },
            //         new DanhMucSanPham() { TenDanhMuc = "Nước mắm" },
            //         new DanhMucSanPham() { TenDanhMuc = "Mắm Tép" }
            //    );
        }
    }
}
