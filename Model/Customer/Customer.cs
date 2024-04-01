using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Customer
{
    public class Customer
    {
        public long ID { set; get; }
        public string Name { set; get; }
        public DateTime? Check_In { get; set; }

        public DateTime? Check_out { get; set; }

        public string Adult { get; set; }

        public int? Number_of_room { get; set; }

        public string Child { get; set; }

        public string Phone { get; set; }



    }
}
