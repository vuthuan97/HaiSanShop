namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableKhachHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKH = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 255),
                        SoDienThoai = c.String(maxLength: 12),
                        MaTV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH)
                .ForeignKey("dbo.ThanhVien", t => t.MaTV, cascadeDelete: true)
                .Index(t => t.MaTV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhachHang", "MaTV", "dbo.ThanhVien");
            DropIndex("dbo.KhachHang", new[] { "MaTV" });
            DropTable("dbo.KhachHang");
        }
    }
}
