using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class CurrentUser
    {
        // Lưu ID để truy vấn Database
        public static int MaNguoiDung { get; set; }

        // Lưu tên để hiển thị lên giao diện cho nhanh
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string VaiTro { get; set; }
        public static string MatKhau { get; set; }
        public static int MaVaiTro { get; set; }
    }
}