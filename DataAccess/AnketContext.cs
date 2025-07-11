using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AnketContext : DbContext
    {
        public AnketContext(DbContextOptions<AnketContext> options) : base(options)
        {
            
        }
        public DbSet<Anket> ankets { get; set; }
        public DbSet<Cevaplar> cevaplars { get; set; }
        public DbSet<Sorular> sorulars { get; set; }
    }
}
