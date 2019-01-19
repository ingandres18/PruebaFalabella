namespace PruebaFalabella.Servicios.Autenticacion
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        public Resultado<object> Autenticar(string usuario, string clave)
        {
            var resultado = new Resultado<object>();

            if (usuario.Equals("admin") && clave.Equals("123"))
            {
                resultado.Exito = true;
            }
            else
            {
                resultado.Exito = false;
                resultado.Mensaje = $"El usuario {usuario} no esta en la base de datos";
            }

            return resultado;
        }
    }
}