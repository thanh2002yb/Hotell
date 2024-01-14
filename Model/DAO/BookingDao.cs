using Model.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookingDao
    {
        StartHotellDBcontext db = null;
        public BookingDao()
        {
            db = new StartHotellDBcontext();
        }
        public long Insert(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book.ID;
        }
    }
}
