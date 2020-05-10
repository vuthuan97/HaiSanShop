using HaiSanSamSon.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class ItemGioHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        
        public ItemGioHang() { }
        public ItemGioHang(int ImaSP, int ISoLuong)
        {
            using (HaiSanHopDbContext db = new HaiSanHopDbContext())
            {
                this.MaSP = ImaSP;
                this.TenSP = db.SanPhams.Single(c => c.MaSP == ImaSP).TenSP;
                this.DonGia = db.SanPhams.Single(c => c.MaSP == ImaSP).DonGia;
                this.SoLuong = ISoLuong;
                this.HinhAnh = db.SanPhams.Single(c => c.MaSP == ImaSP).HinhAnh;
                this.ThanhTien = SoLuong * DonGia;
            }
        }
        public ItemGioHang(int ImaSP)
        {
            using (HaiSanHopDbContext db = new HaiSanHopDbContext())
            {
                this.MaSP = ImaSP;
                this.TenSP = db.SanPhams.Single(c => c.MaSP == ImaSP).TenSP;
                this.DonGia = db.SanPhams.Single(c => c.MaSP == ImaSP).DonGia;
                this.HinhAnh = db.SanPhams.Single(c => c.MaSP == ImaSP).HinhAnh;
                this.SoLuong = 1;
                this.ThanhTien = SoLuong * DonGia;
            }

        }
    }
}
