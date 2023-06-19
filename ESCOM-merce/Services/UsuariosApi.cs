using ESCOM_merce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ESCOM_merce.Services { 

    public class UsuariosApi
    {
        private readonly IMongoCollection<Usuario> _usuariosCollection;
        public UsuariosApi(IOptions<BaseSettings> baseSettings)
        {
        var mongoClient = new MongoClient(
        baseSettings.Value.Server);

        var mongoDatabase = mongoClient.GetDatabase(
            baseSettings.Value.Database);

        _usuariosCollection = mongoDatabase.GetCollection<Usuario>(
            baseSettings.Value.Collection);
        }

    public  List<Usuario> Get()
    {
        return _usuariosCollection.Find(d => true).ToList();
    }
}
}
