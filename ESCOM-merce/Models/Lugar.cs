using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class Lugar
    {
        [BsonElement("nombre")]

        public string Nombre { get; set; }
        [BsonElement("descripcion")]

        public string Descripcion { get; set; }
        [BsonElement("link")]

        public string Link { get; set;}
    }
}
