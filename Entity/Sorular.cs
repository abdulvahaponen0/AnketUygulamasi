using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Sorular
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen soru değerini yazınız.")]
        [StringLength(maximumLength:30,MinimumLength =5,ErrorMessage ="Lütfen 5 ile 50 karakter arasında değer yazınız.")]
        public string? Soru { get; set; }
        public int AnketId { get; set; }
        public Anket? Anket { get; set; }
        public ICollection<Cevaplar>? cevaplars { get; set; }
    }
}
