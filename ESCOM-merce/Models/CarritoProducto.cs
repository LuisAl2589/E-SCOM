namespace ESCOM_merce.Models
{
    public class CarritoProducto
    {
        public Carrito Carro { get; set; }
        public List<ProductoCantidad> Productos { get; set; }
    }
}
