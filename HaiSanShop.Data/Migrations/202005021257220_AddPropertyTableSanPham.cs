namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyTableSanPham : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SanPham", "DaXoa", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SanPham", "DaXoa");
        }
    }
}
