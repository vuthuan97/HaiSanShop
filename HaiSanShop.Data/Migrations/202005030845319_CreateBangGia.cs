namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBangGia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangGia",
                c => new
                    {
                        Ma = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(maxLength: 255),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Ma);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BangGia");
        }
    }
}
