namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateThanhvien2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonDatHang", "MaTV", "dbo.ThanhVien");
            DropIndex("dbo.DonDatHang", new[] { "MaTV" });
            AddColumn("dbo.DonDatHang", "MaKH", c => c.Int(nullable: false));
            CreateIndex("dbo.DonDatHang", "MaKH");
            AddForeignKey("dbo.DonDatHang", "MaKH", "dbo.KhachHang", "MaKH", cascadeDelete: true);
            DropColumn("dbo.DonDatHang", "MaTV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonDatHang", "MaTV", c => c.Int(nullable: false));
            DropForeignKey("dbo.DonDatHang", "MaKH", "dbo.KhachHang");
            DropIndex("dbo.DonDatHang", new[] { "MaKH" });
            DropColumn("dbo.DonDatHang", "MaKH");
            CreateIndex("dbo.DonDatHang", "MaTV");
            AddForeignKey("dbo.DonDatHang", "MaTV", "dbo.ThanhVien", "MaTV", cascadeDelete: true);
        }
    }
}
