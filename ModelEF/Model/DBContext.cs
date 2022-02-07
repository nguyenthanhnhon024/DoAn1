using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace ModelEF.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        public virtual DbSet<canbolop> canbolops { get; set; }
        public virtual DbSet<canbophongdoan> canbophongdoans { get; set; }
        public virtual DbSet<doanphi> doanphis { get; set; }
        public virtual DbSet<doanvien> doanviens { get; set; }
        public virtual DbSet<hoatdong> hoatdongs { get; set; }
        public virtual DbSet<lop> lops { get; set; }
        public virtual DbSet<phieunhansodoan> phieunhansodoans { get; set; }
        public virtual DbSet<sv_hoatdong> sv_hoatdong { get; set; }
        public virtual DbSet<thongbaodoan> thongbaodoans { get; set; }
        public virtual DbSet<thongbaolop> thongbaolops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<canbolop>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<canbolop>()
                .Property(e => e.chucVu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<canbophongdoan>()
                .Property(e => e.maCB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<canbophongdoan>()
                .Property(e => e.matKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<canbophongdoan>()
                .HasMany(e => e.doanphis)
                .WithOptional(e => e.canbophongdoan)
                .HasForeignKey(e => e.maCBThu);

            modelBuilder.Entity<canbophongdoan>()
                .HasMany(e => e.sv_hoatdong)
                .WithOptional(e => e.canbophongdoan)
                .HasForeignKey(e => e.maCBXN);

            modelBuilder.Entity<canbophongdoan>()
                .HasMany(e => e.thongbaodoans)
                .WithRequired(e => e.canbophongdoan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<doanphi>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<doanphi>()
                .Property(e => e.maCBThu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<doanvien>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<doanvien>()
                .Property(e => e.maLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<doanvien>()
                .Property(e => e.matKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<doanvien>()
                .HasMany(e => e.canbolops)
                .WithRequired(e => e.doanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<doanvien>()
                .HasMany(e => e.doanphis)
                .WithRequired(e => e.doanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<doanvien>()
                .HasMany(e => e.sv_hoatdong)
                .WithRequired(e => e.doanvien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hoatdong>()
                .Property(e => e.maHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<hoatdong>()
                .HasMany(e => e.sv_hoatdong)
                .WithRequired(e => e.hoatdong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lop>()
                .Property(e => e.maLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<lop>()
                .HasMany(e => e.doanviens)
                .WithRequired(e => e.lop)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<phieunhansodoan>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sv_hoatdong>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sv_hoatdong>()
                .Property(e => e.maHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sv_hoatdong>()
                .Property(e => e.maCBXN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<thongbaodoan>()
                .Property(e => e.maTBDoan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<thongbaodoan>()
                .Property(e => e.maCB)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<thongbaolop>()
                .Property(e => e.maTBLop)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<thongbaolop>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
