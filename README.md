# 3dlogy - MiniMicroservice

Mini Microservice Mimarisi
Bu proje, modern mikroservis mimarisi kullanılarak oluşturulmuş bir mini mikroservis uygulamasıdır. Proje, farklı teknolojiler ve mimari desenler kullanılarak geliştirilmiş olup, aşağıdaki servisler ve teknolojiler içermektedir.

Servisler ve Teknolojiler

Catalog Service İçerisinde
DDD odaklı Clean Architecture İmplementasyonu: Domain-Driven Design (DDD) yaklaşımıyla temiz mimari uygulaması.

CQRS (Command Query Responsibility Segregation): Komut ve sorgu işlemlerinin ayrıştırılması prensibi.

SOLID ve Clean Code Teknikleri: SOLID prensipleri ve temiz kod yazım teknikleri.

Asenkron Repository İmplementasyonu: Asenkron veri depolama işlemleri.

Dynamic Search İmplementasyonu: Dinamik arama işlemleri.

Response Request Pattern odaklı mapping (Automapper): Otomatik haritalama işlemleri için Automapper kullanımı.

Çoklu ve ilişkili domain modelleme: Birden fazla ve ilişkili domain modellerinin oluşturulması.

Migration İmplementasyonu: Veritabanı geçiş işlemleri.

İş Kuralı ve Clean Code Yazım Teknikleri: İş kurallarının uygulanması ve temiz kod yazım teknikleri.

Global Hata Yönetimi: Global hataların yönetimi ve işlenmesi.

Pipeline Yazım Teknikleri: Pipeline tasarımı ve uygulanması.

Validation Pipeline ile Fluent Validation İmplementasyonu: Fluent Validation kullanarak doğrulama işlemlerinin pipeline içerisine yerleştirilmesi.

Transaction Pipeline İle Transactional Operation İmplementasyonu: İşlem süreçlerinin yönetilmesi ve transactional operation uygulanması.

Caching Pipeline İmplementasyonu: Önbellekleme işlemlerinin pipeline içerisine yerleştirilmesi.

Redis Cache İmplementasyonu: Redis kullanarak önbellekleme işlemlerinin gerçekleştirilmesi.

Logging Pipeline İmplementasyonu: Loglama işlemlerinin pipeline içerisine yerleştirilmesi.

Serilog İmplementasyonu: Serilog kullanarak loglama işlemlerinin gerçekleştirilmesi.

Güvenlik ve JWT İmplementasyonu: JSON Web Token (JWT) kullanarak güvenlik işlemlerinin uygulanması.

Mailing İmplementasyonu: E-posta gönderim işlemlerinin gerçekleştirilmesi.

FilterApi Service İçerisinde
RabbitMQ implementasyonu: RabbitMQ kullanarak mesaj kuyruğu sisteminin uygulanması.

MassTransit İşlemi: MassTransit kullanarak mesaj işlemlerinin yönetilmesi.

Elasticsearch NoSQL: Elasticsearch kullanarak veri dizinleme ve arama işlemlerinin gerçekleştirilmesi.

GatewayOcelot
Ocelot API Gateway: Ocelot kullanarak API geçidi uygulamasının gerçekleştirilmesi.

IdentityService İçerisinde
Duende Identity Server: Duende Identity Server4 teknolojisi kullanarak kimlik doğrulama ve yetkilendirme işlemlerinin gerçekleştirilmesi.

Kurulum ve Kullanım
Bu projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:

Bu repository'yi klonlayın:

bash
git clone https://github.com/kullaniciadi/projeadi.git
cd projeadi
Gerekli paketleri yükleyin:

bash
dotnet restore
RabbitMQ ve Elasticsearch gibi bağımlılıkları başlatın.

Projeyi çalıştırın:

bash
dotnet run
Katkıda Bulunma
Katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir issue açın. Geri bildirimleriniz ve katkılarınız memnuniyetle karşılanır!

Çalışmayı gerçekleştirirken desteklerinden dolayı Gökmen Ada'ya teşekkür ederim.

Çalışmayı alıp kullanabilirsiniz.

![1](https://github.com/user-attachments/assets/50838fc8-b36b-493a-9bd5-8b0bf44893dc)
![2](https://github.com/user-attachments/assets/d9b79bf8-1030-4c30-9d96-c83e73233584)
![3](https://github.com/user-attachments/assets/b3357275-f633-4f72-8587-f07768fec7e9)
![4](https://github.com/user-attachments/assets/50a45922-c388-4433-bb93-3f618008fb6f)
![6](https://github.com/user-attachments/assets/b141be33-8850-48e7-a373-585d85d61945)
![7](https://github.com/user-attachments/assets/62065777-476a-4207-82c1-a286e086640b)
![8](https://github.com/user-attachments/assets/149f5626-13bc-4d11-a300-31dc7fcac422)
![10](https://github.com/user-attachments/assets/c2cdfc8c-2047-441f-a61a-b1ccd0cafb1f)
