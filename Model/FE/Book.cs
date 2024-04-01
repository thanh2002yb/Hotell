namespace Model.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public long ID { get; set; }

        public long CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        public DateTime? Check_In { get; set; }

        public DateTime? Check_out { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Adult { get; set; }

        public int? Number_of_room { get; set; }

        [StringLength(50)]
        public string Child { get; set; }

        public bool? NonSmoking { get; set; }

        public bool? DoubleBed { get; set; }

        public bool? SingleBed { get; set; }

        public bool? ConnectingRooms { get; set; }

        public bool? FloorPreference { get; set; }

        public int? status { get; set; }
    }
}
