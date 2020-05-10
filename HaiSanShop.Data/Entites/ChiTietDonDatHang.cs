using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class ChiTietDonDatHang
    {
        public int MaChiTietDDH { get; set; }
        public int MaDDH { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public virtual DonDatHang DonDatHangs { get; set; }
        public virtual SanPham SanPhams { get; set; }

    }
}
