using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class NguoiDungDAL
    {
        private QLMayTinhDB db = new QLMayTinhDB();

        public NguoiDung GetByMaND(int maND)
        {
            return db.NguoiDungs.Include(u => u.VaiTro).SingleOrDefault(u => u.MaNguoiDung == maND);
        }

        public bool CapNhatHoTen(int maND, string hoTenMoi)
        {
            try
            {
                var user = db.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == maND);
                if (user != null)
                {
                    user.HoTen = hoTenMoi;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhatMatKhau(int maND, string matKhauMoi)
        {
            try
            {
                var user = db.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == maND);
                if (user != null)
                {
                    user.MatKhau = matKhauMoi;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<NguoiDung> GetAll()
        {
            return db.NguoiDungs.Include(u => u.VaiTro).ToList();
        }

        public List<int> GetExistingIds()
        {
            return db.NguoiDungs.Select(u => u.MaNguoiDung).ToList();
        }

        public void Add(NguoiDung user)
        {
            if (string.IsNullOrEmpty(user.MatKhau)) user.MatKhau = "123456"; // Default pass
            db.NguoiDungs.Add(user);
            db.SaveChanges();
        }

        public void Update(NguoiDung user)
        {
            var existing = db.NguoiDungs.Find(user.MaNguoiDung);
            if (existing != null)
            {
                existing.HoTen = user.HoTen;
                existing.TenDangNhap = user.TenDangNhap;
                existing.MaVaiTro = user.MaVaiTro;
                db.SaveChanges();
            }
        }

        public void Delete(int maND)
        {
            var user = db.NguoiDungs.Find(maND);
            if (user != null)
            {
                db.NguoiDungs.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
