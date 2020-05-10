using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class PhieuNhap
    {
        public int MaPN { get; set; }
        public int MaDM { get; set; }
        public DateTime NgayNhap { get; set; }
        public bool DaXoa { get; set; }
        public virtual DanhMucSanPham DanhMucSanPhams { get; set; }
        public virtual List<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}
