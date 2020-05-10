using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class LoaiSanPham
    {
        public int MaLoaiSP { get; set; }
        public string TenLoai { get; set; }
        public virtual List<SanPham> SanPhams { get; set; }        
    }
}
