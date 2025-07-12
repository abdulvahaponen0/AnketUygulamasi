using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class KullaniciServis : IKullaniciServis
    {
        private readonly IAnketRepository _anketRepository;
        public KullaniciServis(IAnketRepository anketRepository)
        {
                _anketRepository = anketRepository;
        }
        public async Task<(bool success, string mesaj)> OylamaYap(KullaniciCevaplari kullaniciCevaplari)
        {
            return await _anketRepository.OylamaYap(kullaniciCevaplari);
        }

        public async Task<(List<Anket> ankets, bool success, string mesaj)> SonuclariGoster()
        {
            return await _anketRepository.SonuclariGöster();
        }
    }
}
