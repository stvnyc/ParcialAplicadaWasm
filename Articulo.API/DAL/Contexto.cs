using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Articulo.API.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options) { }

    public DbSet<Articulos> Articulos { get; set; }

}