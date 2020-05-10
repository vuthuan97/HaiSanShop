using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Configuration
{
    public class BlogConfiguration:EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            this.ToTable("Blog");
            
            this.HasKey(c => c.Ma);
            this.Property(c => c.TieuDe).IsRequired().HasMaxLength(300);
            this.Property(c => c.VanTat).IsRequired().HasMaxLength(500);
            this.Property(c => c.NoiDung).IsRequired().HasMaxLength(100000);
            this.Property(c => c.AnhMinhHoa).HasMaxLength(255);
            
        }
    }
}
