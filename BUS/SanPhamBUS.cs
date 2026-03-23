using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SanPhamBUS
    {
        private SanPhamDAL dal = new SanPhamDAL();

        public List<SanPham> GetAll() => dal.GetAll();

        public string Upsert(SanPham sp, bool isNew)
        {
            if (string.IsNullOrWhiteSpace(sp.TenSanPham))
                return "Tên sản phẩm không được để trống!";

            try
            {
                if (isNew)
                {
                    dal.Add(sp);
                    return "Thêm sản phẩm thành công!";
                }
                else
                {
                    dal.Update(sp);
                    return "Cập nhật sản phẩm thành công!";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }

        public string Delete(int maSP)
        {
            try
            {
                dal.Delete(maSP);
                return "Xóa sản phẩm thành công!";
            }
            catch
            {
                return "Lỗi hệ thống, không thể xóa!";
            }
        }

        public int PhatSinhMaTuDong()
        {
            List<int> ids = dal.GetExistingIds();
            if (ids.Count == 0) return 1;
            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i] != i + 1) return i + 1;
            }
            return ids.Count + 1;
        }
    }
}
