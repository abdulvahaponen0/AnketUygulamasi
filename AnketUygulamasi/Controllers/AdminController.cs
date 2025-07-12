using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servis;

namespace AnketUygulamasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;
        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }
        //Admin anket oluşturur
        [HttpPost]
        public async Task<ActionResult> AnketOlustur(Anket anket)
        {
            var (success, mesaj) = await _admin.AnketOlustur(anket);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (success)
            {
                return Ok(anket);
            }
            return StatusCode(500, mesaj);
        } 
    }
}
