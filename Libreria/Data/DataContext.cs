using Libreria.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
               
        }

        DbSet<Libro> Libros { get; set; }
        DbSet<Autor> Autores { get; set; }
    }
}
