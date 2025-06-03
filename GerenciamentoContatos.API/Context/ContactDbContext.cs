using Microsoft.EntityFrameworkCore;
using GerenciamentoContatos.API.Models;

namespace GerenciamentoContatos.API.Persistence
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
