using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhaCungCapBUS
    {
        private NhaCungCapDAL dal = new NhaCungCapDAL();

        public List<NhaCungCap> LayTatCa() => dal.GetAll();
        public void Them(NhaCungCap ncc) => dal.Add(ncc);
        public void Sua(NhaCungCap ncc) => dal.Update(ncc);
        public void Xoa(int ma) => dal.Delete(ma);

        public int PhatSinhMaTuDong()
        {
            List<int> existingIds = dal.GetExistingIds();
            if (existingIds.Count == 0) return 1;
            for (int i = 0; i < existingIds.Count; i++)
            {
                int expectedId = i + 1; 
                if (existingIds[i] != expectedId)
                {
                    return expectedId; 
                }
            }


            return existingIds.Count + 1;
        }
    }
}
