namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Ma = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(nullable: false, maxLength: 300),
                        VanTat = c.String(nullable: false, maxLength: 500),
                        NoiDung = c.String(nullable: false),
                        NgayTao = c.DateTime(nullable: false),
                        Hien = c.Boolean(nullable: false),
                        DaXoa = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Ma);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blog");
        }
    }
}
