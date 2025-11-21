namespace Dominio
{
    public class PagoUnico : Pago
    {
        private DateTime _fecha;
        public DateTime Fecha { 
            get { return _fecha; } 
            set { _fecha = value; } 
        }

     
        public PagoUnico(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime fecha) : base(metodoPago, tipoGasto, usuario, descripcion, monto)
        {
            Fecha = fecha;
        }

        public PagoUnico() : base() { }

        public override decimal CalcularMontoTotal(Pago pago) //ToDo
        {
            return 0m;
        }

        public override void Validar()
        {
            if (Fecha == DateTime.MinValue)
            {
                throw new Exception("La fecha no puede ser vacía");
            }
            base.Validar();
        }

    }
}
