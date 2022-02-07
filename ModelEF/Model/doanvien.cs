namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("doanvien")]
    public partial class doanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public doanvien()
        {
            canbolops = new HashSet<canbolop>();
            doanphis = new HashSet<doanphi>();
            phieunhansodoans = new HashSet<phieunhansodoan>();
            sv_hoatdong = new HashSet<sv_hoatdong>();
            thongbaolops = new HashSet<thongbaolop>();
        }

        [Key]
        [StringLength(13)]
        public string maSV { get; set; }

        [Required]
        [StringLength(50)]
        public string tenSV { get; set; }

        [Required]
        [StringLength(15)]
        public string maLop { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        public bool? gioiTinh { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        [Required]
        [StringLength(20)]
        public string matKhau { get; set; }

        public bool ttSoDoan { get; set; }

        public bool ttHoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<canbolop> canbolops { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doanphi> doanphis { get; set; }

        public virtual lop lop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phieunhansodoan> phieunhansodoans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sv_hoatdong> sv_hoatdong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thongbaolop> thongbaolops { get; set; }
    }
}
