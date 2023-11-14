using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    internal class KhachHangDAO
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        public List<KhachHang> getList()
        {
            List<KhachHang> list = db.KhachHangs.ToList();
            return list;
        }
        public int getCount()
        {
            return db.KhachHangs.Count();
        }
        public KhachHang getRow(int id)
        {
            KhachHang sv = db.KhachHangs.Find(id);
            return sv;
        }
        public bool Insert(KhachHang nv)
        {
            db.KhachHangs.Add(nv);
            db.SaveChanges();
            return true;
            //try
            //{
            //    db.KhachHangs.Add(nv);
            //    db.SaveChanges();
            //    return true;
            //}
            //catch (Exception)
            //{ return false; }
        }
        public bool Update(KhachHang nv)
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
        public bool Delete(KhachHang nv)
        {
            try
            {
                db.KhachHangs.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public List<KhachHang> TimKiem(string tukhoa)
        {
            try
            {
                string mh = tukhoa.ToLower();
                List<KhachHang> list = db.KhachHangs.Where(nv =>
               nv.TenKH.ToLower().Contains(mh)).ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
    }
}
