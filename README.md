# HealthCareApp
http://46.20.2.187:9090/ Proje demosu yayındadır.fakat redis hostinge yüklenemediğinden kullanıcı girişi canlıda gözükmeyecektir lochalinize veya sunucuya yüklendiğinde söyle bir sorun kalmayacaktır.

Not:Projenin backup dosyası projesinin içerisindedir.Mssql versiyonu 2019 dur.Başka bir versiyonda denendiğinde backup yüklenmesi başarısız olacaktır.Repository katmanında
HealtyCareContext.cs sayfasından configüre ayarını kendi Server adınıza göre değiştirerek projeyi çalıştırabilirsiniz.Ayrıca Lochalde çalıştırmak için redis yüklenmesi gerekmektedir.

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
       7-TestKatmanı:Service Katmanındaki iş akışlarını durumlarını hataları test eden katman.
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
 
 12-Kullanıcı şifre yenileme sayfası hazılama (Mailline yeni bir şifre gönderme işlemi şife sıfırlama)
 
 13-Kullanıcının girmiş olduğu kayıt verilerini güncellebildği kullanıcı ayarları sayfası.
 
 14-Kullanıcı kendi başvuru durumunu  güncellediğinde eşleştiği donörü listeden seçmesini sağlamak. Eşleşen hasta ve donörü ayrı bir tabloda tutup veri analizi çıkartıldı.(AnaSayfa).
 
 15-cshtml sayfalarının altında yazılan javascriptleri wwwroot kısmında sayfaismi.js şeklinde tutmayı sağladık.(Browser  her yenilendiğinde sayfadaki javascriptleri tekrardan yüklemesini önlemek için).
 
 16- TestUnit hazırlandı.
 
 17-Search componentini resuable hale getirildi.

18-Mapto methodu ile modellerin içeriklerinin birbirlerine tek kodla aktarılmasını sağladık(uzun kod satırları yazmamış olduk)


----Projenin Devamında Yapmayı Düşündüğümüz İşler----
 
 1-Soru listesine daha fazla ayrıntı verme evet ise neden açıklama kısımlarının eklenmesi.
 
 2-Kullanıcıların platform üzerinden birbirlerine mesaj gönderebileceği bir yapı hazırlama.(Bildirimler/signalr)
 
 3-Kullanıcıların raporlarının text içeriklerini bir companentle okuyup(pdfpig) rapor içeriğinden arama işleminin gerçekleşmesini sağlamak.Rapor içeriğine göre arama sayfası.
