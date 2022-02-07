namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoatdong")]
    public partial class hoatdong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoatdong()
        {
            sv_hoatdong = new HashSet<sv_hoatdong>();
        }

        [Key]
        [StringLength(10)]
        public string maHD { get; set; }

        [Required]
        [StringLength(50)]
        public string tenHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayBatDauDK { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayKetThucDK { get; set; }

        public int soLuong { get; set; }

        public int Diem { get; set; }

        [Required]
        [StringLength(2000)]
        public string noiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngayBatDauHD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sv_hoatdong> sv_hoatdong { get; set; }
    }
}
