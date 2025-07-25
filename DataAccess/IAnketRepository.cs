﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAnketRepository
    {
        public Task<(bool success, string mesaj)> AnketOlustur(Anket anket);
        public Task<(bool success, string mesaj)> OylamaYap(KullaniciCevaplari kullaniciCevaplari);
        public Task<(List<Anket> anket1, bool success, string mesaj)> SonuclariGöster();
    }
}
