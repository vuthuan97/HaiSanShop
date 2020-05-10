using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class LoaiThanhVien
    {
        public int MaLoaiTV { get; set; }
        public string TenLoai { get; set; }
        public int UuDai { get; set; }
        public virtual List<ThanhVien> ThanhViens { get; set; }
        public virtual List<PhanQuyen> PhanQuyens { get; set; }

    }
}
