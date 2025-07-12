using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servis;

namespace AnketUygulamasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IKullaniciServis _kullaniciServis;
        public KullaniciController(IKullaniciServis kullaniciServis)
        {
            _kullaniciServis = kullaniciServis;
        }
        //Kullanici oylama yapar
        [HttpPost]
        public async Task<ActionResult> OylamaYap(KullaniciCevaplari kullaniciCevaplari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var (success, mesaj) = await _kullaniciServis.OylamaYap(kullaniciCevaplari);
            if (success)
            {
                return Ok(kullaniciCevaplari);
            }
            return StatusCode(500, mesaj);
        }
        //Sonuçları listeler
        [HttpGet]
        public async Task<ActionResult> SonuclariGoster()
        {
            var sonuclar=await _kullaniciServis.SonuclariGoster();
            if (!sonuclar.success)
            {
                return NotFound();
            }
            return Ok(sonuclar);
        } 
    }
}
