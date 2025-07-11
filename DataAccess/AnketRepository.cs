using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AnketRepository : IAnketRepository
    {
        public Task<(bool success, string mesaj)> AnketOlustur(Anket anket)
        {
            throw new NotImplementedException();
        }
    }
}
