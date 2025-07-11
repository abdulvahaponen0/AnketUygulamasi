using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cevaplar
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Lütfen cevap değerini yazınız.")]
        [StringLength(maximumLength:30,MinimumLength =5,ErrorMessage ="Lütfen 5 ile 30 arasında karakter yazınız.")]
        public string? Cevap { get; set; }
        public int SorularId { get; set; }
        public Sorular? Sorular { get; set; }
    }
}
