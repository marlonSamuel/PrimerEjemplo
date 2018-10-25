namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        public int cursoId { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }


        //metodo para guardar curso
        public List<Curso> Listar()
        {
            var list = new List<Curso>();
            try
            {
                using(var ctx = new BdContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    list = ctx.Curso.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return list;
        }

        public bool Save()
        {
            var rpta = false;
            try
            {
                using(var ctx = new BdContext())
                {
                    if (this.cursoId > 0) ctx.Entry(this).State = EntityState.Modified;
                    else ctx.Entry(this).State = EntityState.Added;
                    ctx.SaveChanges();
                    rpta = true;

                }
            }
            catch(Exception e)
            {
                throw e;
            }

            return rpta;
        }

        public Curso Obtener(int id)
        {
            var curso = new Curso();
            try
            {
                using(var ctx = new BdContext())
                {
                    curso = ctx.Curso.Where(x => x.cursoId == id).SingleOrDefault();
                }
                
            }catch(Exception e)
            {
                throw e;
            }

            return curso;
        }

        public bool Delete(int id)
        {
            var rpta = false;
            try
            {
                using(var ctx = new BdContext())
                {
                    var curso = ctx.Curso.Where(x => x.cursoId == id).SingleOrDefault();

                    ctx.Entry(curso).State = EntityState.Deleted;
                    ctx.SaveChanges();
                    rpta = true;
                }
            }catch(Exception e)
            {
                throw e;
            }

            return rpta;
        }

    }
}
