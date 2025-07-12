using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class Admin : IAdmin
    {
        private readonly IAnketRepository _anketRepository;
        public Admin(IAnketRepository anketRepository)
        {
            _anketRepository = anketRepository;
        }
        public async Task<(bool success, string mesaj)> AnketOlustur(Anket anket)
        {
            return await _anketRepository.AnketOlustur(anket);  
        }
    }
}
