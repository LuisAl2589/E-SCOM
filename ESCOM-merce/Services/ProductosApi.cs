using ESCOM_merce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ESCOM_merce.Services
{
    public class ProductosApi
    {
        private readonly IMongoCollection<Producto> _productosCollection;
        public ProductosApi(IOptions<ProductosSettings> baseSettings)
        {
            var mongoClient = new MongoClient(
            baseSettings.Value.Server);

            var mongoDatabase = mongoClient.GetDatabase(
                baseSettings.Value.Database);

            _productosCollection = mongoDatabase.GetCollection<Producto>(
                baseSettings.Value.Collection);
        }

        public List<Producto> Get()
        {
            return _productosCollection.Find(d => true).ToList();
        }
    }
}
