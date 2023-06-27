using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class Carrito
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        
        public string Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_idCliente")]
        public string IdCliente { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_idVendedor")]
        public string IdVendedor { get; set; }
        [BsonElement("detalle")]
        public List<DetalleVenta> Detalles { get; set; }
        [BsonElement("estado")]
        public Boolean Estado { get; set; }
    }
}
