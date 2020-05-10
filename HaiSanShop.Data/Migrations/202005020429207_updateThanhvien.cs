namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateThanhvien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThanhVien", "HoTen", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThanhVien", "HoTen");
        }
    }
}
