using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class UserDao
    {
        private DBContext db;

        public UserDao()
        {
            db = new DBContext();
        }
        //đăng nhập
        public int login(string user, string pass)
        {
            var result = db.doanviens.SingleOrDefault(x => x.maSV.Contains(user) && x.matKhau.Contains(pass));
            var tt = db.doanviens.FirstOrDefault(x => x.ttHoc == true);
            DateTime now = DateTime.Now;
            var cb = db.canbolops.SingleOrDefault(x => x.maSV.Contains(user) && x.Nam == now.Year);
            if (result == null )
            {
                return 0;
            }
            else if(tt == null)
            {
                return 1;
            }
            else if (cb == null)
            {
                return 2;
            }else
            {
                return 3;
            }
        }
        public doanvien GetBymaSV(string ma)
        {
            return db.doanviens.SingleOrDefault(x => x.maSV == ma);
        }
    }
}
