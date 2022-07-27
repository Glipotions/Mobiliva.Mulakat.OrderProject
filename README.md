# Mobiliva.Mulakat.OrderProject


Mobiliva.Mulakat Projesi: İstenilenlerin hepsi yapıldı MemoryCache için iki yapınında altyapısı kuruldu hangisi istenirse o kullanılabilir. İstenilenlere ek olarak Performans yönetimini sağlayan aspect ,Transaction ve Validation yapmayı sağlayan yapılar eklendi. 
	Redis: Core Katmanı, CrossCuttingConcerns, Caching içinde
	Serilog: Core Katmanı -> CrossCuttingConcerns -> Logging
	RabbitMq: Core Katmanı -> Utilities -> MessageBrokers
	AutoMapper: Business Katmanı -> AutoMapperProfile


## İÇERİK
-Entities: Bu katmanda Entityler ve Dtoları bulunmakta, Ayrıca CreateOrderRequestDto da Dtos klasöründe  oluşturuldu.
-Core: Bu katman tüm projelerde ortak kullanılabilecek katmandır, projelere eklemek istenilen özellikler best practice olarak buradan eklenir. 
-Aspects: klasörü içinde Servislerde kullanılacak attributelar üretilir. 
	-Caching: Önbellek işleminin yapılmasını sağlayan aspect
	-Exception: hata loglamayı sağlayan aspect
	-Logging: Loglamayı sağlayan Aspect
	-Performance: Performans problemini bulmayı sağlayan aspect
	-Transaction: Kodda hata olursa database’de yapılan işlemi geri almayı sağlar.
	-Validation: Doğrulama işlemlerinin yapılmasını sağlayan aspect.
-CrossCuttingConcern: Bu Klasör projede kullanılacak özelliklerin managerlerinin yazıldığı klasördür.
-Caching: Microsoft ve Redis Cache Yapılandırması içerir. Hangisi kullanılmak isteniyorsa DependencyResolver klasöründeki CoreModule dan seçer ve tüm proje tek değişiklikle cache yönetimini değiştirmiş olur. 
-Logging: Log işlemlerinin yapılmasını sağlayan Manager. Serilog eklendi ancak istenirse diğer loglama managerleri de eklenerek kolayca tüm yapının log sistemi değiştirilebilir. 
-Validation: Doğrulma işlemlerinin manageri
-DataAccess: DataAccess katmanına ayırılmış klasördür. EntityFramework’ün ekleme silme, güncelleme ve veri getirme işlemlemlerini yaptığı kodlar burada tutulur.
-DependencyResolvers: Bağımlılıkların yönetildiği klasör. Örneğin Cache yönetiminin hangisi seçileceği burada belirtilir.
-Entities: Entities katmanına ait görevlerin klasörüdür. Entity ve Dto ların işaretlenmesi için boş interface üretildi.
-Enums: Enumların olduğu klasör, Success durumunu gösteren enum ayarlandı.
-Extensions: Extensionsların yazıldığı klasör. ServiceCollectionExtensions program başladığında ICoreModule ün çalışmasını sağlar. ICoreModule ile işaretlenmiş sınıflar program başlatıldığı gibi aktif edilir.
-Utilities: Araçların belirtildiği klasör
		-Business: İş kuralları
-Interceptors: Aspect Klasöründe oluşturulan tüm attributelerin attribute özelliğini kazandıran yapı bu klasörde ayarlanır.
-IoC: ServiceTool ve ICoreModule burada oluşturulur mimarinin temelindeki bir çok şey bu 2 sınıfı kullanır.
-MessageBrokers: RabbitMq
-Messages: Mesajların verildiği klasör
-Results: ApiResponse un verildiği yapıdır.

DataAccess: Veritabanını yöneten araca, entitylerin durumunun ayarlandığı yerdir. Bu projede EntityFramework kullanıyoruz. Entitylerin DataAccessLayerlarının interfaceleri oluşturulur, Core katmanındaki IEntityRepository ile işaretlenir. Daha sonra EntityFramework Klasörü içinde, oluşturulan interfaceler doldurulur. Migration migration sınıflarının tutulduğu klasördür entityframework otomatik oluşturur.


Business: İşlerin yapıldığı katmandır.
	-Abstract: Entitylerin Service interfaceleri bu klasörde tutulur.
	-Concrete: Serviceleri oluşturulan entityManager sınıfları bu katmanda doldurulur. Asıl 
veritabanı işleri burada yapılır.
-Constant: Sabit değerlerin tutulduğu klasör.
- DependencyResolvers: Web katmanında kod kalabalıklaşmasın diye Entitylerin kayıtlarını buradan yapılır.
-ValidationRules: Doğrulama kurallarının yazıldığı klasör
-AutoMapperProfile: Bu sınıf AutoMapper işlemi yapmayı sağlar.
WebAPI: ASP.Net katmanıdır. Proje bu katman sayesinde ayağa kalkar. Controllers içinde Get, Post işlemlerinin yapıldığı sınıflar tutulur.
