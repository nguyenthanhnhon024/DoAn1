namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phieunhansodoan")]
    public partial class phieunhansodoan
    {
        [Key]
        public int idPhieuNhan { get; set; }

        [StringLength(13)]
        public string maSV { get; set; }

        [Required]
        [StringLength(100)]
        public string liDo { get; set; }

        public DateTime? ngayHen { get; set; }

        public DateTime? ngayPhat { get; set; }

        public virtual doanvien doanvien { get; set; }
    }
}
