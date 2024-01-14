using Model.FE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDao
    {
        StartHotellDBcontext db = null;
        public MenuDao()
        {
            db = new StartHotellDBcontext();
        }
        public List<Menu> GetListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

    }
}
