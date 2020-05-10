using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class PhanQuyen
    {
        public string MaQuyen { get; set; }
        public int MaLoaiTV { get; set; }
        public string GhiChu { get; set; }
        public virtual Quyen Quyens { get; set; }
        public virtual LoaiThanhVien LoaiThanhViens { get; set; }
    }
}
