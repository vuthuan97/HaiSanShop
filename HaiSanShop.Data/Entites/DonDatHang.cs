using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class DonDatHang
    {
        public int MaDDH { get; set; }
        public DateTime NgayDat { get; set; }
        public bool DaGiao { get; set; }
        public bool DaThanhToan { get; set; }
        public int MaKH { get; set; }
        public int UuDai { get; set; }
        public bool DaHuy { get; set; }
        public bool DaXoa { get; set; }
        public DateTime NgayGiao { get; set; }
        public virtual List<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual KhachHang KhachHangs { get; set; }

    }
}
