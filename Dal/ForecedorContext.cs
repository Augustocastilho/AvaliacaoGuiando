using AvaliacaoGuiando.Models;
using Microsoft.EntityFrameworkCore;

namespace FornecedorCxt.Data
{
    public class FornecedorContext : DbContext
    {
        public FornecedorContext(DbContextOptions<FornecedorContext> options)
            : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedor { get; set; }
    }
}