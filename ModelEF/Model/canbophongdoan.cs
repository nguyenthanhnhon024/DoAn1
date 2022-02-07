namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("canbophongdoan")]
    public partial class canbophongdoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public canbophongdoan()
        {
            doanphis = new HashSet<doanphi>();
            sv_hoatdong = new HashSet<sv_hoatdong>();
            thongbaodoans = new HashSet<thongbaodoan>();
        }

        [Key]
        [StringLength(10)]
        public string maCB { get; set; }

        [Required]
        [StringLength(50)]
        public string tenCB { get; set; }

        public bool? gioiTinh { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        [Required]
        [StringLength(20)]
        public string matKhau { get; set; }

        public bool ttCongTac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<doanphi> doanphis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sv_hoatdong> sv_hoatdong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thongbaodoan> thongbaodoans { get; set; }
    }
}
