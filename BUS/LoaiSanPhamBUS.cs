using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSanPhamBUS
    {
        private LoaiSanPhamDAL dal = new LoaiSanPhamDAL();

        public List<LoaiSanPham> GetAll()
        {
            return dal.GetAll();
        }

        public string Add(string tenLoai)
        {
            if (string.IsNullOrWhiteSpace(tenLoai))
                return "Tên loại không được để trống!";

            LoaiSanPham loai = new LoaiSanPham { TenLoai = tenLoai };
            try
            {
                dal.Add(loai);
                return "Thêm thành công!";
            }
            catch
            {
                return "Lỗi hệ thống!";
            }
        }

        public string Delete(int maLoai)
        {
            try
            {
                dal.Delete(maLoai);
                return "Xóa thành công!";
            }
            catch (Exception ex)
            {
                // Có thể lỗi do ràng buộc khóa ngoại (loại sản phẩm đang có sản phẩm)
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("REFERENCE constraint"))
                {
                    return "Không thể xóa loại sản phẩm này vì đang có sản phẩm thuộc loại này!";
                }
                return "Lỗi hệ thống!";
            }
        }
    }
}
