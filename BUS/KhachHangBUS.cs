using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHangBUS
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHang> LayDanhSach()
        {
            return dal.GetAll();
        }

        public object LayLichSuMuaHang(int maKhachHang)
        {
            return dal.GetLichSuMuaHang(maKhachHang);
        }

        public int PhatSinhMaTuDong()
        {
            var ids = dal.GetExistingIds();
            if (ids.Count == 0) return 1;
            return ids.Max() + 1;
        }

        public void Them(KhachHang kh)
        {
            dal.Add(kh);
        }

        public void Sua(KhachHang kh)
        {
            dal.Update(kh);
        }

        public void Xoa(int maKH)
        {
            dal.Delete(maKH);
        }
    }
}
