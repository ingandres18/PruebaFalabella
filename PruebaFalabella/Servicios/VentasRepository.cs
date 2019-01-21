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
        
        internal IEnumerable<GenVenta> ObtenerVentas()
        {
            var lstVentas = new List<GenVenta>();

            foreach (var item in db.Venta.ToList())
            {
                lstVentas.Add(ToGenVenta(item));
            }

            return lstVentas;
        }

        internal GenVenta ObtenerPorId(int Id)
        {
            var genVenta = db.Venta.Find(Id);
            return ToGenVenta(genVenta);
        }

        private GenVenta ToGenVenta(Venta item)
        {
            if (item == null)
                return null;

            return new GenVenta
            {
                Cantidad = item.Cantidad,
                EmailAsesor = item.Asesor.Correo,
                Id = item.Id,
                IdProducto = item.Producto.Id,
                NoDocumento = item.Cliente.Documento,
                PrimerApellido = item.Cliente.PrimerApelldo,
                PrimerNombre = item.Cliente.PrimerNombre,
                SegundoApellido = item.Cliente.SegundoApellido,
                SegundoNombre = item.Cliente.SegundoNombre,
                Valor = item.Valor
            };
        }

        internal void Crear(GenVenta infoVenta)
        {
            var venta = new Venta();
            venta.Asesor = db.Asesor.Where(x => x.Correo.Equals(infoVenta.EmailAsesor)).Single();
            venta.Producto = db.Producto.Where(x => x.Id.Equals(infoVenta.IdProducto)).Single();
            venta.Cantidad = infoVenta.Cantidad;
            venta.Fecha = DateTime.Now;
            venta.Valor = infoVenta.Valor;

            var cliente = db.Cliente.Where(x => x.Documento.Equals(infoVenta.NoDocumento)).SingleOrDefault();
            if(cliente==null)
            {
                cliente = new Cliente
                {
                    Correo = string.Empty,
                    Documento = infoVenta.NoDocumento,
                    PrimerApelldo = infoVenta.PrimerApellido,
                    PrimerNombre = infoVenta.PrimerNombre,
                    SegundoApellido = infoVenta.SegundoApellido,
                    SegundoNombre = infoVenta.SegundoNombre
                };

                db.Cliente.Add(cliente);
            }

            venta.Cliente = cliente;
            db.Venta.Add(venta);
            db.SaveChanges();
        }

        internal GenVenta Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}