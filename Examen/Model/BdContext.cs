namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BdContext : DbContext
    {
        public BdContext()
            : base("name=BdContext")
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.nombre)
                .IsUnicode(false);
        }
    }
}
