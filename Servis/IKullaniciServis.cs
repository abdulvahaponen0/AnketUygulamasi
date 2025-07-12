using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public interface IKullaniciServis
    {
        public Task<(bool success, string mesaj)> OylamaYap(KullaniciCevaplari kullaniciCevaplari);
        public Task<(List<Anket> ankets, bool success, string mesaj)> SonuclariGoster();
    }
}
