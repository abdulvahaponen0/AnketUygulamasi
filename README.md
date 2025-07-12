# AnketUygulamasi 🎯

Bu proje, kullanıcıların çevrimiçi anketlere katılabildiği, cevapları oylayabildiği ve sonuçları görüntüleyebildiği bir **.NET Core Web API** uygulamasıdır.

## 🔧 Teknolojiler

- ASP.NET Core Web API
- Entity Framework Core
- MS SQL Server (EF ile)
- xUnit & Moq (Birim Testleri)
- RESTful mimari
- GitHub Actions (varsa CI/CD)

## 📁 Proje Yapısı

AnketUygulamasi/
├── Controllers/ # API controller sınıfları
├── DataAccess/ # Veritabanı context'i ve repository sınıfları
├── Entity/ # Model/varlık sınıfları (Anket, Soru, Cevap, Kullanici vb.)
├── Servis/ # Servis katmanı (iş kuralları)
├── AnketTest/ # xUnit ile birim testleri
└── Program.cs # Giriş noktası

bash
Kopyala
Düzenle

## 🚀 Başlarken

Projeyi çalıştırmak için aşağıdaki adımları izleyin:

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/abdulvahaponen0/AnketUygulamasi.git
cd AnketUygulamasi
2. Bağımlılıkları Yükleyin
bash
Kopyala
Düzenle
dotnet restore
3. Veritabanı Oluşturun
appsettings.json dosyasındaki bağlantı cümlesini kendi ortamınıza göre güncelleyin ve ardından:

bash
Kopyala
Düzenle
dotnet ef database update
4. Uygulamayı Çalıştırın
bash
Kopyala
Düzenle
dotnet run
API varsayılan olarak https://localhost:5001 veya http://localhost:5000 adreslerinden çalışacaktır.

🧪 Test Çalıştırma
bash
Kopyala
Düzenle
cd AnketTest
dotnet test
🧱 Özellikler
✅ Anket oluşturma (Admin)

✅ Kullanıcılar için oylama

✅ Anket sonuçlarını görüntüleme

✅ Hata yönetimi ve başarılı/başarısız mesajları

✅ Birim testleri ile güvenilirlik

📬 İletişim
Geliştirici: Abdulvahap Önen
📧 E-posta: abdulvahaponen0@gmail.com
🔗 GitHub: github.com/abdulvahaponen0
