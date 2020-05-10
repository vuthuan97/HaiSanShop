namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatechitietdondathang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChiTietDonDatHang", "TenSP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChiTietDonDatHang", "TenSP");
        }
    }
}
