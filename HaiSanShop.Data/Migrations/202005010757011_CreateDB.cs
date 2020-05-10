namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDonDatHang",
                c => new
                    {
                        MaChiTietDDH = c.Int(nullable: false, identity: true),
                        MaDDH = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaChiTietDDH)
                .ForeignKey("dbo.DonDatHang", t => t.MaDDH, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaDDH)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.DonDatHang",
                c => new
                    {
                        MaDDH = c.Int(nullable: false, identity: true),
                        NgayDat = c.DateTime(nullable: false),
                        DaGiao = c.Boolean(nullable: false),
                        DaThanhToan = c.Boolean(nullable: false),
                        MaTV = c.Int(nullable: false),
                        UuDai = c.Int(nullable: false),
                        DaHuy = c.Boolean(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                        NgayGiao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaDDH)
                .ForeignKey("dbo.ThanhVien", t => t.MaTV, cascadeDelete: true)
                .Index(t => t.MaTV);
            
            CreateTable(
                "dbo.ThanhVien",
                c => new
                    {
                        MaTV = c.Int(nullable: false, identity: true),
                        TaiKhoan = c.String(nullable: false, maxLength: 200),
                        MatKhau = c.String(nullable: false, maxLength: 100),
                        SDT = c.String(maxLength: 12),
                        DiaChi = c.String(maxLength: 255),
                        MaLoaiTV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaTV)
                .ForeignKey("dbo.LoaiThanhVien", t => t.MaLoaiTV, cascadeDelete: true)
                .Index(t => t.MaLoaiTV);
            
            CreateTable(
                "dbo.LoaiThanhVien",
                c => new
                    {
                        MaLoaiTV = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(maxLength: 200),
                        UuDai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiTV);
            
            CreateTable(
                "dbo.PhanQuyen",
                c => new
                    {
                        MaQuyen = c.String(nullable: false, maxLength: 50),
                        MaLoaiTV = c.Int(nullable: false),
                        GhiChu = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.MaQuyen, t.MaLoaiTV })
                .ForeignKey("dbo.LoaiThanhVien", t => t.MaLoaiTV, cascadeDelete: false)
                .ForeignKey("dbo.Quyen", t => t.MaQuyen, cascadeDelete: false)
                .Index(t => t.MaQuyen)
                .Index(t => t.MaLoaiTV);
            
            CreateTable(
                "dbo.Quyen",
                c => new
                    {
                        MaQuyen = c.String(nullable: false, maxLength: 50),
                        TenQuyen = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.MaQuyen);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        TenSP = c.String(maxLength: 200),
                        MaDM = c.Int(nullable: false),
                        MaLoaiSP = c.Int(nullable: false),
                        DonGia = c.Decimal(precision: 18, scale: 2),
                        NgayNhap = c.DateTime(nullable: false),
                        GiaNhap = c.Decimal(precision: 18, scale: 2),
                        HinhAnh = c.String(maxLength: 255),
                        MoTa = c.String(),
                        SoLuongTon = c.Int(),
                        Moi = c.Boolean(nullable: false),
                        DanhGia = c.Int(nullable: false),
                        SoLanMua = c.Int(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.DanhMucSanPham", t => t.MaDM, cascadeDelete: false)
                .ForeignKey("dbo.LoaiSanPham", t => t.MaLoaiSP, cascadeDelete: false)
                .Index(t => t.MaDM)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.ChiTietPhieuNhap",
                c => new
                    {
                        MaChiTietPN = c.Int(nullable: false, identity: true),
                        MaSP = c.Int(nullable: false),
                        MaPN = c.Int(nullable: false),
                        SoLuongNhap = c.Int(nullable: false),
                        DonGiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaChiTietPN)
                .ForeignKey("dbo.PhieuNhap", t => t.MaPN, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: false)
                .Index(t => t.MaSP)
                .Index(t => t.MaPN);
            
            CreateTable(
                "dbo.PhieuNhap",
                c => new
                    {
                        MaPN = c.Int(nullable: false, identity: true),
                        MaDM = c.Int(nullable: false),
                        NgayNhap = c.DateTime(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MaPN)
                .ForeignKey("dbo.DanhMucSanPham", t => t.MaDM, cascadeDelete: false)
                .Index(t => t.MaDM);
            
            CreateTable(
                "dbo.DanhMucSanPham",
                c => new
                    {
                        MaDM = c.Int(nullable: false, identity: true),
                        TenDanhMuc = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaDM);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false, identity: true),
                        TenLoai = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietDonDatHang", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "MaLoaiSP", "dbo.LoaiSanPham");
            DropForeignKey("dbo.SanPham", "MaDM", "dbo.DanhMucSanPham");
            DropForeignKey("dbo.ChiTietPhieuNhap", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.PhieuNhap", "MaDM", "dbo.DanhMucSanPham");
            DropForeignKey("dbo.ChiTietPhieuNhap", "MaPN", "dbo.PhieuNhap");
            DropForeignKey("dbo.ChiTietDonDatHang", "MaDDH", "dbo.DonDatHang");
            DropForeignKey("dbo.DonDatHang", "MaTV", "dbo.ThanhVien");
            DropForeignKey("dbo.ThanhVien", "MaLoaiTV", "dbo.LoaiThanhVien");
            DropForeignKey("dbo.PhanQuyen", "MaQuyen", "dbo.Quyen");
            DropForeignKey("dbo.PhanQuyen", "MaLoaiTV", "dbo.LoaiThanhVien");
            DropIndex("dbo.PhieuNhap", new[] { "MaDM" });
            DropIndex("dbo.ChiTietPhieuNhap", new[] { "MaPN" });
            DropIndex("dbo.ChiTietPhieuNhap", new[] { "MaSP" });
            DropIndex("dbo.SanPham", new[] { "MaLoaiSP" });
            DropIndex("dbo.SanPham", new[] { "MaDM" });
            DropIndex("dbo.PhanQuyen", new[] { "MaLoaiTV" });
            DropIndex("dbo.PhanQuyen", new[] { "MaQuyen" });
            DropIndex("dbo.ThanhVien", new[] { "MaLoaiTV" });
            DropIndex("dbo.DonDatHang", new[] { "MaTV" });
            DropIndex("dbo.ChiTietDonDatHang", new[] { "MaSP" });
            DropIndex("dbo.ChiTietDonDatHang", new[] { "MaDDH" });
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.DanhMucSanPham");
            DropTable("dbo.PhieuNhap");
            DropTable("dbo.ChiTietPhieuNhap");
            DropTable("dbo.SanPham");
            DropTable("dbo.Quyen");
            DropTable("dbo.PhanQuyen");
            DropTable("dbo.LoaiThanhVien");
            DropTable("dbo.ThanhVien");
            DropTable("dbo.DonDatHang");
            DropTable("dbo.ChiTietDonDatHang");
        }
    }
}
