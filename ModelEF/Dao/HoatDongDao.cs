using ModelEF.Model;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class HoatDongDao
    {
        public static string cn = @"data source=THANHNHON\SQLEXPRESS;initial catalog=doan;Integrated Security=True";
        SqlConnection conn = new SqlConnection(cn);
        DBContext context = new DBContext();


        #region Thao tác bảng thông tin biên bản
        //public List<hoatdong> ListAll()
        //{
        //    return context.hoatdongs.ToList();
        //}

        public List<hoatdong> ListAll()
        {
            var da_dk = (from sv_hoatdong in context.sv_hoatdong where sv_hoatdong.tinhTrangDuyet == true select sv_hoatdong).Count();
            IQueryable<hoatdong> model = context.hoatdongs;
            DateTime now = DateTime.Now;

            model = model.Where(x =>  x.ngayKetThucDK >= now.Date && x.soLuong > da_dk);
            return model.OrderBy(x => x.maHD).ToList();
        }

        public IEnumerable<hoatdong> ListWhereAll(string keysearch)
        {
            var da_dk = (from sv_hoatdong in context.sv_hoatdong where sv_hoatdong.maHD == keysearch && sv_hoatdong.tinhTrangDuyet == true select sv_hoatdong).Count();
            IQueryable<hoatdong> model = context.hoatdongs;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.tenHD.Contains(keysearch));
            return model.OrderBy(x => x.maHD).ToList();
        }


        //public string Insert(hoatdong entity)
        //{
        //    var sp = Find(entity.maHD);
        //    if (sp == null)
        //    {
        //        context.hoatdongs.Add(entity);
        //    }
        //    else
        //    {
        //        sp.maHD = entity.maHD;
        //    }
        //    context.SaveChanges();
        //    return entity.maHD.ToString();
        //}

        public void ThemTB(thongbaolop tb)
        {
            SqlCommand com = new SqlCommand("themThongBao", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@masv", tb.maSV);
            com.Parameters.AddWithValue("@tieude", tb.tieuDe);
            com.Parameters.AddWithValue("@noidung", tb.noiDung);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
        }

        public hoatdong Find(string id)
        {
            return context.hoatdongs.Find(id);
        }
        #endregion
    }
}