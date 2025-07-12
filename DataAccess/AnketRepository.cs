using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AnketRepository : IAnketRepository
    {
		private readonly AnketContext _context;
        public AnketRepository(AnketContext context)
        {
            _context = context;
        }
        public async Task<(bool success, string mesaj)> AnketOlustur(Anket anket)
        {
			try
			{
                await _context.ankets.AddAsync(anket);
                await _context.SaveChangesAsync();
                return (true, "anket başarılı bir şekilde kaydedildi");
			}
			catch (Exception ex)
			{
                return (false, $"Hata:{ex.Message}");
			}
        }

        public async Task<(bool success, string mesaj)> OylamaYap(KullaniciCevaplari kullaniciCevaplari)
        {
            try
            {
                await _context.kullaniciCevaplaris.AddAsync(kullaniciCevaplari);
                await _context.SaveChangesAsync();
                return (true, "kullanicinin cevapları başarılı bir şekilde kaydedildi.");
            }
            catch (Exception ex)
            {
                return (false, $"Hata:{ex.Message}");
            }
        }

        public async Task<(List<Anket> anket1,bool success,string mesaj)> SonuclariGöster()
        {
            try
            {
                var anket =await _context.ankets.ToListAsync();
                return (anket,true,"sonuç başarılı bir şekilde gösterildi.");
            }
            catch (Exception ex)
            {
                return (null, false, $"Hata: {ex.Message}");
            }
        }
    }
}
