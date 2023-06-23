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

        public Usuario GetId(string id)
        {
            return _usuariosCollection.Find(d => d.Id==id).FirstOrDefault();
        }
        public Task Create(Usuario usuario)
        {
          return  _usuariosCollection.InsertOneAsync(usuario);

        }

        public Task Update(string id,Usuario usuario)
        {
            return _usuariosCollection.ReplaceOneAsync(d => d.Id == id,usuario);
        }

        public Task Delete(string id)
        {
           return _usuariosCollection.DeleteOneAsync(d => d.Id==id);
        }

        public Usuario? ValidarUsuario(string _correo, string _password)
        {

            return _usuariosCollection.Find(d => d.Correo == _correo && d.Password==_password).FirstOrDefault();
        }
    }
}
