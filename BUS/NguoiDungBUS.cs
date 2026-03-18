using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NguoiDungBUS
    {
        private NguoiDungDAL dal = new NguoiDungDAL();

        public string UpdateUserFullName(int maND, string hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                return "Họ tên không được để trống!";

            if (dal.CapNhatHoTen(maND, hoTen))
                return "Cập nhật thành công!";

            return "Lỗi hệ thống, vui lòng thử lại!";
        }
    }
}
