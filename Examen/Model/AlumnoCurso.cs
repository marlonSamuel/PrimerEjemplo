namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("AlumnoCurso")]
    public partial class AlumnoCurso
    {
        public int alumnoCursoId { get; set; }

        public int? alumnoId { get; set; }

        public int? cursoId { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }

        public List<AlumnoCurso> getAll()
        {
            var list = new List<AlumnoCurso>();
            try
            {
                using(var ctx = new BdContext())
                {
                    list = ctx.AlumnoCurso.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public bool save(int idAlumno, List<int> cursoId)
        {
            var rpta = false;

            try
            {
                using(var ctx = new BdContext())
                {
                   foreach(var l in cursoId)
                    {
                        var asignacion = new AlumnoCurso
                        {
                            alumnoId = alumnoId,
                            cursoId = l
                        };

                        ctx.AlumnoCurso.Add(asignacion);
                        ctx.SaveChanges();
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
