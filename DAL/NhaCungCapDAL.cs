using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL
    {
        private QLMayTinhDB db = new QLMayTinhDB();

        public List<NhaCungCap> GetAll()
        {
            return db.NhaCungCaps.ToList();
        }

        public void Add(NhaCungCap ncc)
        {
            db.NhaCungCaps.Add(ncc);
            db.SaveChanges();
        }

        public void Update(NhaCungCap ncc)
        {
            var existing = db.NhaCungCaps.Find(ncc.MaNCC);
            if (existing != null)
            {
                existing.TenNCC = ncc.TenNCC;
                existing.DiaChi = ncc.DiaChi;
                existing.SoDienThoai = ncc.SoDienThoai;
                db.SaveChanges();
            }
        }

        public void Delete(int maNCC)
        {
            var ncc = db.NhaCungCaps.Find(maNCC);
            if (ncc != null)
            {
                db.NhaCungCaps.Remove(ncc);
                db.SaveChanges();
            }
        }
        public List<int> GetExistingIds()
        {
            // Lấy danh sách các mã đang tồn tại và sắp xếp tăng dần
            return db.NhaCungCaps.Select(n => n.MaNCC).OrderBy(id => id).ToList();
        }
    }
}
