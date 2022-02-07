using ModelEF.Model;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class SV_HoatDongDao
    {
        DBContext context = new DBContext();


        #region Thao tác bảng thông tin biên bản
        public List<sv_hoatdong> ListAll()
        {
            return context.sv_hoatdong.ToList();
        }

        //public IEnumerable<sv_hoatdong> ListWhereAll(string keysearch)
        //{
        //    IQueryable<sv_hoatdong> model = context.sv_hoatdong;
        //    if (!string.IsNullOrEmpty(keysearch))
        //        model = model.Where(x => x.maHD.Contains(keysearch));
        //    return model.OrderBy(x => x.maHD).ToList();
        //}

        public IEnumerable<HoatDongViewModel> ListWhereAll(string keysearch,string lop)
        {
            var model = from a in context.sv_hoatdong
                        join b in context.doanviens
                        on a.maSV equals b.maSV
                        where a.maHD == keysearch && b.maLop == lop
                        select new HoatDongViewModel()
                        {
                            maHD = a.maHD,
                            maSV = a.maSV,
                            maLop = b.maLop,
                            tenSV = b.tenSV,
                            tinhTrangDuyet = a.tinhTrangDuyet
                        };

            model.OrderBy(x => x.maSV);
            return model.ToList();
        }

        public sv_hoatdong Find(string id)
        {
            return context.sv_hoatdong.Find(id);
        }

        //public bool Edit(string maSV)
        //{
        //    try
        //    {
        //        var sp = context.sv_hoatdong.Find(maSV);
        //        if(sp.tinhTrangDuyet == false)
        //        {
        //            sp.tinhTrangDuyet = true;
        //        }
        //        else
        //        {
        //            sp.tinhTrangDuyet = false;
        //        }
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public string Edit(sv_hoatdong entity)
        {
            var sp = Find(entity.maSV);
            if (sp == null)
            {
                context.sv_hoatdong.Add(entity);
            }
            else
            {
                if (sp.tinhTrangDuyet == false)
                {
                    sp.tinhTrangDuyet = true;
                }
                else
                {
                    sp.tinhTrangDuyet = false;
                }
            }
            context.SaveChanges();
            return entity.maSV.ToString();
        }
        public List<HoatDongViewModel> ListByMaSV(string maSV)
        {
            var model = from a in context.doanviens
                        join b in context.sv_hoatdong on a.maSV equals b.maSV
                        where a.maSV == b.maSV
                        select new HoatDongViewModel()
                        {
                            maSV = b.maSV,
                            maHD = b.maHD,
                            tinhTrangDuyet = b.tinhTrangDuyet,
                            maLop = a.maLop,
                        };
            return model.OrderBy(x => x.maHD).ToList();
  
        }

        
        #endregion
        public bool ChangeStatus(string id, string id2)
        { 
            var a = context.sv_hoatdong.SingleOrDefault(x => x.maSV.Contains(id) && x.maHD.Contains(id2));
            a.tinhTrangDuyet = !a.tinhTrangDuyet;
            context.SaveChanges();
            return a.tinhTrangDuyet;
        }
    }
}