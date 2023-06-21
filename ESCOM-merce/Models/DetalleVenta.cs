using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class DetalleVenta
    {
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_idProducto")]

        public string IdProducto { get; set; }
        [BsonElement("unidades")]

        public int Unidades { get; set; }
    }
}
