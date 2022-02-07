namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sv_hoatdong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string maSV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string maHD { get; set; }

        public bool tinhTrangDuyet { get; set; }

        public bool thamGia { get; set; }

        [StringLength(10)]
        public string maCBXN { get; set; }

        public virtual canbophongdoan canbophongdoan { get; set; }

        public virtual doanvien doanvien { get; set; }

        public virtual hoatdong hoatdong { get; set; }
    }
}
