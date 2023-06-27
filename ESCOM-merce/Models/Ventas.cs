using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class Ventas
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_idVendedor")]
        public string IdVendedor { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_idCliente")]
        public string IdCliente { get; set; }
        [BsonElement("productoCantidad")]
        public List<ProductoCantidad> Detalle{ get; set; }
        [BsonElement("total")]
        public decimal Total { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        [BsonElement("fechaPedido")]
        public DateTime FechaPedido { get; set; }
        [BsonElement("fechaEntrega")]
        public DateTime FechaEntrega { get; set; }
        [BsonElement("completado")]
        public Boolean Completado { get; set; }
        [BsonElement("lugar")]
        public Lugar LugarVenta { get; set; }

    }
}
