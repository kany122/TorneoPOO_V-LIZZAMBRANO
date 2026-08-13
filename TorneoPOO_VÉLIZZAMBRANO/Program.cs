using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TorneoPOO_VÉLIZZAMBRANO.Datos;
using TorneoPOO_VÉLIZZAMBRANO.Generales;
using TorneoPOO_VÉLIZZAMBRANO.Moddel;

int opcion = 0;

do
{
    Console.Clear();
    Console.WriteLine("**************Bienvenido al Torneo de Futbol del mundial 2026***************");
    Console.WriteLine("=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. Crear Jugadores");
    Console.WriteLine("2. Listar Jugadores");
    Console.WriteLine("3. Buscar Jugadores");
    Console.WriteLine("4. Actualizar Jugadores");
    Console.WriteLine("5. Eliminar Jugadores");
    Console.WriteLine("6. Crear Equipos");
    Console.WriteLine("7. Listar Equipos");
    Console.WriteLine("8. Buscar Equipos");
    Console.WriteLine("9. Actualizar Equipos");
    Console.WriteLine("10. Eliminar Equipos");
    Console.WriteLine("11. Crear Partidos");
    Console.WriteLine("12. Listar Partidos");
    Console.WriteLine("13. Buscar Partido");
    Console.WriteLine("14. Actualizar Partido");
    Console.WriteLine("15. Eliminar Partido");
    Console.WriteLine("16. Salir");
    Console.WriteLine("");
    Console.Write("Seleccione una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Por favor, ingrese un número válido.");
        Console.ReadLine();
        continue;
    }

    switch (opcion)
    {
        case 1:
            crearJugador();
            break;
        case 2:
            ListarJugadores();
            break;
        case 3:
            BuscarJugadores();
            break;
        case 4:
            ActualizarJugadores();
            break;
        case 5:
            EliminarJugadores();
            break;
        case 6:
            crearEquipo();
            break;
        case 7:
            ListarEquipos();
            break;
        case 8:
            BuscarEquipo();
            break;
        case 9:
            ActualizarEquipo();
            break;
        case 10:
            EliminarEquipo();
            break;
        case 11:
            crearPartido();
            break;
        case 12:
            ListarPartidos();
            break;
        case 13:
            BuscarPartido();
            break;
        case 14:
            ActualizarPartido();
            break;
        case 15:
            EliminarPartido();
            break;
        case 16:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            Console.ReadLine();
            break;
    }

} while (opcion != 16);

// ==========================================
// MÉTODOS JUGADORES (SIN CAMBIOS)
// ==========================================

void crearJugador()
{
    Console.Clear();
    Console.WriteLine("=== CREAR JUGADOR ===");
    try
    {
        Console.WriteLine("Ingrese el nombre del jugador:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la edad del jugador:");
        int edad = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el número de camiseta del jugador:");
        int numero = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese la posición del jugador:");
        string posicion = Console.ReadLine();
        Console.WriteLine("Ingrese la nacionalidad del jugador:");
        string nacionalidad = Console.ReadLine();
        Console.WriteLine("Ingrese la cantidad de goles marcados por el jugador:");
        int goles = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese la estatura del jugador (en metros, ej: 1,75):");
        double estatura = Convert.ToDouble(Console.ReadLine());

        Jugador objJugador = new Jugador(nombre, edad, numero, posicion, nacionalidad, goles, estatura);
        DateBase.Jugadores.Add(objJugador);

        Console.WriteLine("\nJugador creado exitosamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError al crear jugador: {ex.Message}");
    }
    Console.ReadLine();
}

void ListarJugadores()
{
    Console.Clear();
    Console.WriteLine("=== Jugadores Creados ===");

    using (var context = new TorneoDbContext())
    {
        var listaJugadores = context.Jugadores.ToList();

        if (listaJugadores.Count == 0)
            Console.WriteLine("No hay jugadores registrados.");

        foreach (Jugador jugador in listaJugadores)
        {
            jugador.Imprimir();
            Console.WriteLine("-------------------------");
        }
    }

    Console.ReadLine();
}

void BuscarJugadores()
{
    Console.Clear();
    Console.WriteLine("=== Buscar Jugadores ===");
    Console.WriteLine("Ingrese el nombre del jugador a buscar:");
    string nombreIngresado = Console.ReadLine();

    Jugador objJugador = DateBase.Jugadores.Find(j => j.Nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase));
    if (objJugador != null)
    {
        Console.WriteLine("\nJugador encontrado:");
        Console.WriteLine("-------------------------");
        objJugador.Imprimir();
    }
    else
    {
        Console.WriteLine("Jugador no encontrado.");
    }
    Console.ReadLine();
}

void ActualizarJugadores()
{
    Console.Clear();
    Console.WriteLine("=== Actualizar Jugadores ===");
    Console.WriteLine("Ingrese el nombre del jugador a Actualizar:");
    string nombreIngresado = Console.ReadLine();

    Jugador objJugador = DateBase.Jugadores.Find(j => j.Nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase));
    if (objJugador != null)
    {
        Console.WriteLine("\nJugador encontrado:");
        objJugador.Imprimir();
        Console.WriteLine("-------------------------");

        Console.WriteLine("Nuevo nombre (deje en blanco para mantener):");
        string nuevoNombre = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoNombre)) objJugador.Nombre = nuevoNombre;

        Console.WriteLine("Nueva edad (deje en blanco para mantener):");
        string nuevaEdadInput = Console.ReadLine();
        if (int.TryParse(nuevaEdadInput, out int nuevaEdad)) objJugador.Edad = nuevaEdad;

        Console.WriteLine("Nuevo número de camiseta (deje en blanco para mantener):");
        string nuevoNumeroInput = Console.ReadLine();
        if (int.TryParse(nuevoNumeroInput, out int nuevoNumero)) objJugador.Numero = nuevoNumero;

        Console.WriteLine("Nueva posición (deje en blanco para mantener):");
        string nuevaPosicion = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaPosicion)) objJugador.Posicion = nuevaPosicion;

        Console.WriteLine("Nueva nacionalidad (deje en blanco para mantener):");
        string nuevaNacionalidad = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaNacionalidad)) objJugador.Nacionalidad = nuevaNacionalidad;

        Console.WriteLine("Nuevos goles marcados (deje en blanco para mantener):");
        string nuevosGolesInput = Console.ReadLine();
        if (int.TryParse(nuevosGolesInput, out int nuevosGoles)) objJugador.GolesMarcados = nuevosGoles;

        Console.WriteLine("Nueva estatura (deje en blanco para mantener):");
        string nuevaEstaturaInput = Console.ReadLine();
        if (double.TryParse(nuevaEstaturaInput, out double nuevaEstatura)) objJugador.Estatura = nuevaEstatura;

        Console.WriteLine("\nJugador actualizado exitosamente.");
    }
    else
    {
        Console.WriteLine("Jugador no encontrado.");
    }
    Console.ReadLine();
}

void EliminarJugadores()
{
    Console.Clear();
    Console.WriteLine("=== Eliminar Jugadores ===");
    Console.WriteLine("Ingrese el nombre del jugador a Eliminar:");
    string nombreIngresado = Console.ReadLine();

    Jugador objJugador = DateBase.Jugadores.Find(j => j.Nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase));
    if (objJugador != null)
    {
        objJugador.Imprimir();
        Console.WriteLine("-------------------------");
        Console.WriteLine($"¿Está seguro de que deseas eliminar al jugador {objJugador.Nombre}? (si/no)");
        string confirmacion = Console.ReadLine();
        if (confirmacion.Equals("si", StringComparison.OrdinalIgnoreCase))
        {
            DateBase.Jugadores.Remove(objJugador);
            Console.WriteLine("Jugador eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Eliminación cancelada.");
        }
    }
    else
    {
        Console.WriteLine("Jugador no encontrado.");
    }
    Console.ReadLine();
}

// ==========================================
// MÉTODOS EQUIPOS (MODIFICADO PARA SQL SERVER)
// ==========================================

void crearEquipo()
{
    Console.Clear();
    Console.WriteLine("=== CREAR EQUIPO ===");
    try
    {
        Console.WriteLine("Ingrese el nombre del equipo:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la ciudad del equipo:");
        string ciudad = Console.ReadLine();
        Console.WriteLine("Ingrese el nombre del DT del equipo:");
        string dt = Console.ReadLine();
        Console.WriteLine("Ingrese el año de fundación del equipo:");
        int anioFundacion = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el presupuesto del equipo:");
        double presupuesto = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese el color del uniforme del equipo:");
        string colorUniforme = Console.ReadLine();

        Equipo objEquipo = new Equipo(nombre, ciudad, dt, anioFundacion, presupuesto);
        objEquipo.ColorUniforme = colorUniforme;

        using (var context = new TorneoDbContext())
        {
            context.Equipos.Add(objEquipo);
            context.SaveChanges();

            Console.WriteLine("\nEquipo creado exitosamente en la base de datos.");

            string respuesta = "";
            do
            {
                Console.WriteLine("\n¿Desea fichar e ingresar jugadores a este equipo? Si/No");
                respuesta = Console.ReadLine();

                if (respuesta.Equals("si", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Ingrese el nombre del jugador registrado a fichar:");
                    string nombreIngresado = Console.ReadLine();

                    // Se busca directamente en SQL Server mediante el Context
                    Jugador objJugador = context.Jugadores.FirstOrDefault(j => j.Nombre.ToLower() == nombreIngresado.ToLower());

                    if (objJugador != null)
                    {
                        objEquipo.AgregarJugador(objJugador);
                        objJugador.Fichar(objEquipo);

                        // Guardamos el fichaje en SQL Server
                        context.SaveChanges();

                        Console.WriteLine("¡Jugador fichado con éxito!");
                    }
                    else
                    {
                        Console.WriteLine("Jugador no encontrado en el sistema.");
                    }
                }
            } while (respuesta.Equals("si", StringComparison.OrdinalIgnoreCase));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError al crear equipo: {ex.Message}");
    }
    Console.ReadLine();
}

void ListarEquipos()
{
    Console.Clear();
    Console.WriteLine("=== Equipos Creados ===");
    using (var context = new TorneoDbContext())
    {
        // Agregamos Include para traer la lista de jugadores relacionada
        var listaEquipos = context.Equipos.Include(e => e.Jugadores).ToList();

        if (listaEquipos.Count == 0) Console.WriteLine("No hay equipos registrados.");

        foreach (Equipo equipo in listaEquipos)
        {
            equipo.Imprimir();
            Console.WriteLine("=========================");
        }
    }
    Console.ReadLine();
}

void BuscarEquipo()
{
    Console.Clear();
    Console.WriteLine("=== Buscar Equipos ===");
    Console.WriteLine("Ingrese el nombre del equipo a buscar:");
    string nombre_Ingresado = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Equipo objEquipo = context.Equipos.FirstOrDefault(e => e.Nombre.ToLower() == nombre_Ingresado.ToLower());
        if (objEquipo != null)
        {
            Console.WriteLine("\nEquipo encontrado:");
            Console.WriteLine("-------------------------");
            objEquipo.Imprimir();
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }
    Console.ReadLine();
}

void ActualizarEquipo()
{
    Console.Clear();
    Console.WriteLine("=== Actualizar Equipos ===");
    Console.WriteLine("Ingrese el nombre del equipo a Actualizar:");
    string nombre_Ingresado = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Equipo objEquipo = context.Equipos.FirstOrDefault(e => e.Nombre.ToLower() == nombre_Ingresado.ToLower());
        if (objEquipo != null)
        {
            Console.WriteLine("\nEquipo actual:");
            Console.WriteLine($"Nombre: {objEquipo.Nombre}, Ciudad: {objEquipo.Ciudad}, DT: {objEquipo.DirectorTecnico}, Presupuesto: {objEquipo.Presupuesto}");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Nuevo nombre (deje en blanco para mantener):");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombre)) objEquipo.Nombre = nuevoNombre;

            Console.WriteLine("Nueva ciudad (deje en blanco para mantener):");
            string nuevaCiudad = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaCiudad)) objEquipo.Ciudad = nuevaCiudad;

            Console.WriteLine("Nuevo Director Técnico (deje en blanco para mantener):");
            string nuevoDt = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoDt)) objEquipo.DirectorTecnico = nuevoDt;

            Console.WriteLine("Nuevo presupuesto (deje en blanco para mantener):");
            string nuevoPresupuestoInput = Console.ReadLine();
            if (double.TryParse(nuevoPresupuestoInput, out double nuevoPresupuesto)) objEquipo.Presupuesto = nuevoPresupuesto;

            Console.WriteLine("Nuevo color de uniforme (deje en blanco para mantener):");
            string nuevoColor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoColor)) objEquipo.ColorUniforme = nuevoColor;

            context.SaveChanges();
            Console.WriteLine("\nEquipo actualizado con éxito.");
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }
    Console.ReadLine();
}

void EliminarEquipo()
{
    Console.Clear();
    Console.WriteLine("=== Eliminar Equipo ===");
    Console.WriteLine("Ingrese el nombre del equipo a eliminar:");
    string nombreIngresado = Console.ReadLine();

    using (var context = new TorneoDbContext())
    {
        Equipo objEquipo = context.Equipos.FirstOrDefault(e => e.Nombre.ToLower() == nombreIngresado.ToLower());
        if (objEquipo != null)
        {
            Console.WriteLine($"¿Está seguro de eliminar el equipo '{objEquipo.Nombre}'? (si/no)");
            string confirmacion = Console.ReadLine();
            if (confirmacion.Equals("si", StringComparison.OrdinalIgnoreCase))
            {
                context.Equipos.Remove(objEquipo);
                context.SaveChanges();
                Console.WriteLine("Equipo eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }
        else
        {
            Console.WriteLine("Equipo no encontrado.");
        }
    }
    Console.ReadLine();
}

// ==========================================
// MÉTODOS PARTIDOS (SIN CAMBIOS)
// ==========================================

void crearPartido()
{
    Console.Clear();
    Console.WriteLine("=== CREAR PARTIDO ===");

    Console.WriteLine("Ingrese el nombre del equipo LOCAL:");
    string localInput = Console.ReadLine();
    Equipo eLocal = DateBase.Equipos.Find(e => e.Nombre.Equals(localInput, StringComparison.OrdinalIgnoreCase));

    Console.WriteLine("Ingrese el nombre del equipo VISITANTE:");
    string visitanteInput = Console.ReadLine();
    Equipo eVisitante = DateBase.Equipos.Find(e => e.Nombre.Equals(visitanteInput, StringComparison.OrdinalIgnoreCase));

    if (eLocal == null || eVisitante == null)
    {
        Console.WriteLine("\nError: Ambos equipos deben estar creados previamente en la opción 6.");
        Console.ReadLine();
        return;
    }

    try
    {
        Console.WriteLine("Ingrese el ID único del partido (número entero):");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese la fecha del partido (formato: yyyy-MM-dd):");
        DateTime fecha = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el lugar / estadio del partido:");
        string lugar = Console.ReadLine();
        Console.WriteLine("Ingrese el nombre del árbitro principal:");
        string arbitro = Console.ReadLine();
        Console.WriteLine("Ingrese el precio de la entrada:");
        double precio = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("¿Es asistencia clave? (true/false):");
        bool clave = Convert.ToBoolean(Console.ReadLine());

        Partido nuevoPartido = new Partido(id, eLocal, eVisitante, fecha, lugar, arbitro, precio, clave);
        DateBase.Partidos.Add(nuevoPartido);

        Console.WriteLine("\nPartido programado de forma exitosa.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError en datos de partido: {ex.Message}");
    }
    Console.ReadLine();
}

void ListarPartidos()
{
    Console.Clear();
    Console.WriteLine("=== Calendario de Partidos ===");
    if (DateBase.Partidos.Count == 0) Console.WriteLine("No hay partidos agendados.");
    foreach (Partido partido in DateBase.Partidos)
    {
        partido.Imprimir();
        Console.WriteLine("");
    }
    Console.ReadLine();
}

void BuscarPartido()
{
    Console.Clear();
    Console.WriteLine("=== Buscar Partido ===");
    Console.WriteLine("Ingrese el nombre del equipo local del partido a buscar:");
    string busqueda = Console.ReadLine();

    Partido part = DateBase.Partidos.Find(p => p.Local.Nombre.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
    if (part != null)
    {
        Console.WriteLine("\nPartido Encontrado:");
        part.Imprimir();
    }
    else
    {
        Console.WriteLine("No se encontró ningún partido con ese equipo local.");
    }
    Console.ReadLine();
}

void ActualizarPartido()
{
    Console.Clear();
    Console.WriteLine("=== Actualizar Sede de Partido ===");
    Console.WriteLine("Ingrese el nombre del equipo local para ubicar el partido:");
    string busqueda = Console.ReadLine();

    Partido part = DateBase.Partidos.Find(p => p.Local.Nombre.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
    if (part != null)
    {
        Console.WriteLine("\nPartido actual:");
        part.Imprimir();
        Console.WriteLine("\nIngrese la nueva sede/estadio para reprogramar:");
        string nuevaSede = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaSede))
        {
            part.CambiarSede(nuevaSede);
        }
    }
    else
    {
        Console.WriteLine("Partido no encontrado.");
    }
    Console.ReadLine();
}

void EliminarPartido()
{
    Console.Clear();
    Console.WriteLine("=== Cancelar/Eliminar Partido ===");
    Console.WriteLine("Ingrese el nombre del equipo local del partido a cancelar:");
    string busqueda = Console.ReadLine();

    Partido part = DateBase.Partidos.Find(p => p.Local.Nombre.Equals(busqueda, StringComparison.OrdinalIgnoreCase));
    if (part != null)
    {
        Console.WriteLine($"¿Seguro que desea eliminar el partido {part.Local.Nombre} vs {part.Visitante.Nombre}? (si/no)");
        if (Console.ReadLine().Equals("si", StringComparison.OrdinalIgnoreCase))
        {
            DateBase.Partidos.Remove(part);
            Console.WriteLine("Partido cancelado del fixture.");
        }
    }
    else
    {
        Console.WriteLine("Partido no encontrado.");
    }
    Console.ReadLine();
}







//try
//{
//    // === EQUIPO 1 ===

//    // Nuevos params de Jugador: Nacionalidad, Goles, Estatura
//    Jugador objJugador1 = new Jugador("Piero Hincapié", 25, 4, "Defensa", "Ecuatoriana", 2, 1.84);
//    Jugador objJugador2 = new Jugador("Enner Valencia", 32, 7, "Delantero", "Ecuatoriana", 40, 1.77);



//    // Nuevos params de Equipo: DT, Año de fundación, Presupuesto
//    Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil", "Leonel Álvarez", 1929, 1200000.50);
//    objEquipo1.AgregarJugador(objJugador1);
//    objEquipo1.AgregarJugador(objJugador2);



//    // PRUEBA VALIDACIÓN 1: Agregar jugador nulo
//    objEquipo1.AgregarJugador(null);
//    objEquipo1.ListarPlantilla();



//    // MÉTODO NUEVO DE EQUIPO: Mostrar total
//    objEquipo1.MostrarTotalJugadores();



//    // === EQUIPO 2 ===

//    Jugador objJugador3 = new Jugador("Moisés Caicedo", 23, 5, "Medio Campo", "Ecuatoriana", 5, 1.78);
//    Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Lateral", "Ecuatoriana", 12, 1.72);

//    Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil", "Segundo Castillo", 1925, 1500000.00);
//    objEquipo2.AgregarJugador(objJugador3);
//    objEquipo2.AgregarJugador(objJugador4);
//    objEquipo2.ListarPlantilla();



//    // MÉTODO NUEVO DE EQUIPO: Mostrar total
//    objEquipo2.MostrarTotalJugadores();



//    // === PROBAR MÉTODO DE JUGADOR ===
//    objJugador1.CambiarPosicion("Mediocampista");
//    Console.WriteLine();



//    // === PARTIDO ===

//    // Nuevos params de Partido: Árbitro, precio de entrada, ¿es clave? (true/false)
//    Partido objPartido1 = new Partido(objEquipo1, objEquipo2, DateTime.Now, "Estadio Monumental", "Augusto Aragón", 10.50, true);

//    if (objPartido1.Local != null)
//    {
//        objPartido1.MostrarResumen();

//        // MÉTODO NUEVO DE PARTIDO: Cambiar el estadio de juego
//        objPartido1.CambiarSede("Estadio Capwell");
//        objPartido1.MostrarResumen();
//    }
//    Console.WriteLine();



//    // PRUEBA VALIDACIÓN 2: Forzar partido contra el mismo equipo
//    Console.WriteLine("--- Test de Validación: Mismo Equipo ---");
//    Partido objPartidoInvalido = new Partido(objEquipo1, objEquipo1, DateTime.Now, "Guayaquil", "Augusto Aragón", 5.00, false);
//    if (objPartidoInvalido != null && objPartidoInvalido.Local != null)
//    {
//        objPartidoInvalido.MostrarResumen();
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"\n[ERROR DETECTADO EN VALIDACIÓN]: {ex.Message}");
//}