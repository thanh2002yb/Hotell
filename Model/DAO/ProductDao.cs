using Model.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ProductDao
    {
        StartHotellDBcontext db = null;
        public ProductDao()
        {
            db = new StartHotellDBcontext();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
