using Dominio;

namespace ObligatorioP2
{
    internal class Program
    {
        private static Sistema sistema = Sistema.Instancia;

        static void Main(string[] args)
        {
            Menu();
            int opcion = Opcion();

            while (opcion != 0)
            {
                switch (opcion)
                {
                    case 1:
                        Cargando();
                        MostrarUsuarios();
                        Continuar();
                        break;
                    case 2:
                        Cargando();
                        MostrarPagosPorEmail();
                        Continuar();
                        break;
                    case 3:
                        Cargando();
                        CrearUsuario(); ;
                        Continuar();
                        break;
                    case 4:
                        Cargando();
                        MostrarIntegrantesEquipo();
                        Continuar();
                        break;
                }
                Menu();
                opcion = Opcion();
            }
        }
        public static void Menu()
        {
            Console.WriteLine("=== MENU ===\n");
            Console.WriteLine("1- Mostrar listado de todos los usuarios");
            Console.WriteLine("2- Mostrar pagos del usuario(por email)");
            Console.WriteLine("3- Alta de usuario");
            Console.WriteLine("4- Mostrar integrantes por nombre de equipo");
            Console.WriteLine("0- Salir\n");
        }

        public static int Opcion()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int opcion))
                {
                    if (opcion >= 0 && opcion <= 4)
                    {
                        return opcion;
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar un numero del rango 1-4");
                    }
                }
                else
                {
                    Console.WriteLine("Se debe ingrear un numero");
                }
            }
        }

        private static void CrearUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRAR NUEVO USUARIO ===\n");

            Console.WriteLine("Ingresar nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Ingresar apellido");
            string apellido = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Crear una contraseña de mínimo 8 carácteres");
            string password = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Ingresar nombre de equipo");
            string equipoIngresado = Console.ReadLine();
            Equipo equipo = null;

            foreach (Equipo unE in sistema.GetEquipos())
            {
                if (unE.Nombre.ToLower() == equipoIngresado.ToLower())
                    equipo = unE;
            }
            Console.WriteLine("");

            Console.WriteLine("Ingresr fecha de ingreso a la empresa (YYYY-MM-DD)");
            DateTime trabajaDesde = new DateTime();
            if (DateTime.TryParse(Console.ReadLine(), out trabajaDesde))
            {
                //no le paso por parametros el email, ya que se autogenera
                try
                {
                    Usuario nuevoUsuario = new Usuario(nombre, apellido, password, equipo, trabajaDesde);
                    sistema.AgregarUsuario(nuevoUsuario);
                    Console.WriteLine("\n=== USUARIO CREADO CON ÉXITO ===");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("La fecha no puede estar vacia y debe ester en formato YYYY-MM-DD");
            }
        }

        private static void MostrarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("=== USUARIOS ===\n");

            List<Usuario> usuarios = sistema.GetUsuarios();

            if (usuarios.Count > 0)
            {
                foreach (Usuario unU in usuarios)
                    Console.WriteLine(unU.ToString());
            }
            else
            {
                Console.WriteLine("No existen usuarios en el sistema");
            }
        }

        private static void MostrarPagosPorEmail()
        {
            Console.Clear();
            Console.WriteLine("=== BUSCAR PAGOS DE USUARIO ===\n");
            Console.WriteLine("Ingresa un Email:");
            string EmailIngresado = Console.ReadLine();

            //  Validamos que el email no sea vacio
            if (string.IsNullOrEmpty(EmailIngresado))
            {
                Console.WriteLine("El Email no puede ser vacio");
            }
            else
            {
                //  Validamos que el Email ingresado se encuentre en el sistema para no enviar la lista al UI si no es un usuario existente
                if (sistema.ExisteEmail(EmailIngresado))
                {
                    List<Pago> pagosCliente = sistema.GetPagosPorEmail(EmailIngresado);
                    //  Validamos que el usuario cuente con pagos
                    if (pagosCliente.Count > 0)
                    {
                        Console.WriteLine("");
                        //   Listamos los pagos del cliente
                        foreach (Pago unU in pagosCliente)
                        {
                            Console.WriteLine(unU.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No existen pagos para el usuario {EmailIngresado} en el sistema");
                    }
                }
                else
                {
                    Console.WriteLine("El Email ingresado no existe");
                }
            }
        }

        private static void MostrarIntegrantesEquipo()
        {
            Console.Clear();
            Console.WriteLine("=== EQUIPOS REGISTRADOS ===\n");
            //  Funcion que lista los equipos disponibles
            foreach (Equipo unE in sistema.GetEquipos())
            {
                Console.WriteLine(unE.Nombre);
            }

            Console.WriteLine("\nIngrese el nombre de equipo: ");
            string nombreIngresado = Console.ReadLine();

            if (string.IsNullOrEmpty(nombreIngresado))
            {
                Console.WriteLine("Debe ingresar un equipo");
            }
            else
            {
                if (sistema.ExisteEquipo(nombreIngresado))
                {
                    List<Usuario> usuariosPorEquipo = sistema.GetUsuariosPorEquipo(nombreIngresado);

                    if (usuariosPorEquipo.Count > 0)
                    {
                        Console.WriteLine("");
                        foreach (Usuario unU in usuariosPorEquipo)
                            //  Muestro el nombre y email, ya que el equipo lo acabo de ingresar
                            Console.WriteLine(unU.Nombre+" - "+unU.Email);
                    }
                    else
                    {
                        Console.WriteLine("El equipo no tiene integrantes.");
                    }
                }
                else
                {
                    Console.WriteLine("El equipo ingresado no existe");
                }
            }
        }

        //  Metodos para la consola.
        private static void Continuar()
        {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Cargando(int milisegundos = 1000)
        {
            string frames = "|/-\\";
            for (int i = 0; i < milisegundos / 100; i++)
            {
                Console.Write("\rCargando " + frames[i % frames.Length]);
                Thread.Sleep(100);
            }
        }
    }
}
