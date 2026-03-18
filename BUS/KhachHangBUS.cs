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
    }
}
