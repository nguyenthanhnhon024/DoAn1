namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("doanphi")]
    public partial class doanphi
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int namHoc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string maSV { get; set; }

        public bool? SVienNop { get; set; }

        public bool? CDoanNop { get; set; }

        [StringLength(10)]
        public string maCBThu { get; set; }

        public virtual canbophongdoan canbophongdoan { get; set; }

        public virtual doanvien doanvien { get; set; }
    }
}
