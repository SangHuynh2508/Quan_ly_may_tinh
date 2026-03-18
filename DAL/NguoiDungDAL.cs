using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
        public class NguoiDungDAL
        {
            private QLMayTinhDB db = new QLMayTinhDB();

            // Hàm này sẽ dùng Entity Framework để lưu Họ tên mới
            public bool CapNhatHoTen(int maND, string hoTenMoi)
            {
                try
                {
                    // Tìm đúng người dùng trong DB dựa vào mã
                    var user = db.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == maND);
                    if (user != null)
                    {
                        user.HoTen = hoTenMoi; // Gán lại họ tên từ TextBox gửi xuống
                        db.SaveChanges();      // Lưu thay đổi xuống SQL Server
                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
}
