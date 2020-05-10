using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class DanhMucSanPham
    {
        public int MaDM { get; set; }
        public string TenDanhMuc { get; set; }
        public virtual List<SanPham> sanPhams { get; set; }
        public virtual List<PhieuNhap> PhieuNhaps { get; set; }
        
    }
}
