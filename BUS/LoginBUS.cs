using System.Linq;
using System.Data.Entity;
using DAL;

namespace BUS
{
    public class LoginBUS
    {
        public NguoiDung CheckLogin(string username, string password)
        {
            using (var db = new QLMayTinhDB())
            {
                return db.NguoiDungs
                         .Include(x => x.VaiTro)
                         .FirstOrDefault(x => x.TenDangNhap == username
                                           && x.MatKhau == password);
            }
        }
    }
}