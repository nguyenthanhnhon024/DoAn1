using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.SqlClient;
using System.Data;

namespace ModelEF.Dao
{
    public class ThongBaoLopDao
    {
        public static string cn = @"data source=THANHNHON\SQLEXPRESS;initial catalog=doan;Integrated Security=True";
        SqlConnection conn = new SqlConnection(cn);
        DBContext context = new DBContext();


        #region Thao tác bảng thông tin biên bản
        public List<thongbaolop> ListAll()
        {
            return context.thongbaolops.ToList();
        }

        public IEnumerable<thongbaolop> ListWhereAll(string keysearch)
        {
            IQueryable<thongbaolop> model = context.thongbaolops;
            if (!string.IsNullOrEmpty(keysearch))
                model = model.Where(x => x.tieuDe.Contains(keysearch));
            return model.OrderBy(x => x.ngayDang).ToList();
        }


        public string Insert(thongbaolop entity)
        {
            var sp = Find(entity.maTBLop);
            if (sp == null)
            {
                context.thongbaolops.Add(entity);
            }
            else
            {
                sp.maTBLop = entity.maTBLop;
            }
            context.SaveChanges();
            return entity.maTBLop.ToString();
        }

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

        public thongbaolop Find(string id)
        {
            return context.thongbaolops.Find(id);
        }

        
        public string Edit(thongbaolop entity)
        {
            var sp = Find(entity.maTBLop);
            if (sp == null)
            {
                context.thongbaolops.Add(entity);
            }
            else
            {
                sp.maTBLop = entity.maTBLop;
                sp.maSV = entity.maSV;
                sp.tieuDe = entity.tieuDe;
                sp.noiDung = entity.noiDung;
                sp.ngayDang = entity.ngayDang;
                sp.ngayCapNhat = entity.ngayCapNhat;
            }
            context.SaveChanges();
            return entity.maTBLop.ToString();
        }

        public bool Delete(string id)
        {
            try
            {
                var sp = context.thongbaolops.Find(id);
                context.thongbaolops.Remove(sp);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
