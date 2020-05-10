using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public int MaTV { get; set; }
        public virtual ThanhVien ThanhVienS { get; set; }
        public virtual List<DonDatHang> DonDatHangs { get; set; }
    }
}
