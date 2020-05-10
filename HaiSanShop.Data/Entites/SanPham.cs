using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaiSanShop.Data.Entites
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int MaDM { get; set; }
        public int MaLoaiSP { get; set; }
        public decimal DonGia { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal GiaNhap { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public int SoLuongTon { get; set; }
        public bool Moi { get; set; }
        public int DanhGia { get; set; }
        public int SoLanMua { get; set; }
        public bool DaXoa { get; set; }
        public virtual DanhMucSanPham DanhMucSanPhams { get; set; }
        public virtual LoaiSanPham LoaiSanPhams { get; set; }
        public virtual List<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual List<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } 
    }
}
