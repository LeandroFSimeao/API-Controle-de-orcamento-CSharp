using Microsoft.EntityFrameworkCore;
using OrcamentoAPI.Models;

namespace OrcamentoAPI.Data
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> opt) : base(opt)
        {

        }

        public DbSet<Receita> Receitas { get; set; }
    }
}
