using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLNhanVien.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QLNhanVienDB")
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Manv)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Maphong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Phong>()
                .Property(e => e.Maphong)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
