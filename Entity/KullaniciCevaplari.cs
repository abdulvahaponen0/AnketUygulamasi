using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class KullaniciCevaplari
    {
        public int Id { get; set; }
        public string? Cevap { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici? Kullanici { get; set; }
        public int SorularId { get; set; }
        public Sorular? Sorular { get; set; }
    }
}
