using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public ICollection<KullaniciCevaplari>? KullaniciCevaplaris { get; set; }
        public int AnketId { get; set; }
        public Anket? Anket { get; set; }
    }
}
