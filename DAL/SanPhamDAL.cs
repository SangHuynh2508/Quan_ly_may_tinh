using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPhamDAL
    {
        private QLMayTinhDB db = new QLMayTinhDB();

        public List<SanPham> GetAll()
        {
            return db.SanPhams.Include("LoaiSanPham").ToList();
        }

        public void Add(SanPham sp)
        {
            db.SanPhams.Add(sp);
            db.SaveChanges();
        }

        public void Update(SanPham sp)
        {
            var existing = db.SanPhams.Find(sp.MaSanPham);
            if (existing != null)
            {
                existing.TenSanPham = sp.TenSanPham;
                existing.MaLoai = sp.MaLoai;
                existing.HangSanXuat = sp.HangSanXuat;
                existing.GiaNhap = sp.GiaNhap;
                existing.GiaBan = sp.GiaBan;
                existing.SoLuongTon = sp.SoLuongTon;
                db.SaveChanges();
            }
        }

        public void Delete(int maSP)
        {
            var sp = db.SanPhams.Find(maSP);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
            }
        }

        public List<int> GetExistingIds()
        {
            return db.SanPhams.Select(s => s.MaSanPham).OrderBy(id => id).ToList();
        }
    }
}
