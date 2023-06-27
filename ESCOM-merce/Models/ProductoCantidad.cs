using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class ProductoCantidad
    {
        [BsonElement("producto")]
        public Producto Producto { get; set; }
        [BsonElement("cantidad")]
        public int Cantidad { get; set; }
    }
}
