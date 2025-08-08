# 🛍️ MultiShop - Mikroservis Mimarili E-Ticaret Projesi

Bu proje, **ASP.NET Core Mikroservis Mimarisi** üzerine hazırlanmış bir e-ticaret platformudur. Proje, [Udemy'deki Asp.Net Core MultiShop Mikroservis E-Ticaret Kursu] kapsamında geliştirilmiştir.

## 🚀 Proje Amacı

Bu proje ile mikroservis mimarisini gerçek bir e-ticaret senaryosu üzerinde uygulayarak aşağıdaki teknolojilerin kullanımını öğrenmek hedeflenmiştir:

- Servisler arası haberleşme (Sync & Async)
- API Gateway entegrasyonu
- Kimlik doğrulama ve yetkilendirme (OAuth2, IdentityServer)
- RabbitMQ ile Event-Driven mimari
- Docker & Containerization
- Resilience Pattern’lar (Retry, Circuit Breaker)
- PostgreSQL, MongoDB gibi farklı veritabanları ile çalışma

---

## 🧱 Kullanılan Teknolojiler

- **.NET 8 / ASP.NET Core**
- **IdentityServer** – Auth işlemleri
- **Ocelot / YARP** – API Gateway
- **MongoDB** – Katalog servisi
- **PostgreSQL** – Sipariş ve ödeme verileri
- **RabbitMQ** – Event-Driven Architecture
- **Docker** – Tüm servislerin container ile ayağa kaldırılması
- **Dapper & EF Core** – Veri erişimi
- **CQRS / MediatR** – Komut ve sorguların ayrılması
- **Consul / Ocelot / YARP** – Servis keşfi ve yönlendirme
- **AutoMapper** – DTO-Entity dönüşümleri

🧪 Özellikler
✅ Kullanıcı Kaydı & Giriş
✅ Ürün Listeleme ve Kategori Filtreleme
✅ Sepet Yönetimi (Redis)
✅ İndirim Yönetimi (gRPC üzerinden Discount Service)
✅ Sipariş Oluşturma
✅ Ödeme Senaryosu
✅ Sipariş Geçmişi
✅ Admin panel entegrasyonu (opsiyonel)
