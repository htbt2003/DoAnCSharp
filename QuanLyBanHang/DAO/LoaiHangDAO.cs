using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    internal class LoaiHangDAO
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        public List<LoaiHang> getList()
        {
            List<LoaiHang> list = db.LoaiHangs.ToList();
            return list;
        }
        public int getCount()
        {
            return db.LoaiHangs.Count();
        }
        public LoaiHang getRow(int id)
        {
            LoaiHang lh = db.LoaiHangs.Find(id);
            return lh;
        }
        public bool Insert(LoaiHang nv)
        {
            try
            {
                db.LoaiHangs.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool Update(LoaiHang nv)
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
        public bool Delete(LoaiHang nv)
        {
            try
            {
                db.LoaiHangs.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public List<LoaiHang> TimKiem(string tukhoa)
        {
            try
            {
                string mh = tukhoa.ToLower();
                List<LoaiHang> list = db.LoaiHangs.Where(nv =>
               nv.TenLoai.ToLower().Contains(mh)).ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
    }
}
