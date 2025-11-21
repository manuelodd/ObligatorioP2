using System.Net.Security;

namespace Dominio
{
    public class PagoRecurrente : Pago
    {

        private DateTime _desde;
        private DateTime _hasta;

        public DateTime Desde
        {
            get { return _desde; }
            set { _desde = value; }
        }
        public DateTime Hasta
        {
            get { return _hasta; }
            set { _hasta = value; }
        }

        public PagoRecurrente() : base() { }
        public PagoRecurrente(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal monto, DateTime desde, DateTime hasta) : base(metodoPago, tipoGasto, usuario, descripcion, monto)
        {
            Desde = desde;
            Hasta = hasta;
        }

        public override decimal CalcularMontoTotal(Pago pago) //ToDo
        {
            return 0m;
        }

        public override string ToString()
        {
            if (Hasta == new DateTime())
            {
                return base.ToString() + "- Pago recurrente";
            }
            if (DateTime.Now > Hasta)
            {
                return base.ToString() + "- Totalmente pagado";
            }
            Double Diferencia = (Hasta - Desde).Days / 30.44;
            //  Math.Floor lo usamos para quedarnos con la parte entera, es decir que si quedan 6.8888... cuotas se queda solo con el 6
            return base.ToString() + "- Quedan " + Math.Floor(Diferencia) + " pagos";
        }

        public override void Validar()
        {
            base.Validar();
            if (Desde == DateTime.MinValue)
            {
                throw new Exception("La fecha de inicio no no puede ser vacías");
            }
            if (Desde > Hasta && Hasta != new DateTime())
            {
                throw new Exception("La fecha de la primera cuota debe ser menor a la de la siguiente o ultima");
            }
        }

    }
}
