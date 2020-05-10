namespace HaiSanShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blog", "AnhMinhHoa", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blog", "AnhMinhHoa");
        }
    }
}
