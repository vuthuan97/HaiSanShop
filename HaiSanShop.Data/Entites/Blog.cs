using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class Blog
    {
        public int Ma { get; set; }
        public string TieuDe { get; set; }
        public string AnhMinhHoa { get; set; }
        public string VanTat { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
        public bool Hien { get; set; }
        public bool DaXoa { get; set; }

    }
}
