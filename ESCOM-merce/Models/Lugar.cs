using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class Lugar
    {
        [BsonElement("nombre")]

        public string Nombre { get; set; }
        [BsonElement("latitud")]

        public string Latitud { get; set; }
        [BsonElement("longitud")]

        public string Longitud { get; set;}
    }
}
