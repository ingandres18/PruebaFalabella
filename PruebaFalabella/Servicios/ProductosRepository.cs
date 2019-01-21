using PruebaFalabella.Models;
using System.Collections.Generic;
using System.Linq;

namespace PruebaFalabella.Servicios
{
    public class ProductosRepository
    {
        private FalabellaContext db = new FalabellaContext();

        internal IEnumerable<Producto> ObtenerProductos()
        {
            return db.Producto.ToList();
        }
    }
}