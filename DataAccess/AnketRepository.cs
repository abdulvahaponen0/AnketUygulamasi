using Entity;
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
    }
}
