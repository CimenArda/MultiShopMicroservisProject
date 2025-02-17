# MultiShop - Mikroservis Tabanlı E-Ticaret Platformu

MultiShop, kullanıcıların oturum açarak veya ziyaretçi olarak giriş yapabildiği, ürün arama, listeleme ve alışveriş yapma imkanı sunan kapsamlı bir e-ticaret platformudur.

## 🚀 Projeye Genel Bakış
### 🖥️ Yönetim Paneli
- Ürün, kategori ve marka işlemlerinin yönetilebildiği kapsamlı bir admin paneli.
- Sepet yönetimi, sipariş takibi ve kullanıcı yönetimi.

### 👤 Kullanıcı Arayüzü
- Modern ve kullanıcı dostu bir tasarım.
- Ürün arama, listeleme, sepete ekleme ve sipariş oluşturma özellikleri.
- Ürün detay sayfaları ve sepet yönetimi.
- Localization desteği ile çoklu dil seçeneği.

### 🧑‍💻 Kullanıcı Paneli
- Kullanıcıların siparişlerini görüntüleme ve takip etme.
- Admin ile mesajlaşma ve iletişim kurma.

## 🛠️ Teknolojik Altyapı
Bu proje, **ASP.NET Core 6.0** ile geliştirilmiş olup **mikroservis tabanlı** bir mimariye sahiptir. **N katmanlı ve Onion mimarisi** ile yapılandırılmış, modern yazılım desenleri kullanılmıştır.

**Öne çıkan teknolojiler:**
- **Güvenlik:** Identity Server ve JWT (JSON Web Token).
- **Veritabanları:** MSSQL, MongoDB, Redis, PostgreSQL.
- **API:** Swagger dokümantasyonu, Postman testleri.
- **İletişim:** Ocelot Gateway ile API yönlendirme, RabbitMQ mesajlaşma.
- **Ölçeklenebilirlik:** Docker tabanlı veritabanı yönetimi.
- **Dış Servis Entegrasyonu:** RapidAPI ile çeşitli veriler çekilerek sistemde kullanılmıştır.
- **Dil Desteği:** Localization entegrasyonu ile farklı dillerde içerik sunulmuştur.

## 💻 Kullanılan Teknolojiler
### Backend
- ASP.NET Core 6.0 Web API
- MSSQL, MongoDB, Redis, PostgreSQL
- Dapper, Entity Framework Code First
- CQRS, Mediator, Repository Design Pattern
- IdentityServer4, JWT
- Ocelot Gateway
- SignalR
- Docker
- RabbitMQ
- Google Cloud Storage
- RapidAPI

### Frontend
- HTML, CSS, JavaScript, Bootstrap

## 🔗 Mikroservisler ve Veritabanı Kullanımı
| Mikroservis | Kullanılan Veritabanı |
|-------------|----------------------|
| Basket | Redis |
| Cargo | MSSQL |
| Catalog | MongoDB |
| Comment | MSSQL |
| Discount | MSSQL (Dapper) |
| Images | Local SQL |
| Message | PostgreSQL |
| Order | MSSQL |
| Identity | MSSQL |

## 📌 Teknik Özellikler
- **Ziyaretçi veya Kullanıcı Girişi:** Identity Server ile kimlik doğrulama.
- **N-Tier & Onion Architecture:** Katmanlı yapı ile sürdürülebilir mimari.
- **CQRS & Mediator & Repository Design Pattern:** Veri yönetiminde modern yaklaşımlar.
- **SignalR ile Canlı Veri Takibi:** Gerçek zamanlı güncellemeler.
- **Redis ile Sepet Yönetimi:** Hızlı ve optimize sepet işlemleri.
- **Docker ile Mikroservis Yönetimi:** Servislerin kolay yönetimi.
- **Google Cloud Storage ile Ürün Görselleri:** Bulut tabanlı depolama entegrasyonu.

Bu proje, **ölçeklenebilir, güvenli ve yönetilebilir bir e-ticaret platformu** oluşturmak için geliştirilmiş olup **mikroservis mimarisi ve modern yazılım teknikleri** kullanılarak inşa edilmiştir.


![Ekran görüntüsü 2025-02-16 152144](https://github.com/user-attachments/assets/ce3964bb-db4c-49e7-89db-934a3b0b63ea)
![Ekran görüntüsü 2025-02-16 152247](https://github.com/user-attachments/assets/0a377fa1-7fb7-4855-a1d7-b45be1a86d4e)
![Ekran görüntüsü 2025-02-16 152305](https://github.com/user-attachments/assets/a4797a98-e24f-4f7e-83d9-1c8107181476)
![Ekran görüntüsü 2025-02-16 152335](https://github.com/user-attachments/assets/6aa33b4b-4a26-4228-8b4d-5e6c5a93ceb1)
![Ekran görüntüsü 2025-02-16 152413](https://github.com/user-attachments/assets/78d143a3-e120-4783-a72c-4999c089985b)
![Ekran görüntüsü 2025-02-16 152440](https://github.com/user-attachments/assets/3f2cf16d-29b4-4ef8-98a1-623f4f7d3fdc)
![Ekran görüntüsü 2025-02-16 152459](https://github.com/user-attachments/assets/1aba3a73-844f-4947-b55a-75dbf711a54e)
![Ekran görüntüsü 2025-02-16 152523](https://github.com/user-attachments/assets/7e753d68-b0d3-47ff-9b95-d3dd67e3f287)
![Ekran görüntüsü 2025-02-16 152627](https://github.com/user-attachments/assets/106bfa0c-a872-4a03-8eb9-1472b39787c4)
![Ekran görüntüsü 2025-02-16 153105](https://github.com/user-attachments/assets/7159d0e7-0e35-4e87-a550-ad88c757722e)
![Ekran görüntüsü 2025-02-16 153414](https://github.com/user-attachments/assets/bbec1237-9307-4b97-a02f-b839554e68f0)
![Ekran görüntüsü 2025-02-16 153448](https://github.com/user-attachments/assets/52c69fd0-f064-4aac-bba6-60f4d9d1cbde)
