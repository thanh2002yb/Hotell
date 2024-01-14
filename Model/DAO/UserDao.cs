using Model.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.DAO
{
    public class UserDao
    {
        StartHotellDBcontext db = null;

        public UserDao()
        {
            db = new StartHotellDBcontext();
        }
        public User GetbyID(int id)
        {
           return db.Users.Find(id);
            
        }
        public bool Update(User entity)
        {
            var user = db.Users.Find(entity.ID);
            user.Name = entity.Name;
            user.Password = entity.Password;
            user.ModifedDate = DateTime.Now;
            db.SaveChanges();
            return true;
        }
        public IEnumerable<User> getListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }
        public long Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.ID;
        }
        public User GetByName(string username)
        {
            return db.Users.SingleOrDefault(x => x.UserName == username);
        }
        public int Login(string username ,string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.UserName == username && result.Password == password)
                {
                    return 1;
                }
                else if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    return -2;
                }
            }
        }
    }
}
