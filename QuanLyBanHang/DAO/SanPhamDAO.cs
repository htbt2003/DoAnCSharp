using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    internal class SanPhamDAO
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        public List<SanPham> getList()
        {
            List<SanPham> list = db.SanPhams.ToList();
            return list;
        }
        public List<SanPham> getList(int maloai)
        {
            try
            {
                List<SanPham> list = db.SanPhams.Where(nv =>
               nv.MaLoai == maloai).ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
        public int getCount()
        {
            return db.SanPhams.Count();
        }
        public SanPham getRow(int id)
        {
            SanPham sv = db.SanPhams.Find(id);
            return sv;
        }
        public bool Insert(SanPham nv)
        {
            try
            {
                db.SanPhams.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool Update(SanPham nv)
        {
            db.Entry(nv).State = EntityState.Modified;
            db.SaveChanges();
            return true;
            //try
            //{
            //    db.Entry(nv).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return true;
            //}
            //catch (Exception)
            //{ return false; }
        }
        public bool Delete(SanPham nv)
        {
            try
            {
                db.SanPhams.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public List<SanPham> TimKiem(string tukhoa)
        {
            try
            {
                string mh = tukhoa.ToLower();
                List<SanPham> list = db.SanPhams.Where(nv =>
               nv.TenSP.ToLower().Contains(mh)).ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
    }
}
