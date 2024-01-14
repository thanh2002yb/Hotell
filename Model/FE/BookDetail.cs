namespace Model.FE
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookDetail")]
    public partial class BookDetail
    {
        [Key]
        [Column(Order = 0)]
        public long ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long BookID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
