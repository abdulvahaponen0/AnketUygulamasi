using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketTest
{
    public class AnketRepositoryTest
    {
        public DbContextOptions<AnketContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<AnketContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }
    }
}
