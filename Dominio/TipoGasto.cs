namespace Dominio
{
    public class TipoGasto
    {


 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoGasto(string nombre, string descripcion)
        {
            
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"{Descripcion}";
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre del gasto no puede estar vacío.");
            if (string.IsNullOrEmpty(Descripcion))
                throw new Exception("La descripción no puede estar vacía.");
        }

    }
}