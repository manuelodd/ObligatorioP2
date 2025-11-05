using System.Security.Cryptography.X509Certificates;

namespace Dominio
{
    public class Sistema
    {
        private List<Usuario> _usuarios;
        private List<Equipo> _equipos;
        private List<Pago> _pagos;
        private List<TipoGasto> _tipoGastos;

        private static Sistema s_instancia;

        #region Singleton

        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        private Sistema()
        {
            _usuarios = new List<Usuario>();
            _equipos = new List<Equipo>();
            _pagos = new List<Pago>();
            _tipoGastos = new List<TipoGasto>();

            // Precargo los datos al iniciar el sistema
            Precargar();
        }

        #endregion

        private void Precargar()
        {
            // =====================
            // EQUIPOS (4)
            // =====================
            Equipo e1 = new Equipo("IT");
            AgregarEquipo(e1);

            Equipo e2 = new Equipo("Desarrollo");
            AgregarEquipo(e2);

            Equipo e3 = new Equipo("Finanzas");
            AgregarEquipo(e3);

            Equipo e4 = new Equipo("Operaciones");
            AgregarEquipo(e4);


            // =====================
            // USUARIOS (22)  -> 5 con mismo nombre y apellido ("Sofía Gómez")
            // =====================
            // (u1..u5 comparten nombre+apellido)
            Usuario u1 = new Usuario("Sofía", "Gómez", "SofiaG1!", e1, new DateTime(2021, 5, 10));
            AgregarUsuario(u1);

            Usuario u2 = new Usuario("Sofía", "Gómez", "SofiaG2!", e2, new DateTime(2022, 3, 15));
            AgregarUsuario(u2);

            Usuario u3 = new Usuario("Sofía", "Gómez", "SofiaG3!", e3, new DateTime(2020, 11, 2));
            AgregarUsuario(u3);

            Usuario u4 = new Usuario("Sofía", "Gómez", "SofiaG4!", e4, new DateTime(2019, 8, 21));
            AgregarUsuario(u4);

            Usuario u5 = new Usuario("Sofía", "Gómez", "SofiaG5!", e1, new DateTime(2023, 1, 9));
            AgregarUsuario(u5);

            // Resto (17 con nombres distintos)
            Usuario u6 = new Usuario("Alex", "Silva", "AlexS!234", e2, new DateTime(2020, 6, 1));
            AgregarUsuario(u6);

            Usuario u7 = new Usuario("Camila", "Pérez", "CamPz#2020", e3, new DateTime(2018, 7, 12));
            AgregarUsuario(u7);

            Usuario u8 = new Usuario("Diego", "Rodríguez", "DiegoR*77", e4, new DateTime(2022, 9, 30));
            AgregarUsuario(u8);

            Usuario u9 = new Usuario("Martina", "López", "MarLo_88", e1, new DateTime(2017, 4, 5));
            AgregarUsuario(u9);

            Usuario u10 = new Usuario("Juan", "Torres", "JTorres99", e2, new DateTime(2021, 12, 13));
            AgregarUsuario(u10);

            Usuario u11 = new Usuario("Valentina", "Ramos", "ValeR@22", e3, new DateTime(2019, 2, 18));
            AgregarUsuario(u11);

            Usuario u12 = new Usuario("Bruno", "Acosta", "Bruno_Ac0", e4, new DateTime(2024, 5, 16));
            AgregarUsuario(u12);

            Usuario u13 = new Usuario("Lucía", "Fernández", "LuFer!55", e1, new DateTime(2020, 10, 7));
            AgregarUsuario(u13);

            Usuario u14 = new Usuario("Agustín", "Morales", "AgusM_12", e2, new DateTime(2016, 3, 3));
            AgregarUsuario(u14);

            Usuario u15 = new Usuario("Paula", "Castro", "PauCast*4", e3, new DateTime(2018, 1, 23));
            AgregarUsuario(u15);

            Usuario u16 = new Usuario("Felipe", "Suárez", "FeliS-77", e4, new DateTime(2023, 7, 19));
            AgregarUsuario(u16);

            Usuario u17 = new Usuario("Carolina", "Vega", "CaroVega99", e1, new DateTime(2022, 11, 11));
            AgregarUsuario(u17);

            Usuario u18 = new Usuario("Nicolás", "Sosa", "Nico_S0sa", e2, new DateTime(2019, 6, 6));
            AgregarUsuario(u18);

            Usuario u19 = new Usuario("Jimena", "Alonso", "JimeA#33", e3, new DateTime(2021, 8, 28));
            AgregarUsuario(u19);

            Usuario u20 = new Usuario("Rodrigo", "Ferrer", "RodFe_01", e4, new DateTime(2020, 12, 2));
            AgregarUsuario(u20);

            Usuario u21 = new Usuario("Micaela", "Núñez", "MicaN2024", e1, new DateTime(2024, 2, 14));
            AgregarUsuario(u21);

            Usuario u22 = new Usuario("Tomás", "Pereyra", "TomPereyra!", e2, new DateTime(2017, 9, 9));
            AgregarUsuario(u22);


            // =====================
            // TIPOS DE GASTO (10)
            // =====================
            TipoGasto g1 = new TipoGasto("Alquiler", "Renta mensual de oficina o local.");
            AgregarTipoGasto(g1);

            TipoGasto g2 = new TipoGasto("Servicios", "Luz, agua, saneamiento y tributos.");
            AgregarTipoGasto(g2);

            TipoGasto g3 = new TipoGasto("Internet", "Conectividad y telefonía fija/móvil.");
            AgregarTipoGasto(g3);

            TipoGasto g4 = new TipoGasto("Seguridad", "Seguro integral, vigilancia, alarmas.");
            AgregarTipoGasto(g4);

            TipoGasto g5 = new TipoGasto("Transporte", "Combustible, viáticos y fletes.");
            AgregarTipoGasto(g5);

            TipoGasto g6 = new TipoGasto("Mantenimiento", "Reparaciones, insumos y limpieza.");
            AgregarTipoGasto(g6);

            TipoGasto g7 = new TipoGasto("Marketing", "Publicidad, impresos y patrocinios.");
            AgregarTipoGasto(g7);

            TipoGasto g8 = new TipoGasto("Comidas", "Café, snacks, almuerzos de equipo.");
            AgregarTipoGasto(g8);

            TipoGasto g9 = new TipoGasto("Software", "Licencias y suscripciones de software.");
            AgregarTipoGasto(g9);

            TipoGasto g10 = new TipoGasto("Equipamiento", "Compra y repuesto de equipos.");
            AgregarTipoGasto(g10);


            // ===================================================================
            // PAGOS RECURRENTES (25) -> 5 con 'hasta' < 14/10/2025 (p1..p5)
            // ===================================================================
            // VENCIDOS (hasta menor a hoy 14/10/2025)
            Pago p1 = new PagoRecurrente(MetodoPago.CREDITO, g4, u4, "Seguro integral anual", 12500m, new DateTime(2025, 1, 1), new DateTime(2025, 9, 30));
            AgregarPago(p1);

            Pago p2 = new PagoRecurrente(MetodoPago.DEBITO, g3, u6, "Internet fibra empresarial", 3200m, new DateTime(2025, 5, 1), new DateTime(2025, 9, 30));
            AgregarPago(p2);

            Pago p3 = new PagoRecurrente(MetodoPago.EFECTIVO, g2, u7, "Servicios públicos trimestrales", 9800m, new DateTime(2025, 7, 1), new DateTime(2025, 9, 15));
            AgregarPago(p3);

            Pago p4 = new PagoRecurrente(MetodoPago.CREDITO, g6, u3, "Mantenimiento locativo", 4500m, new DateTime(2024, 10, 1), new DateTime(2025, 9, 1));
            AgregarPago(p4);

            Pago p5 = new PagoRecurrente(MetodoPago.DEBITO, g7, u9, "Campaña marketing Q3", 15000m, new DateTime(2025, 7, 1), new DateTime(2025, 9, 30));
            AgregarPago(p5);

            // VIGENTES O FUTUROS
            Pago p6 = new PagoRecurrente(MetodoPago.CREDITO, g1, u1, "Alquiler sede central", 75000m, new DateTime(2025, 1, 1), new DateTime(2025, 12, 31));
            AgregarPago(p6);

            Pago p7 = new PagoRecurrente(MetodoPago.DEBITO, g3, u8, "Plan datos móviles", 2100m, new DateTime(2025, 6, 1), new DateTime(2026, 5, 31));
            AgregarPago(p7);

            Pago p8 = new PagoRecurrente(MetodoPago.EFECTIVO, g8, u10, "Catering reuniones mensuales", 6800m, new DateTime(2025, 3, 1), new DateTime(2025, 12, 1));
            AgregarPago(p8);

            Pago p9 = new PagoRecurrente(MetodoPago.CREDITO, g9, u11, "Licencias software anuales", 42000m, new DateTime(2025, 1, 15), new DateTime(2025, 12, 15));
            AgregarPago(p9);

            Pago p10 = new PagoRecurrente(MetodoPago.DEBITO, g5, u12, "Viáticos logística", 9000m, new DateTime(2025, 2, 1), new DateTime(2026, 1, 31));
            AgregarPago(p10);

            Pago p11 = new PagoRecurrente(MetodoPago.CREDITO, g6, u13, "Limpieza y sanidad", 3500m, new DateTime(2025, 4, 1), new DateTime(2026, 3, 31));
            AgregarPago(p11);

            Pago p12 = new PagoRecurrente(MetodoPago.EFECTIVO, g2, u14, "Tasas y contribuciones", 5200m, new DateTime(2025, 1, 1), new DateTime(2025, 12, 1));
            AgregarPago(p12);

            Pago p13 = new PagoRecurrente(MetodoPago.CREDITO, g7, u15, "Publicidad permanente", 11500m, new DateTime(2025, 2, 1), new DateTime(2025, 11, 30));
            AgregarPago(p13);

            Pago p14 = new PagoRecurrente(MetodoPago.DEBITO, g4, u16, "Seguro equipos electrónicos", 8700m, new DateTime(2025, 3, 1), new DateTime(2026, 2, 28));
            AgregarPago(p14);

            Pago p15 = new PagoRecurrente(MetodoPago.CREDITO, g10, u17, "Leasing de equipamiento", 38500m, new DateTime(2025, 5, 1), new DateTime(2026, 4, 30));
            AgregarPago(p15);

            Pago p16 = new PagoRecurrente(MetodoPago.DEBITO, g1, u18, "Alquiler depósito", 30000m, new DateTime(2025, 1, 1), new DateTime(2025, 12, 31));
            AgregarPago(p16);

            Pago p17 = new PagoRecurrente(MetodoPago.EFECTIVO, g8, u19, "Coffee break semanal", 2500m, new DateTime(2025, 6, 1), new DateTime(2025, 12, 31));
            AgregarPago(p17);

            Pago p18 = new PagoRecurrente(MetodoPago.CREDITO, g9, u20, "Suite creativa mensual", 9800m, new DateTime(2025, 4, 1), new DateTime(2026, 3, 31));
            AgregarPago(p18);

            Pago p19 = new PagoRecurrente(MetodoPago.DEBITO, g5, u21, "Transporte eventos", 12000m, new DateTime(2025, 9, 1), new DateTime(2026, 8, 31));
            AgregarPago(p19);

            Pago p20 = new PagoRecurrente(MetodoPago.CREDITO, g6, u22, "Contrato limpieza extendido", 6400m, new DateTime(2025, 7, 1), new DateTime(2026, 6, 30));
            AgregarPago(p20);

            Pago p21 = new PagoRecurrente(MetodoPago.EFECTIVO, g3, u5, "Internet backup", 1800m, new DateTime(2025, 3, 1), new DateTime(2025, 12, 31));
            AgregarPago(p21);

            Pago p22 = new PagoRecurrente(MetodoPago.DEBITO, g7, u2, "Ads redes sociales", 14000m, new DateTime(2025, 8, 1), new DateTime(2026, 7, 31));
            AgregarPago(p22);

            Pago p23 = new PagoRecurrente(MetodoPago.CREDITO, g10, u6, "Renta de notebooks", 27000m, new DateTime(2025, 2, 1), new DateTime(2026, 1, 31));
            AgregarPago(p23);

            Pago p24 = new PagoRecurrente(MetodoPago.DEBITO, g2, u10, "Impuestos y tasas", 6000m, new DateTime(2025, 5, 1), new DateTime(2025, 12, 31));
            AgregarPago(p24);

            Pago p25 = new PagoRecurrente(MetodoPago.EFECTIVO, g1, u9, "Alquiler sala de reuniones", 8000m, new DateTime(2025, 9, 1), new DateTime(2026, 8, 31));
            AgregarPago(p25);


            // ==========================================
            // PAGOS ÚNICOS (17) -> p26 .. p42
            // ==========================================
            Pago p26 = new PagoUnico(MetodoPago.CREDITO, g10, u1, "Compra de impresora láser", 23500m, new DateTime(2025, 2, 10));
            AgregarPago(p26);

            Pago p27 = new PagoUnico(MetodoPago.DEBITO, g8, u3, "Almuerzo con proveedores", 4200m, new DateTime(2025, 3, 5));
            AgregarPago(p27);

            Pago p28 = new PagoUnico(MetodoPago.EFECTIVO, g6, u5, "Reparación de aire acondicionado", 8700m, new DateTime(2025, 1, 22));
            AgregarPago(p28);

            Pago p29 = new PagoUnico(MetodoPago.CREDITO, g7, u7, "Impresión de flyers", 3100m, new DateTime(2025, 4, 2));
            AgregarPago(p29);

            Pago p30 = new PagoUnico(MetodoPago.DEBITO, g5, u8, "Taxi a reunión externa", 980m, new DateTime(2025, 5, 18));
            AgregarPago(p30);

            Pago p31 = new PagoUnico(MetodoPago.EFECTIVO, g2, u10, "Pago tasa excepcional", 2500m, new DateTime(2025, 6, 7));
            AgregarPago(p31);

            Pago p32 = new PagoUnico(MetodoPago.CREDITO, g9, u12, "Alta de licencia anual extra", 19500m, new DateTime(2025, 7, 3));
            AgregarPago(p32);

            Pago p33 = new PagoUnico(MetodoPago.DEBITO, g3, u13, "Router adicional", 6800m, new DateTime(2025, 8, 1));
            AgregarPago(p33);

            Pago p34 = new PagoUnico(MetodoPago.EFECTIVO, g1, u14, "Mes adicional de alquiler", 75000m, new DateTime(2025, 2, 1));
            AgregarPago(p34);

            Pago p35 = new PagoUnico(MetodoPago.CREDITO, g4, u15, "Ajuste póliza robo", 5600m, new DateTime(2025, 9, 12));
            AgregarPago(p35);

            Pago p36 = new PagoUnico(MetodoPago.DEBITO, g8, u16, "Merienda jornada extendida", 2100m, new DateTime(2025, 3, 14));
            AgregarPago(p36);

            Pago p37 = new PagoUnico(MetodoPago.EFECTIVO, g6, u17, "Compra de herramientas", 4300m, new DateTime(2025, 1, 31));
            AgregarPago(p37);

            Pago p38 = new PagoUnico(MetodoPago.CREDITO, g10, u18, "Silla ergonómica", 15400m, new DateTime(2025, 5, 9));
            AgregarPago(p38);

            Pago p39 = new PagoUnico(MetodoPago.DEBITO, g5, u19, "Peaje y combustible", 3200m, new DateTime(2025, 6, 20));
            AgregarPago(p39);

            Pago p40 = new PagoUnico(MetodoPago.EFECTIVO, g7, u20, "Entrada a feria sectorial", 1800m, new DateTime(2025, 7, 29));
            AgregarPago(p40);

            Pago p41 = new PagoUnico(MetodoPago.CREDITO, g9, u21, "Suscripción premium anual", 29900m, new DateTime(2025, 2, 17));
            AgregarPago(p41);

            Pago p42 = new PagoUnico(MetodoPago.DEBITO, g3, u22, "Módem 5G", 11500m, new DateTime(2025, 8, 22));
            AgregarPago(p42);
        }

        public void AgregarEquipo(Equipo nuevoEquipo)
        {
            //  El manejo de Exepciones en este momento no estan controladas, porque los datos son precargados al sistema. Solo estan controladas para la creacion de un nuevo usuario.
            nuevoEquipo.Validar();
            _equipos.Add(nuevoEquipo);
        }

        public void AgregarTipoGasto(TipoGasto nuevoGasto)
        {
            nuevoGasto.Validar();
            _tipoGastos.Add(nuevoGasto);
        }

        public void AgregarPago(Pago nuevoPago)
        {
            nuevoPago.Validar();
            _pagos.Add(nuevoPago);
        }

        //Creo el metodo AgrgearUsuario para delegar responsabilidades y para poder generar el email.
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            nuevoUsuario.Email = GenerarEmail(nuevoUsuario.Nombre, nuevoUsuario.Apellido);
            //  Valido despues del generar el email por si el sistema falla, asi no existen usuarios sin email en el sistema.
            nuevoUsuario.Validar();
            _usuarios.Add(nuevoUsuario);
        }

        public List<Equipo> GetEquipos()
        {
            List<Equipo> listado = new List<Equipo>();
            foreach (Equipo unE in _equipos)
            {
                listado.Add(unE);
            }
            return listado;
        }

        public List<Usuario> GetUsuarios()
        {
            //Esto devuelve una copia de la lista original.
            return new List<Usuario>(_usuarios);
        }

        public List<Usuario> GetUsuariosPorEquipo(string nombreEquipo)
        {
            List<Usuario> listado = new List<Usuario>();
            foreach (Usuario unU in _usuarios)
            {
                if (unU.Equipo.Nombre.ToLower() == nombreEquipo.ToLower())
                {
                    listado.Add(unU);
                }
            }
            return listado;
        }

        public List<Pago> GetPagosPorEmail(string EmailIngresado)
        {
            List<Pago> listado = new List<Pago>();
            foreach (Pago unP in _pagos)
            {
                if (unP.GetEmailUsuario().ToLower() == EmailIngresado.ToLower())
                {
                    listado.Add(unP);
                }
            }
            return listado;
        }

        public bool ExisteEmail(string EmailIngresado)
        {
            foreach (Usuario unU in _usuarios)
            {
                if (unU.Email.ToLower() == EmailIngresado.ToLower())
                    return true;
            }
            return false;
        }

        public bool ExisteEquipo(string EquipoIngresado)
        {
            foreach (Equipo unE in _equipos)
            {
                if (unE.Nombre.ToLower() == EquipoIngresado.ToLower())
                {
                    return true;
                }
            }
                return false;
        }

        public string GenerarEmail(string nombre, string apellido)
        {

            string nombreCortado = "";
            string apellidoCortado = "";

            int largo = 3;
            if (nombre.Length < largo)
                largo = nombre.Length;

            for (int i = 0; i<largo; i++)
            {
                nombreCortado += nombre[i];
            }

            largo = 3;
            if (apellido.Length < largo)
                largo = apellido.Length;

            for (int i = 0; i<largo; i++)
            {
                apellidoCortado += apellido[i];
            }

            string nombreDeUsuario = nombreCortado.ToLower() + apellidoCortado.ToLower();

            string extension = "@laEmpresa.com";

            string emailCreado = nombreDeUsuario + extension;

            int contador = 0;

            //  El inicio de un nuevo bool siempre es False por defecto.
            bool existe = new bool();

            do
            {
                foreach (Usuario unU in _usuarios)
                {
                    if (unU.Email == emailCreado)
                    {
                        existe = true;
                        contador++;
                        emailCreado = nombreDeUsuario + contador + extension;
                    }
                    else
                    {
                        existe=false;
                    }
                }
            } while (existe);

            return emailCreado;
        }

    }
}
