# HealthCareApp
https://github.com/ozgundgn/HealthCareApp.git

Not:Projenin backup dosyası projesinin içerisindedir.Mssql versiyonu 2019 dur.Başka bir versiyonda denendiğinde backup yüklenmesi başarısız olacaktır.Repository katmanında
HealtyCareContext.cs sayfasından configüre ayarını kendi Server adınıza göre değiştirerek projeyi çalıştırabilirsiniz.

Veritabanı diagram şemasına projenin içerisinden ulaşabilirsiniz.

---Yapılanlar---

1-Projenin veritabanı oluşturuldu.İlgili tabloların ilişkileri tamamlandı. 

2-Projenin Katmanları hazırlandı.

       
       Katmanlar
       ----------------
       1-Core Katmanı:Enetitiy tarafında kullanılar base classlar eklendi.Projenin heryerinde kullanılabilecek methodlar bu katmanda bulunmaktadır.
       2-Entity Katmanı: Entitiy Modellerinin yani tablolarımızın bulunduğu aralarında ilişkilerin barındığı katmandır.
       3-Models Katmanı: UI tarafında kullanılan modellerin ve enumların bulunduğu katmandır.
       4-Repository Katmanı:Linq Sorgularının yazıldığı veritabından veri çekme ,insert ve update işlemlerinin yapıldığı katmandır.HealtyCareContext.cs dosyasında veri tabanı ilişkilerinin (pk,fk,onetomany gibi yapıların)olduğu dosya bulunmaktadır.
       5-Service Katmanı:İş akışlarının olduğu katmandır controller ile repository arasında ki  ara katmandır.
       6-HealtyCareApp:UI Katmanı css,js html projenin arayüzünün bulunduğu katmandır.
       -----------------
       
 3-Projenin katmalarının oluşmasının ardından ilk olarak veri tabanı configürasyonunu hazırladık.
 
 4- UI tarafında donör ve hasta tablolarını listeledik.
 
 5-Kullanıcı Girişi için Session yapısını hazıladık.cookies ve redis cache mantığıyla user tablomuzun verilerine kullanıcı çıkış yapana kadar heryerden erişmeyi sağladık(SessionHelper.DefaultSession)
 
 6-Kullanıcının sisteme kayıt olabilmesi için kullanıcı kayıt sayfasını oluşturduk.
 
 7-Kullanıcının hasta veya donor tipini kayıt olurken aldığımız için başvuru kaydı yaparken soruları ve detayları dinamik olarak başvuru sayfasında değiştirdik.
 
 8-Kullanıcı kendi yaptığı başvurularının listelediği bir sayfa hazırladık.
 
 9-Kullanıcı başvurusunun durumunu değiştirebilir.(iptal(iptal nedeni girişi) ve uygun donör bulundu gibi(bu platformdan mı yoksa baika bir yerden mi belirtme))
 
 10-hasta ve donor listelerinde  hastaların ve donörlerin iletişime geçebilmesi için kayıt olduğu mail adresine mail gönderilmesini sağladık.
 
 11-Kullanıcıların yüklemiş olduğu raporları görüntülendiği sayfayı hazırladık.
 
 
 ---Eksikler---(Yapmayı düşündüğümüz fakat çalıştığımız için yapmaya zamanımızın olmadığı maddeler)
 
 1-Kullanıcı şifre yenileme sayfası hazılama (Mailline yeni bir şifre gönderme işlemi şife sıfırlama)
 
 2-Kullanıcının girmiş olduğu kayıt verilerini güncellebildği kullanıcı ayarları sayfası.
 
 3-Soru listesine daha fazla ayrıntı verme evet ise neden açıklama kısımlarının eklenmesi.
 
 4-Kullanıcıların platform üzerinden birbirlerine mesaj gönderebileceği bir yapı hazırlama.(Bildirimler)
 
 5-Kullanıcı kendi başvuru durumunu  güncellediğinde eşleştiği donörü listeden seçmesini sağlamak. Eşleşen hasta ve donörü ayrı bir tabloda tutup veri analizi çıkarma.(Ayda şu kadar hasta bu platformdan yararlanıp  kendilerine donör bulması,Yüzde olarak dashboardlarda gösterim(yüzde 60 olarak bulunun donörler bu platformdan bulundu gibi))
 
 6-Kullanıcıların raporlarının text içeriklerini bir companentle okuyup(pdfpig) rapor içeriğinden arama işleminin gerçekleşmesini sağlamak.Rapor içeriğine göre arama sayfası.
 
 7-cshtml sayfalarının altında yazılan javascriptleri wwwroot kısmında sayfaismi.js şeklinde tutmayı sağlamak.(Browser  her yenilendiğinde sayfadaki javascriptleri tekrardan yüklemesini önlemek için)
 
 8-Testutil hazırlamak.
 
 9-Bazı componenetleri resuable hale getirmek.
       
       
