namespace PruebaFalabella.Servicios
{
    public class Resultado<T>
    {
        public string Mensaje { get; set; }
        public T ResultadoOperacion { get; set; }
        public bool Exito { get; set; }
    }
}