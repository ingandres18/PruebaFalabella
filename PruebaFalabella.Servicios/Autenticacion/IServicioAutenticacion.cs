namespace PruebaFalabella.Servicios.Autenticacion
{
    public interface IServicioAutenticacion
    {
        Resultado<object> Autenticar(string usuario, string clave);
    }
}