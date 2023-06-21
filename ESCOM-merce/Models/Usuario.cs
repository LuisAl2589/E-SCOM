using MongoDB.Bson.Serialization.Attributes;

namespace ESCOM_merce.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ?Id { get; set; }
        [BsonElement("nombre")]
        public string Nombre { get; set; }
        [BsonElement("primerApellido")]

        public string PrimerApellido { get; set; }
        [BsonElement("correo")]

        public string Correo { get; set; }
        [BsonElement("nickname")]

        public string Nickname { get; set; }
        [BsonElement("password")]

        public string Password { get; set; }
        [BsonElement("tipoUsuario")]

        public string TipoUsuario { get; set; }


    }
}
