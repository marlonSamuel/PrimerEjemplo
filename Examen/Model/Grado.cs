namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Grado")]
    public partial class Grado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grado()
        {
            Alumno = new HashSet<Alumno>();
        }

        public int gradoId { get; set; }

        public string nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alumno> Alumno { get; set; }

        public List<Grado> getAll()
        {
            var list = new List<Grado>();
            try
            {
                using(var ctx = new BdContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    list = ctx.Grado.ToList();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public Grado Obtener(int id)
        {
            var grado = new Grado();
            try
            {
                using(var ctx = new BdContext())
                {
                    grado = ctx.Grado.Where(x => x.gradoId == id).SingleOrDefault();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return grado;
        }

        public bool Save()
        {
            var rpta = false;

            try
            {
                using(var ctx = new BdContext())
                {
                    if (this.gradoId > 0) ctx.Entry(this).State = EntityState.Modified;
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

        public bool Delete(int id)
        {
            var rpta = false;

            try
            {
                using(var ctx = new BdContext())
                {
                    var grado = this.Obtener(id);
                    if(grado != null)
                    {
                        ctx.Entry(grado).State = EntityState.Deleted;
                        ctx.SaveChanges();
                        rpta = true;
                    }
                }
            }catch(Exception ex)
            {
                throw ex;
            }

            return rpta;
        }
    }
}
