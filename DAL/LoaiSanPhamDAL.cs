using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        private QLMayTinhDB db = new QLMayTinhDB();

        public List<LoaiSanPham> GetAll()
        {
            return db.LoaiSanPhams.ToList();
        }

        public void Add(LoaiSanPham loai)
        {
            db.LoaiSanPhams.Add(loai);
            db.SaveChanges();
        }

        public void Delete(int maLoai)
        {
            var loai = db.LoaiSanPhams.Find(maLoai);
            if (loai != null)
            {
                db.LoaiSanPhams.Remove(loai);
                db.SaveChanges();
            }
        }
    }
}
