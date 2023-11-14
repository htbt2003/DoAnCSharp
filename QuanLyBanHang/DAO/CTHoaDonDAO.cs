using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    internal class CTHoaDonDAO
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        public List<CTHoaDon> getList()
        {
            List<CTHoaDon> list = db.CTHoaDons.ToList();
            return list;
        }
        public int getCount()
        {
            return db.CTHoaDons.Count();
        }
        public CTHoaDon getRow(int id)
        {
            CTHoaDon sv = db.CTHoaDons.Find(id);
            return sv;
        }
        public List<CTHoaDon> getList(string mahd)
        {
            List<CTHoaDon> list = db.CTHoaDons.Where(p => p.MaHD == mahd).ToList();
            return list;
        }
        public bool CheckExit(CTHoaDon sp, string mahd)
        {
            CTHoaDon ctdh = db.CTHoaDons.Where(ct =>
               ct.MaSP == sp.MaSP && ct.MaHD==mahd).FirstOrDefault();
            if (ctdh != null)
            {
                return false;
            }
            else
            { return true; }
        }
        public bool Insert(CTHoaDon nv)
        {
            try
            {
                db.CTHoaDons.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool Update(CTHoaDon nv)
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
        public bool Delete(CTHoaDon nv)
        {
            try
            {
                db.CTHoaDons.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
    }
}
