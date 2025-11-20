namespace Dominio
{
    public abstract class Pago
    {
        private static int s_ultimoID = 0;

        private int _id;
        private MetodoPago _metodoPago;
        private TipoGasto _tipoGasto;
        private Usuario _usuario;
        private string _descripcion;
        private decimal _monto;
        public int s_Id
        {
            get { return s_ultimoID; }
            set { s_ultimoID = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public MetodoPago MetodoPago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }
        public TipoGasto TipoGasto
        {
            get { return _tipoGasto; }
            set { _tipoGasto = value; }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public decimal Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public Pago() { }
        public Pago(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto)
        {
            Id = ++s_ultimoID;
            MetodoPago = metodoPago;
            TipoGasto = tipoGasto;
            Usuario = usuario;
            Descripcion = descripcion;
            Monto = monto;
        }

        public string GetEmailUsuario()
        {
            return this.Usuario.Email;
        }

        public abstract decimal CalcularMontoTotal(Pago pago);

        public override string ToString()
        {
            return $"Pago | {Id} | Método: {MetodoPago} ";
        }

        public virtual void Validar()
        {
            if ((int)MetodoPago <= 0 || (int)MetodoPago > 3)
                throw new Exception("El metodo de pago no puede ser vacio");

            if (TipoGasto == null)
                throw new Exception("El tipo de gasto no puede ser vacio");

            if (Usuario == null)
                throw new Exception("El Usuario no debe ser vacio");

            if (string.IsNullOrEmpty(Descripcion))
                throw new Exception("La descripcion no puede ser vacia");

            if (Monto < 0)
                throw new Exception("El monto tiene que ser mayor o igual a 0");
        }
    }
}