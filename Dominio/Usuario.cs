namespace Dominio
{
    public abstract class Usuario
    {

        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasenia;
        private Equipo _equipo;
        private DateTime _empleadoDesde;

        public string Rol { get; set; }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }
        public Equipo Equipo
        {
            get { return _equipo; }
            set { _equipo = value; }
        }
        public DateTime EmpleadoDesde
        {
            get { return _empleadoDesde; }
            set { _empleadoDesde = value; }
        }

        public Usuario(string nombre, string apellido, string contrasenia, Equipo equipo, DateTime empleadoDesde)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Contrasenia = contrasenia;
            this.Equipo = equipo;
            this.EmpleadoDesde = empleadoDesde;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("El nombre no puede ser vacío.");

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new Exception("El apellido no puede ser vacío.");

            if (string.IsNullOrWhiteSpace(Contrasenia))
                throw new Exception("La contraseña no puede ser vacía.");

            if (Equipo == null)
                throw new Exception("Debe ingresar un nombre de equipo.");

            if (Contrasenia.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");
            if (string.IsNullOrWhiteSpace(Email))
                throw new Exception("El email no puede ser vacìo.");
        }

        public override string ToString()
        {
            return $"{Nombre} - {Email} - {Equipo}";
        }

        public abstract string ObtenerRol();

    }
}
