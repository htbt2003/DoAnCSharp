using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace QuanLyBanHang.DAO
{
    internal class HoaDonDAO
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        public List<HoaDon> getList()
        {
            List<HoaDon> list = db.HoaDons.ToList();
            return list;
        }
        public int getCount()
        {
            return db.HoaDons.Count();
        }
        public HoaDon getRow(string id)
        {
            HoaDon sv = db.HoaDons.Find(id);
            return sv;
        }
        public bool Insert(HoaDon nv)
        {
            try
            {
                db.HoaDons.Add(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public bool Update(HoaDon nv)
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
        public bool Delete(HoaDon nv)
        {
            try
            {
                db.HoaDons.Remove(nv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }
        }
        public List<HoaDon> TimKiem(string tukhoa)
        {
            try
            {
                string mh = tukhoa.ToLower();
                List<HoaDon> list = db.HoaDons.Where(nv =>
               nv.MaHD.ToLower().Contains(mh)).ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
        public List<HoaDon> Loc(DateTime batdau, DateTime ketthuc)
        {
            try
            {
                List<HoaDon> list = db.HoaDons.Where(hd => hd.NgayBan >= batdau && hd.NgayBan <= ketthuc)
                .ToList();
                return list;
            }
            catch (Exception)
            { return null; }
        }
    }
}
