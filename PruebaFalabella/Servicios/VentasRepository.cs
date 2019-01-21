using PruebaFalabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaFalabella.Servicios
{
    public class VentasRepository
    {
        private FalabellaContext db = new FalabellaContext();

        public IEnumerable<GenVenta> ObtenerVentas()
        {
            var lstVentas = new List<GenVenta>();

            foreach (var item in db.Venta.ToList())
            {
                lstVentas.Add(ToGenVenta(item));
            }

            return lstVentas;
        }

        private GenVenta ToGenVenta(Venta item)
        {
            return new GenVenta
            {
                Cantidad = item.Cantidad,
                EmailAsesor = item.Asesor.Correo,
                Id = item.Id,
                IdProducto = item.Producto.Id,
                NoDocumento = item.Cliente.Id,
                PrimerApellido = item.Cliente.PrimerApelldo,
                PrimerNombre = item.Cliente.PrimerNombre,
                SegundoApellido = item.Cliente.SegundoApellido,
                SegundoNombre = item.Cliente.SegundoNombre,
                Valor = item.Valor
            };
        }
    }
}