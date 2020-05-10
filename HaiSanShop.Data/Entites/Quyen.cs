using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
   public class Quyen
    {
        public string MaQuyen { get; set; }
        public string TenQuyen { get; set; }
        public virtual List<PhanQuyen> PhanQuyens { get; set; }
    }
}
