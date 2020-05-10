using HaiSanSamSon.Data.EF;
using HaiSanShop.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HaiSanShop.Application.Public
{
    
   public class SanPhamPublic
    {
        private readonly HaiSanHopDbContext context = null;
        public SanPhamPublic()
        {
            this.context = new HaiSanHopDbContext();
        }
        public List<SanPham> GetAllSP()
        {
            var list = context.SanPhams.ToList();
            return list;
        }
        public List<SanPham> GetLoai(int MaLoai, int ItemCount)
        {
            var list = context.SanPhams.Where(c => c.MaLoaiSP == MaLoai && c.Moi == true).Take(ItemCount).ToList();
            return list;
        }
        public List<SanPham> GetListDMAndLoai(int? maLoai, int? MaDM)
        {
            var list = context.SanPhams.Where(c => c.MaLoaiSP == maLoai && c.MaDM == MaDM).ToList();
            return list;
        }
        public string gettenloai(int? madm)
        {
            var dm = context.DanhMucSanPhams.SingleOrDefault(c => c.MaDM == madm);
            string tendm = dm.TenDanhMuc;
            return tendm;
        }
        public SanPham getDetail(int? MaSP)
        {
            var sp = context.SanPhams.SingleOrDefault(c => c.MaSP == MaSP);
            return sp;
        }
        public List<SanPham> Search(string key)
        {
            var lst = context.SanPhams.Where(c => c.TenSP.Contains(key) && c.DaXoa == false).ToList();
            return lst;
        }
    }
}
