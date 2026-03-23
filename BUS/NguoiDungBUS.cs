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
            {
                CurrentUser.HoTen = hoTen; // Cập nhật lại session
                return "Cập nhật thành công!";
            }

            return "Lỗi hệ thống, vui lòng thử lại!";
        }

        public string ChangePassword(int maND, string oldPass, string newPass, string confirmPass)
        {
            if (string.IsNullOrWhiteSpace(oldPass) || string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirmPass))
                return "Vui lòng nhập đầy đủ thông tin!";

            if (newPass != confirmPass)
                return "Mật khẩu mới và xác nhận mật khẩu không khớp!";

            var user = dal.GetByMaND(maND);
            if (user == null)
                return "Người dùng không tồn tại!";

            if (user.MatKhau != oldPass)
                return "Mật khẩu cũ không chính xác!";

            if (dal.CapNhatMatKhau(maND, newPass))
                return "Đổi mật khẩu thành công!";

            return "Lỗi hệ thống, vui lòng thử lại!";
        }

        public List<NguoiDung> LayTatCa()
        {
            return dal.GetAll();
        }

        public int PhatSinhMaTuDong()
        {
            var ids = dal.GetExistingIds();
            if (ids.Count == 0) return 1;
            return ids.Max() + 1;
        }

        public void Them(NguoiDung user)
        {
            dal.Add(user);
        }

        public void Sua(NguoiDung user)
        {
            dal.Update(user);
        }

        public void Xoa(int maND)
        {
            dal.Delete(maND);
        }
    }
}
