using Global.Dados.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Global.Dados
{
    public class DataContext : DbContext
    {
        public DbSet<Contacto> Contactos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
