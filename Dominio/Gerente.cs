using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Gerente : Usuario
    {
        public override string ObtenerRol()
        {
            return this.Rol;
        }

        public Gerente(string nombre, string apellido, string contrasenia, Equipo equipo, DateTime empleadoDesde) : base(nombre, apellido, contrasenia, equipo, empleadoDesde)
        {
            this.Rol = "Gerente";
        }

    }
}
