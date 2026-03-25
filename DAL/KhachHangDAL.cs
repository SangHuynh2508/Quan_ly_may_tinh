using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        private QLMayTinhDB db = new QLMayTinhDB();

        // 1. Hàm lấy tất cả khách hàng
        public List<KhachHang> GetAll()
        {
            return db.KhachHangs.ToList();
        }

        // 2. Hàm lấy lịch sử mua hàng bằng cách JOIN 3 bảng
        public object GetLichSuMuaHang(int maKhachHang)
        {
            var query = from hd in db.HoaDons
                        join ct in db.ChiTietHoaDons on hd.MaHoaDon equals ct.MaHoaDon
                        join sp in db.SanPhams on ct.MaSanPham equals sp.MaSanPham
                        where hd.MaKhachHang == maKhachHang
                        select new
                        {
                            MaHoaDon = hd.MaHoaDon,
                            NgayMua = hd.NgayLap,
                            TenSanPham = sp.TenSanPham,
                            SoLuong = ct.SoLuong,  
                            ThanhToan = hd.ThanhToan
                        };

            return query.ToList();
        }

        public List<int> GetExistingIds()
        {
            return db.KhachHangs.Select(k => k.MaKhachHang).ToList();
        }

        public void Add(KhachHang kh)
        {
            db.KhachHangs.Add(kh);
            db.SaveChanges();
        }

        public void Update(KhachHang kh)
        {
            var existing = db.KhachHangs.Find(kh.MaKhachHang);
            if (existing != null)
            {
                existing.HoTen = kh.HoTen;
                existing.SoDienThoai = kh.SoDienThoai;
                existing.DiaChi = kh.DiaChi;
                db.SaveChanges();
            }
        }

        public void Delete(int maKH)
        {
            var kh = db.KhachHangs.Find(maKH);
            if (kh != null)
            {
                db.KhachHangs.Remove(kh);
                db.SaveChanges();
            }
        }
    }
}
