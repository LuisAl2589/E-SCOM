using MongoDB.Bson.Serialization.Attributes;
namespace ESCOM_merce.Models
{
    public class Producto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonElement("_idVendedor")]
        public string IdVendedor { get; set; }
        [BsonElement("descripcion")]
        public string Descripcion { get; set; }
        [BsonElement("costo")]

        public decimal Costo { get; set; }
        [BsonElement("stock")]

        public int Stock { get; set; }
        [BsonElement("estado")]

        public Boolean Estado { get; set; }
        [BsonElement("imagen")]

        public string Imagen { get; set; }





    }
}
