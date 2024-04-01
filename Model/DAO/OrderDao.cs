using Model.FE;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDao
    {
        StartHotellDBcontext db = null;

        public OrderDao()
        {
            db = new StartHotellDBcontext();
        }

        public List<Book> getListAllPaging()
        {
            return db.Books.ToList();
        }
        public bool Delete(int id)
        {
            var order = db.Books.Find(id);
            db.Books.Remove(order);
            db.SaveChanges();
            return true;
        }
        public List<Book> getListAllPagingg()
        {
            var model = (from a in db.Books
                         join b in db.Users on a.CustomerID equals b.ID
                         select new
                         {
                             a.CustomerName,
                             a.Check_In,
                             a.Check_out,
                             a.Adult,
                             a.Child,
                             b.Phone
                         }).ToList()
                .Select(x => new Book
                {
                    CustomerName = x.CustomerName,
                    Check_In = x.Check_In,
                    Check_out = x.Check_out,
                    Adult = x.Adult,
                    Child = x.Child,
                    Phone = x.Phone
                }).ToList();
            return model;
        }


    }
}

