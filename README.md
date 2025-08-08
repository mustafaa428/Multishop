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



## 📦 Mikroservis Yapısı

```text
├── ApiGateway
├── IdentityServer
├── Services
│   ├── CatalogService (MongoDB)
│   ├── BasketService (Redis)
│   ├── OrderService (PostgreSQL)
│   ├── DiscountService (gRPC)
│   ├── PaymentService

🧪 Özellikler
✅ Kullanıcı Kaydı & Giriş
✅ Ürün Listeleme ve Kategori Filtreleme
✅ Sepet Yönetimi (Redis)
✅ İndirim Yönetimi (gRPC üzerinden Discount Service)
✅ Sipariş Oluşturma
✅ Ödeme Senaryosu
✅ Sipariş Geçmişi

<img width="1920" height="925" alt="multishop1" src="https://github.com/user-attachments/assets/80a73073-8e15-4af4-8bfa-22d0fb863254" />

<img width="1920" height="965" alt="multishop2" src="https://github.com/user-attachments/assets/82c5dcf5-497f-48b1-a324-fdf0ecae90e0" />

<img width="1920" height="937" alt="multishop3" src="https://github.com/user-attachments/assets/4060eda8-bcf9-45b0-8709-a26476500d7e" />

<img width="1920" height="978" alt="multishop4" src="https://github.com/user-attachments/assets/c6bac150-e767-414b-8146-6fa0841e7437" />



