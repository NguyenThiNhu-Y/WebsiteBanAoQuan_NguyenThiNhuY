using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class categoryDao
    {
        NguyenThiNhuYContext db;
        public categoryDao()
        {
            db = new NguyenThiNhuYContext();
        }
        public List<tblCategory> getAllCategory(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return db.tblCategories.Where(x => x.id == id).ToList();
            }
            return db.tblCategories.ToList();
        }

    }
}
