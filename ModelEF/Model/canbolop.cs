namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("canbolop")]
    public partial class canbolop
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Nam { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string maSV { get; set; }

        [StringLength(3)]
        public string chucVu { get; set; }

        public virtual doanvien doanvien { get; set; }
    }
}
