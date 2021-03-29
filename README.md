# ReCapProject
Yazılım Geliştirici Yetiştirme Kampı Rent A Car Projesi

RECAP PROJECT BACK-END
Yazılım Geliştirici Yetiştirme Kampı boyunca kampla beraber paralelde geliştirdiğimiz Rent A Car Projesi.
Katmanlı mimariye tamamen uygun olarak geliştirilmiştir. 
Katmanlı Mimari
•	Core
•	Entities – Core katmanını referans alır.
•	DataAccess – Core ve Entities katmanlarını referans alır.
•	Business – DataAccess ve Entities katmanlarını referans alır.
•	Web API – Core, Entities, DataAccess ve Business katmanlarını referans alır.

Core
Core katmanı bütün projelerde kullanılabilecek temel bir altyapıdır.
-	Entities 
IEntity ve IDto interface’ lerini içerir. Bu interfaceler kendisini inherit eden nesnelerin bir veritabanı tablosu olduğunu imzalamak amacıyla kullanılır. 
-	DataAccess
Bu klasörde tüm Entity’ lerin ortak CRUD operasyonlarının belirlendiği generic  IEntityRepository interface’ ini bulunur.
-	EntityFramework
Bu klasörde ise IEntityRepository interface’ inde belirtilen CRUD operasyonları EntityFramework kullanılarak gerçekleştirilir.
-	Utilities
Bu klasör projelerde isteğe göre kullanabileceğimiz araçları bulundurur.
-	Results
Bu klasörde isteğe bağlı olarak void döndürmek yerine yapılan işlem başarılı ya da başarısızsa true yada false ve mesajını döndürebileceğimiz altyapı oluşturuldu.
Ya da sadece bir data döndürmek yerine datayla beraber o işleme karşılık gelen bir mesaj ve işlemin başarılı olup olmadığını döndürebileceğimiz altyapı oluşturuldu.

Entities 
Entities katmanında veritabanında bulunan tabloları projede karşılamak için model oluşturulur. Bu modeller Core katmanında Entities altında bulunan IEntity interface’ ini inherit ederler. Bunun sebebi entities modellerinin birer veritabanı tablosu olduğunu imzalamaktır.
-	Concrete
Entity Nesnelerinin Property’ leri
•	Brand.cs – Id ve Name
•	Car.cs – Id, BrandId, ColorId, ModelYear, DailyPrice ve Description
•	Color.cs – Id ve Name
•	Customer.cs – Id, UserId ve CompanyName
•	Rental.cs – Id, CarId, CustomerId, RentDate ve ReturnDate
•	User.cs – Id, FirstName, LastName, Email, Password
Bu Entity nesneleri aynı zamanda Visual Studio’ nun içinde bulunan Sql Server tarafında veritabanı tabloları olarak oluşturulmuştur.
-	DTOs
•	CarDetailDto.cs – Id, BrandName, ColorName, ModelYear, DailyPrice, Description
•	CustomerDetailDto.cs – Id, UserFirstName, UserLastName, CompanyName
•	RentalDetailDto.cs – Id, BrandName, ColorName, CompanyName, FirstName, LastName, RentDate, ReturnDate
Bu DTO nesneleri kullanıcıya Entity nesnelerindeki propertylerinde bulunan Id’ ler yerine onların isimlerini göstermemizi sağlayan model yapısıdır. Örneğin kullanıcıya Car Entity’ sinde bulunan BrandId ve ColorId göstermek yerine BrandName ve ColorName göstermek istediğimizde bu DTO nesnesi modelini kullanırız.


DataAccess
Bu katman sadece veriye erişim için kullanılır.
-	Abstract
Bu klasörde Dal interfaceleri bulunur. Bu interfaceler Core katmanındaki IEntityRepository<T> generic interface’ ini inherit ederler. Böylece her nesne için aynı olan CRUD operasyonları tek çatı altında gerçekleştirilmiş olur. Eğer nesne diğer nesnelerden ayrı CRUD operasyonlarına sahip ise burada belirlenir.
-	Concrete
-	EntityFramework
Bu klasörde diğer nesnelerden ayrı Dal operasyonlarına sahip nesnelerin operasyonları burada gerçekleştirilir. Örneğin CarDetailDto için 3 tablonun join işlemi ve ona uygun Dto döndürülmesi burada gerçekleştirilir.
-	Ayrıca EntityFramework için veritabanı connectionString’ i yani contexti de burada bulunur. Aynı zamanda veritabanı ile Entity nesnelerinin DbSet ilişkilendirilmesi de burada gerçekleştirilir.

Business
Bu katman iş kodlarının ve iş kurallarının bulunduğu katmandır. 
-	Abstract
Bu klasörde nesnelerin sahip olduğu bütün serviceleri belirlenir.
-	Concrete
Bu klasörde ise manager’ lar bulunur. Ait olduğu service’ ini inherit alır ve iş kurallarına göre operasyonlar gerçekleştirilir. 
-	Constants
Bu klasörde ise Core katmanı altında Utilities altında kurmuş olduğumuz Results altyapısıyla beraber kullanacağımız mesaj field’ ları bulunur.


Web API
Bu katman, projenin, Angular tabanlı front-end web projesi ile etkileşim kurmasını sağlayan katmandır.
-	Controllers
Bu klasör ilgili Entity’ nin Business katmanındaki tüm service’ lerini kullanarak web projesi ile etkileşim kurmasını sağlayan HttpGet ve HttpPost requestlerini gerçekleştirir.
-	Startup.cs
Gerekli configuration’ ların yapıldığı dosyadır.

