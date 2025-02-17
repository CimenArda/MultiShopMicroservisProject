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

