using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class userDao
    {
        private NguyenThiNhuYContext db;
        public userDao()
        {
            db = new NguyenThiNhuYContext();
        }
        public int login(String userName, String passWord)
        {
            var result = db.tblUserAccounts.SingleOrDefault(x => x.UserName == (userName) && x.password==(passWord) );
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == "activated")
                {
                    return 1;
                }
                return -1;
            }
        }
        public IEnumerable<tblUserAccount> getAllUser(string key, int page, int pagesize)
        {
            if (!string.IsNullOrEmpty(key))
                return db.tblUserAccounts.Where(x => x.UserName.Contains(key)).OrderBy(x=>x.UserName).ToPagedList(page, pagesize);
            return db.tblUserAccounts.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
        public tblUserAccount Find(int id)
        {
            return db.tblUserAccounts.Find(id);
        }
        public bool Delete(int id)
        {
            var us = Find(id);
            if (us.status == "blocked")
            {
                db.tblUserAccounts.Remove(us);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
