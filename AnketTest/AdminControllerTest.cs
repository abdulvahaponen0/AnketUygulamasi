using AnketUygulamasi.Controllers;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketTest
{
    public class AdminControllerTest
    {
        [Fact]
        public async Task Anket_Olustur_Controller()
        {
            //Arrnage
            var cevaplar1 = new List<Cevaplar> { new Cevaplar { Cevap="Çok kötü"},
              new Cevaplar{Cevap="Kötü"},
              new Cevaplar{Cevap="İyi"},
              new Cevaplar{Cevap="Çok iyi"}
            };
            var cevaplar2 = new List<Cevaplar> { new Cevaplar { Cevap="Çok kötü"},
              new Cevaplar{Cevap="Kötü"},
              new Cevaplar{Cevap="İyi"},
              new Cevaplar{Cevap="Çok iyi"}
            };
            var anketSorulari = new List<Sorular> { new Sorular { Soru="Galvanizli ürünlerimizde teslimat değerlendirmesini nasıl buluyorsunuz?",cevaplars=cevaplar1},
              new Sorular { Soru="Galvanizli ürünlerimize ait kaplama kalınlığını nasıl buluyorsunuz?",cevaplars=cevaplar2}
            };
            var anket = new Anket { Ad = "Galvaniz anketi", Tarih = DateTime.Now, sorulars = anketSorulari };
            var mockServis = new Mock<IAdmin>();
            mockServis.Setup(servis => servis.AnketOlustur(anket)).ReturnsAsync((true, "anket başarılı bir şekilde kaydedildi"));
            var controller=new AdminController(mockServis.Object);  
            //Act
            var result=await controller.AnketOlustur(anket);
            //Assert
            var okObject = Assert.IsType<OkObjectResult>(result);
            var returnedResult=Assert.IsType<Anket>(okObject.Value);
            Assert.Equal(returnedResult.Ad,anket.Ad);
            Assert.Equal(2, returnedResult.sorulars.Count);
            var sorularListesi=returnedResult.sorulars.ToList();
            Assert.Equal("Galvanizli ürünlerimizde teslimat değerlendirmesini nasıl buluyorsunuz?", sorularListesi[0].Soru);
            var cevaplarListesi = sorularListesi[0].cevaplars.ToList();   
            Assert.Equal(4,cevaplarListesi.Count);
            Assert.Equal("Çok iyi", cevaplarListesi[3].Cevap);
        }
    }
}
