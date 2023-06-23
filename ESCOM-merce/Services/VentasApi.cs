using ESCOM_merce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ESCOM_merce.Services
{
    public class VentasApi
    {
        private readonly IMongoCollection<Ventas> _ventasCollection;
        public VentasApi(IOptions<BaseSettings> baseSettings)
        {
            var mongoClient = new MongoClient(
            baseSettings.Value.Server);

            var mongoDatabase = mongoClient.GetDatabase(
                baseSettings.Value.Database);

            _ventasCollection = mongoDatabase.GetCollection<Ventas>("ventas");
        }

        public List<Ventas> Get()
        {
            return _ventasCollection.Find(d => true).ToList();
        }

        public Task<Ventas> GetId(string id)
        {
            return _ventasCollection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }
        public Task Create(Ventas ventas)
        {
            return _ventasCollection.InsertOneAsync(ventas);

        }

        public Task Update(string id, Ventas ventas)
        {
            return _ventasCollection.ReplaceOneAsync(d => d.Id == id, ventas);
        }

        public Task Delete(string id)
        {
            return _ventasCollection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
