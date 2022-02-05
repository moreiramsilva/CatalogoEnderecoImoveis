
using Microsoft.EntityFrameworkCore;
using WebApplicationTeste.Models;

namespace WebApplicationTeste.Data
{
    public class WebApplicationTesteContext : DbContext
    {
        public WebApplicationTesteContext (DbContextOptions<WebApplicationTesteContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogoImovel> CatalogoImovel { get; set; }
    }
}
