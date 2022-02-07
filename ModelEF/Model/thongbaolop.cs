namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("thongbaolop")]
    public partial class thongbaolop
    {
        [Key]
        [StringLength(7)]
        public string maTBLop { get; set; }

        [StringLength(13)]
        public string maSV { get; set; }

        [Required]
        [StringLength(50)]
        public string tieuDe { get; set; }

        [Required]
        [StringLength(2000)]
        public string noiDung { get; set; }

        public DateTime? ngayDang { get; set; }

        public DateTime? ngayCapNhat { get; set; }

        public virtual doanvien doanvien { get; set; }
    }
}
