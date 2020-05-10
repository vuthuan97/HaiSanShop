using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class ChiTietPhieuNhap
    {
        public int MaChiTietPN { get; set; }
        public int MaSP { get; set; }
        public int MaPN { get; set; }
        public int SoLuongNhap { get; set; }
        public decimal DonGiaNhap { get; set; }
        public virtual PhieuNhap PhieuNhaps { get; set; }
        public virtual SanPham SanPhams { get; set; }

    }
}
