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
            // Sử dụng LINQ để JOIN bảng HoaDon, ChiTietHoaDon và SanPham
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

            // Trả về một danh sách (List) các đối tượng ẩn danh (Anonymous type)
            // Entity Framework sẽ tự động chuyển đổi thành dạng bảng cho DataGridView
            return query.ToList();
        }
    }
}
