
using Fiap.Disrupt.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Disrupt.Web.Persistencia
{
    public class DisruptContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DisruptContext(DbContextOptions options) : base(options) { }
    }
}
