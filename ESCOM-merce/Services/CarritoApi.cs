using ESCOM_merce.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ESCOM_merce.Services
{
    public class CarritoApi
    {

        private readonly IMongoCollection<Carrito> _carritoCollection;
        public CarritoApi(IOptions<BaseSettings> baseSettings)
        {
            var mongoClient = new MongoClient(
            baseSettings.Value.Server);

            var mongoDatabase = mongoClient.GetDatabase(
                baseSettings.Value.Database);

            _carritoCollection = mongoDatabase.GetCollection<Carrito>("carrito");
        }

        public List<Carrito> Get()
        {
            return _carritoCollection.Find(d => true).ToList();
        }

        public Task Create(Carrito carro)
        {
            return _carritoCollection.InsertOneAsync(carro);

        }

        public Carrito BuscarCarrito(string _idCliente, string _idVendedor)
        {
            return _carritoCollection.Find(d=> d.IdCliente==_idCliente && d.IdVendedor==_idVendedor).FirstOrDefault();

        }

        public Carrito GetId(string _idCarrito)
        {
            return _carritoCollection.Find(d => d.Id == _idCarrito).FirstOrDefault();

        }

        public Task Update (Carrito carro)
        {
            return _carritoCollection.ReplaceOneAsync(d => d.Id == carro.Id, carro);

        }

        public Carrito AgregarCarrito(string _idCliente, string _idVendedor,DetalleVenta detalle)
        {
            var carroB = BuscarCarrito(_idCliente, _idVendedor);

            if(carroB == null)
            {
                Carrito carritoN = new Carrito();

                carritoN.Detalles = new List<DetalleVenta>();
               
                carritoN.IdCliente= _idCliente;
                carritoN.IdVendedor= _idVendedor;
                carritoN.Detalles.Add(detalle);
                carritoN.Estado = true;

                Create(carritoN);
                return carritoN;
            }
            else
            {
                carroB.Detalles.Add(detalle);
                Update(carroB);
                return carroB;
            }

        }

        public List<Carrito> CarritosCliente(string _idCliente)
        {
            return _carritoCollection.Find(d => d.IdCliente==_idCliente).ToList();
        }

        public Task Delete(string _idCarrito)
        {
            return _carritoCollection.DeleteOneAsync(d => d.Id == _idCarrito);
        }

    }
}
