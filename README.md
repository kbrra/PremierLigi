# ⚽ Premier Ligi Yönetim Sistemi

İngiltere Premier Ligi maçlarını, takımlarını ve istatistiklerini yönetmek için geliştirilmiş full-stack web uygulaması.

## 🖥️ Teknolojiler

- **Backend:** ASP.NET Core Web API (.NET 6)
- **Frontend:** ASP.NET Core MVC (.NET 6)
- **Veritabanı:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Mimari:** N-Layer (WebApi + WebUI)

## 📋 Özellikler

### 🌐 Public Site
- Anlık puan durumu (galibiyet/beraberlik/mağlubiyet hesabı)
- Fikstür sayfası (tamamlanan, canlı, yaklaşan maçlar)
- Maç detay sayfası (olaylar + istatistikler)
- Takımlar sayfası

### 🔧 Admin Paneli
- Maç ekleme / güncelleme / silme
- Takım yönetimi
- Maç olayı girişi (gol, kart, değişiklik)
- Maç istatistikleri girişi
- Sezon, stadyum, hakem, maç haftası yönetimi

## 🗄️ Veritabanı Tabloları

| Tablo | Açıklama |
|-------|----------|
| Teams | Takım bilgileri |
| Matches | Maç/Fikstür bilgileri |
| MatchEvents | Maç olayları (gol, kart, değişiklik) |
| MatchStatistics | Maç istatistikleri |
| Seasons | Sezon bilgileri |
| Stadiums | Stadyum bilgileri |
| Referees | Hakem bilgileri |
| GameWeeks | Maç haftaları |

## 🚀 Kurulum

### Gereksinimler
- Visual Studio 2022+
- .NET 6 SDK
- SQL Server / SQL Server Express

### Adımlar

1. Repoyu klonla:
```bash
git clone https://github.com/kbrra/PremierLigi.git
```

2. `PremierLigi.WebApi` klasöründe `appsettings.example.json` dosyasını kopyala ve `appsettings.json` olarak kaydet:
```bash
cp appsettings.example.json appsettings.json
```

3. `appsettings.json` içindeki connection string'i kendi SQL Server bilgilerinle güncelle:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER; initial Catalog=PremierLigi; integrated Security=true"
  }
}
```

4. Package Manager Console'da migration'ı uygula:
```
update-database
```

5. Her iki projeyi de başlat (Set Startup Projects → Multiple startup projects).

## 🔗 API Endpoint'leri

| Method | URL | Açıklama |
|--------|-----|----------|
| GET | /api/Match | Tüm maçlar |
| GET | /api/Match/Standings | Puan durumu |
| GET | /api/Match/GetMatch?id={id} | Maç detayı |
| POST | /api/Match | Maç ekle |
| PUT | /api/Match | Maç güncelle |
| DELETE | /api/Match?id={id} | Maç sil |
| GET | /api/MatchEvent/GetByMatch?matchId={id} | Maç olayları |
| GET | /api/MatchStatistics/GetByMatch?matchId={id} | Maç istatistikleri |
| GET | /api/Team | Tüm takımlar |

## 👩‍💻 Geliştirici

GitHub: [@kbrra](https://github.com/kbrra)
