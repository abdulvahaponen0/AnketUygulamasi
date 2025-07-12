using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public interface IAdmin
    {
        public Task<(bool success, string mesaj)> AnketOlustur(Anket anket);
    }
}
