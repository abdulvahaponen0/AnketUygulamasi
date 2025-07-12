using DataAccess;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnketTest
{
    public class AnketRepositoryTest
    {
        public DbContextOptions<AnketContext> CreateOptions()
        {
            return new DbContextOptionsBuilder<AnketContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }
        //Anket oluştumak için test
        [Fact]
        public async Task Anket_Olustur()
        {
            //Arrnage
            var options=CreateOptions();
            var context=new AnketContext(options);
            var cevapListesi =new List< Cevaplar> {
                new Cevaplar { Cevap = "Çok kötü" },
                new Cevaplar { Cevap = "Kötü" },
                new Cevaplar { Cevap = "İyi" },
                new Cevaplar { Cevap = "Çok iyi" }
            };
            var sorular = new Sorular { Soru="Galvanizli ürünlerimizde yüzey temizliğini nasıl buluyorsunuz?",cevaplars=cevapListesi};
            var anket = new Anket {Ad="Galvaniz müşteri anketi" ,Tarih=DateTime.Now};
            IAnketRepository anketRepository = new AnketRepository(context);
            //Act
            var(success,mesaj)=await anketRepository.AnketOlustur(anket);
            //Assert
            Assert.True(success);
            Assert.Equal(mesaj, "anket başarılı bir şekilde kaydedildi");
            var result =await context.ankets.FirstOrDefaultAsync();
            Assert.NotNull(result);
            //Assert.Equal(result.Tarih, DateTime.Now);
            Assert.Equal(result.Ad,anket.Ad);
        }
        [Fact]
        public async Task Birden_Fazla_Soru_İle_Anket()
        {
            //Arrange
            var options = CreateOptions();
            var context = new AnketContext(options);
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
            IAnketRepository anketRepository = new AnketRepository(context);
            //Act
            var(success,mesaj)=await anketRepository.AnketOlustur(anket);
            //Assert
            var result = await context.ankets.Include(s => s.sorulars).ThenInclude(c => c.cevaplars).FirstOrDefaultAsync();
            Assert.NotNull(result);
            Assert.Equal(2,result.sorulars.Count());
            Assert.All(result.sorulars, s =>
            {
                Assert.NotEmpty(s.cevaplars);
            });
        }
        [Fact]
        public async Task Kullanici_Oylama_Yapar()
        {
            //Arrange
            var options = CreateOptions();
            var context = new AnketContext(options);
            var kullaniciCevaplari = new List<KullaniciCevaplari> { new KullaniciCevaplari{Cevap="A" },
            new KullaniciCevaplari{Cevap="A"}
            };
            var kullanici = new Kullanici { Ad = "Abdulvahap", Soyad = "Önen" };
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
            var anket = new Anket { Ad = "galvaniz anketi", Tarih = DateTime.Now, sorulars = anketSorulari,kullanicis=new List<Kullanici> { kullanici}  };
            context.ankets.Add(anket);
            await context.SaveChangesAsync();
            IAnketRepository anketRepository=new AnketRepository(context);
            //Act
            var results = new List<(bool success, string mesaj)>();
            foreach (var cevap in kullaniciCevaplari)
            {
                var  result=await anketRepository.OylamaYap(cevap);
                results.Add(result);
            }
            // Assert
            foreach (var result in results)
            {
                Assert.True(result.success, result.mesaj);
            }
            var cevapSayisi = await context.kullaniciCevaplaris.CountAsync();
            Assert.Equal(2, cevapSayisi);

        }
        [Fact]
        public async Task Kullanici_Oylama_Yapar2()
        {
            //Arrange
            var options = CreateOptions();
            var context = new AnketContext(options);
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
            context.ankets.Add(anket);
            await context.SaveChangesAsync();
            IAnketRepository anketRepository = new AnketRepository(context);
            //Act
            var results = new List<(bool success, string mesaj)>();
            foreach (var cevap in kullaniciCevaplari)
            {
                var result = await anketRepository.OylamaYap(cevap);
                results.Add(result);
            }
            // Assert
            foreach (var result in results)
            {
                Assert.True(result.success, result.mesaj);
            }
            var cevapSayisi = await context.kullaniciCevaplaris.CountAsync();
            Assert.Equal(2, cevapSayisi);

             var kullaniciVeritabaninda = await context.kullanicis.Include(k => k.KullaniciCevaplaris)
            .FirstOrDefaultAsync(k => k.Id == kullanici.Id);
                 Assert.Equal(2, kullaniciVeritabaninda.KullaniciCevaplaris.Count);
        }
        [Fact]
        public async Task SonuclarGoster()
        {
            //Arrange
            var options = CreateOptions();
            var context = new AnketContext(options);
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
            await context.ankets.AddAsync(anket);
            await context.SaveChangesAsync();
            IAnketRepository anketRepository=new AnketRepository(context);
            // Act
            var (anket1, success, mesaj) = await anketRepository.SonuclariGöster();

            // Assert
            Assert.True(success);
            Assert.Equal("sonuç başarılı bir şekilde gösterildi.", mesaj);
            Assert.NotNull(anket1);
            Assert.Single(anket1);
            Assert.Equal("galvaniz anketi", anket1[0].Ad);
            var sorularListesi = anket1[0].sorulars.ToList();
            Assert.Equal(2, sorularListesi.Count);
            Assert.Equal(4, sorularListesi[0].cevaplars.Count);
        }
    }
}
