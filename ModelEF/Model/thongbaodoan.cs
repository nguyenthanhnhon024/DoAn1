namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("thongbaodoan")]
    public partial class thongbaodoan
    {
        [Key]
        [StringLength(10)]
        public string maTBDoan { get; set; }

        [Required]
        [StringLength(10)]
        public string maCB { get; set; }

        [Required]
        [StringLength(50)]
        public string tieuDe { get; set; }

        [Required]
        [StringLength(200)]
        public string noiDung { get; set; }

        public DateTime? ngayDang { get; set; }

        public DateTime? ngayCapNhat { get; set; }

        public virtual canbophongdoan canbophongdoan { get; set; }
    }
}
