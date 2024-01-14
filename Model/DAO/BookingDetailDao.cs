using Model.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookingDetailDao
    {
        StartHotellDBcontext db = null;
        public BookingDetailDao()
        {
            db = new StartHotellDBcontext();
        }
        public bool Insert(BookDetail detail)
        {
            try
            {
                db.BookDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
