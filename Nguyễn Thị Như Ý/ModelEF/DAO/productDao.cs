using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class productDao
    {
        private NguyenThiNhuYContext db;
        public productDao()
        {
            db = new NguyenThiNhuYContext();
        }
        public List<tblProduct> GetAllProducts()
        {
            return db.tblProducts.OrderBy(x=>x.Quantity).ThenByDescending(x=>x.UnitCost).ToList();
        }
        public tblProduct Detail(string id)
        {
            return db.tblProducts.Find(id);
        }
        public void Insert(tblProduct pr)
        {
            try
            {
                db.tblProducts.Add(pr);
                db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        public List<tblProduct> GetAllProducts_Type(string idType)
        {
            return db.tblProducts.Where(x=>x.idCategoryNo == idType).ToList();
        }

    }
}
