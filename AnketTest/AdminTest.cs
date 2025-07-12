using DataAccess;
using Entity;
using Moq;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnketTest
{
    public class AdminTest
    {
        [Fact]
        public async Task Anket_Olustur_Servis()
        {
            //Arrange
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
            var mockRepo=new Mock<IAnketRepository>();
            mockRepo.Setup(repo => repo.AnketOlustur(anket)).ReturnsAsync((true, "anket başarılı bir şekilde kaydedildi"));
            IAdmin admin=new Admin(mockRepo.Object);
            //Act
            var(success,mesaj)=await admin.AnketOlustur(anket);
            //Assert
            Assert.True(success);
            Assert.Equal(mesaj, "anket başarılı bir şekilde kaydedildi");
        }
    }
}
