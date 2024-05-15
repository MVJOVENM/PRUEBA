using Dapper.Contrib.Extensions;
using System;

namespace DapperProject.Entity
{
    [Table("Libro")]
    public class Libros
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int LibroContador { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
