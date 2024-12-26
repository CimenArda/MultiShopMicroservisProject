using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }

        public string CategoryID { get; set; }

        [BsonIgnore] 
        public Category Category { get; set; }

        /*BsonIgnore =>o yazdığımız satırın veritabanına kaydedilmemesini sağlıyor 
         bu satırı kullan ama veritabanına kaydetme gibi.. */


    }
}
