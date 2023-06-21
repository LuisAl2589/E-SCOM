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
    }
}
