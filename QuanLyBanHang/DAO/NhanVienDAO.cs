using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    internal class NhanVienDAO
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        public List<NhanVien> getList()
        {
            List<NhanVien> list = db.NhanViens.ToList();
            return list;
        }
        public int getCount()
        {
            return db.NhanViens.Count();
        }
        public NhanVien getRow(int id)
        {
            NhanVien sv = db.NhanViens.Find(id);
            return sv;
        }
        public bool Insert(NhanVien nv)
        {
            try
            {
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch(Exception) 
            { return false; }
        }
        public bool Update(NhanVien nv)
        {
            try
            {
                db.Entry(nv).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool Delete(NhanVien nv)
        {
            try
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public NhanVien Login(string email, string passwork)
        {
            string mk = MaHoa.ToShA1(passwork);
            NhanVien nv = db.NhanViens.Where(v => v.Email==email && v.MatKhau==mk).FirstOrDefault();
            if(nv!=null)
            {
                return nv;
            }
            else
            {
                return null;
            }
        }
        public List<NhanVien> TimKiem(string tukhoa)
        {
            try
            {
                string mh = tukhoa.ToLower();
                List<NhanVien> list = db.NhanViens.Where(nv =>
               nv.TenNV.ToLower().Contains(mh)).ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
    }
}
