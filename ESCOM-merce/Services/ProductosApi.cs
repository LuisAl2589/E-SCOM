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

        public List<Producto> GetIdVendedor(string idVendedor)
        {
            return _productosCollection.Find(d => d.IdVendedor==idVendedor).ToList();
        }

        public Producto GetId(string id)
        {
            return _productosCollection.Find(d => d.Id == id).FirstOrDefault();
        }
        public Task Create(Producto producto)
        {
            return _productosCollection.InsertOneAsync(producto);

        }

        public Task Update(string id, Producto producto)
        {
            return _productosCollection.ReplaceOneAsync(d => d.Id == id, producto);
        }

        public Task Delete(string id)
        {
            return _productosCollection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
