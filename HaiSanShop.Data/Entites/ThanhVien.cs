using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class ThanhVien
    {
        public int MaTV { get; set; }
        public string TaiKhoan { get; set; }
        public string HoTen { get; set; }
        public string MatKhau { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int MaLoaiTV { get; set; }
        public virtual LoaiThanhVien LoaiThanhViens { get; set; }
        
        public virtual List<KhachHang> KhachHangs { get; set; }

    }
}
