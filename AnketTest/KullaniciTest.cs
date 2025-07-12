using AnketUygulamasi.Controllers;
using DataAccess;
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
    public class KullaniciTest
    {
        [Fact]
        public async Task Oylama_Yap_Servis()
        {
            //Arrange
            var kullanici = new Kullanici { Ad = "Abdulvahap", Soyad = "Önen" };
            var kullaniciCevaplari = new List<KullaniciCevaplari> { new KullaniciCevaplari{Cevap="A",Kullanici=kullanici},
            new KullaniciCevaplari{Cevap="A",Kullanici=kullanici}
            };
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
            var anket = new Anket { Ad = "galvaniz anketi", Tarih = DateTime.Now, sorulars = anketSorulari, kullanicis = new List<Kullanici> { kullanici } };
            var mockRepo = new Mock<IAnketRepository>();
            foreach (var cevap in kullaniciCevaplari)
            {
                mockRepo.Setup(repo => repo.OylamaYap(cevap)).ReturnsAsync((true, "kullanicinin cevapları başarılı bir şekilde kaydedildi."));
            }
            IKullaniciServis kullaniciServis=new KullaniciServis(mockRepo.Object);  
            //Act
            var results = new List<(bool success, string mesaj)>();
            foreach (var cevap in kullaniciCevaplari)
            {
                var result = await kullaniciServis.OylamaYap(cevap);
                results.Add(result);
            }
            // Assert
            foreach (var result in results)
            {
                Assert.True(result.success, result.mesaj);
                Assert.Equal("kullanicinin cevapları başarılı bir şekilde kaydedildi.", result.mesaj);
                Assert.NotNull(result);

            }
            Assert.Collection(results,
             item => Assert.True(item.success),
             item => Assert.True(item.success)
             );
        }
        [Fact]
        public async Task Oylama_Yap_Controller()
        {
            //Arrange
            var kullanici = new Kullanici { Ad = "Abdulvahap", Soyad = "Önen" };
            var kullaniciCevaplari = new List<KullaniciCevaplari> { new KullaniciCevaplari{Cevap="A",Kullanici=kullanici},
            new KullaniciCevaplari{Cevap="A",Kullanici=kullanici}
            };
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
            var anket = new Anket { Ad = "galvaniz anketi", Tarih = DateTime.Now, sorulars = anketSorulari, kullanicis = new List<Kullanici> { kullanici } };
            var mockServis = new Mock<IKullaniciServis>();
            foreach (var cevap in kullaniciCevaplari)
            {
                mockServis.Setup(servis => servis.OylamaYap(cevap)).ReturnsAsync((true, "kullanicinin cevapları başarılı bir şekilde kaydedildi."));
            }
            var kullaniciController=new KullaniciController(mockServis.Object);
            //Act
            var results = new List<KullaniciCevaplari>();
            foreach (var cevap in kullaniciCevaplari)
            {
                var actionResult = await kullaniciController.OylamaYap(cevap);

                // Controller başarılıysa, OkObjectResult beklenir
                var okResult = Assert.IsType<OkObjectResult>(actionResult);

                // Dönen cevabın orijinal KullaniciCevaplari nesnesi olup olmadığını kontrol et
                var returnedValue = Assert.IsType<KullaniciCevaplari>(okResult.Value);
                Assert.Equal(cevap.Cevap, returnedValue.Cevap);
                Assert.Equal(cevap.Kullanici.Ad, returnedValue.Kullanici.Ad);
                Assert.Equal(cevap.Kullanici.Soyad, returnedValue.Kullanici.Soyad);
            }
        }
        [Fact]
        public async Task Sonucu_Goster_Servis()
        {
            var kullanici = new Kullanici { Ad = "Abdulvahap", Soyad = "Önen" };
            var kullaniciCevaplari = new List<KullaniciCevaplari> { new KullaniciCevaplari{Cevap="A",Kullanici=kullanici},
            new KullaniciCevaplari{Cevap="A",Kullanici=kullanici}
            };
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
            var anket = new Anket { Ad = "galvaniz anketi", Tarih = DateTime.Now, sorulars = anketSorulari, kullanicis = new List<Kullanici> { kullanici } };
            var mockRepo=new Mock<IAnketRepository>();
            mockRepo.Setup(repo => repo.SonuclariGöster()).ReturnsAsync((new List<Anket> { anket }, true, "sonuç başarılı bir şekilde gösterildi."));
            IKullaniciServis kullaniciServis=new KullaniciServis(mockRepo.Object);
            //Act
            var (anket1, success, mesaj) =await kullaniciServis.SonuclariGoster();
            //Assert
            Assert.True(success);
            Assert.Equal(mesaj, "sonuç başarılı bir şekilde gösterildi.");
            Assert.Equal(anket1.Count, 1);
            Assert.Equal(anket1[0].sorulars.Count, 2);
            var sorularListesi = anket1[0].sorulars.ToList();
            Assert.Equal("Galvanizli ürünlerimizde teslimat değerlendirmesini nasıl buluyorsunuz?", sorularListesi[0].Soru);
            Assert.Equal(2, sorularListesi.Count);
            Assert.Equal(4, sorularListesi[0].cevaplars.Count);
        }
        [Fact]
        public async Task Sonuclari_Goster_Controller()
        {
            var kullanici = new Kullanici { Ad = "Abdulvahap", Soyad = "Önen" };
            var kullaniciCevaplari = new List<KullaniciCevaplari> { new KullaniciCevaplari{Cevap="A",Kullanici=kullanici},
            new KullaniciCevaplari{Cevap="A",Kullanici=kullanici}
            };
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
            var anket = new Anket { Ad = "galvaniz anketi", Tarih = DateTime.Now, sorulars = anketSorulari, kullanicis = new List<Kullanici> { kullanici } };
            var mockServis=new Mock<IKullaniciServis>();
            mockServis.Setup(servis => servis.SonuclariGoster()).ReturnsAsync((new List<Anket> { anket }, true, "sonuç başarılı bir şekilde gösterildi."));
            foreach (var cevap in kullaniciCevaplari)
            {
                mockServis.Setup(servis => servis.OylamaYap(cevap)).ReturnsAsync((true, "kullanicinin cevapları başarılı bir şekilde kaydedildi."));
            }
            var kullaniciController=new KullaniciController(mockServis.Object);
            //Act
            var result=await kullaniciController.SonuclariGoster();
            //Assert
            var okObject=Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<(List<Anket>, bool, string)>(okObject.Value);
            Assert.True(returnedResult.Item2);
            Assert.Equal("sonuç başarılı bir şekilde gösterildi.", returnedResult.Item3);
            Assert.Single(returnedResult.Item1); // 1 anket var
            Assert.Equal("galvaniz anketi", returnedResult.Item1[0].Ad); // anket adı doğru mu
        }
    }
}
