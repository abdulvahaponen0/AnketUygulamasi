using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Anket
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen anket adını yazınız.")]
        [StringLength(maximumLength:20,MinimumLength =3,ErrorMessage ="Lütfen 3 ile 20 karakter arasında değer yazınız.")]  
        public string? Ad { get; set; }
        [Required(ErrorMessage ="Lütfen tarih değerini yazınız.")]
        [DataType(DataType.Date)]
        public DateTime? Tarih { get; set; }
        public ICollection<Sorular>? sorulars { get; set; }
        public ICollection<Kullanici>? kullanicis { get; set; }
    }
}
