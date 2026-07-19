using System;
using System.ComponentModel.Design;
using TorneoPOO_VÉLIZZAMBRANO.Generales;
using TorneoPOO_VÉLIZZAMBRANO.Moddel;

int opcion = 0;
Jugador objJugador = new Jugador("Sebastián", 23, 10, "Delantero", "Guayaquil", 18, 1.74);
DateBase.jugadores.Add(objJugador);
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
    Console.WriteLine("7. Crear Partidos");
    Console.WriteLine("8. Salir");
    Console.WriteLine("");
    Console.Write("Seleccione una opción: ");
    opcion = Convert.ToInt32(Console.ReadLine());

  
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
            crearPartido();
            break;

        case 8:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
            break;
    }

} while (opcion != 8);

void EliminarJugadores()
{
    Console.Clear();
    Console.WriteLine("===  Eliminar Jugadores ===");
    Console.WriteLine("Ingrese el nombre del jugador a Eliminar:");
    string nombreIngresado = Console.ReadLine();
    Jugador objJugador = DateBase.jugadores.Find(j => j.Nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase));
    if (objJugador != null)
    {
        Console.WriteLine("-------------------------");
        objJugador.Imprimir();
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Estas seguro de que deseas eliminar al jugador {objJugador.Nombre}?");
        Console.WriteLine("Ingrese 'si' para confirmar o cualquier otra tecla para cancelar:");
        string confirmacion = Console.ReadLine();
        if (confirmacion.Equals("si", StringComparison.OrdinalIgnoreCase))
        {
            DateBase.jugadores.Remove(objJugador);
            Console.WriteLine($"Jugador eliminado exitosamente.");
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

void ActualizarJugadores()
{
    Console.Clear();
    Console.WriteLine("===  Actualizar Jugadores ===");
    Console.WriteLine("Ingrese el nombre del jugador a Actualizar:");
    string nombreIngresado = Console.ReadLine();
    Jugador objJugador = DateBase.jugadores.Find(j => j.Nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase));
    if (objJugador != null)
    {
        Console.WriteLine("Jugador encontrado:");
        Console.WriteLine("-------------------------");
        objJugador.Imprimir();
        Console.WriteLine("-------------------------");
        Console.WriteLine("Ingrese el nuevo nombre del jugador (deje en blanco para mantener el actual):");
        string nuevoNombre = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevoNombre))
        {
            objJugador.Nombre = nuevoNombre;
        }
        Console.WriteLine("Ingrese la nueva edad del jugador (deje en blanco para mantener la actual):");
        string nuevaEdadInput = Console.ReadLine();
        if (int.TryParse(nuevaEdadInput, out int nuevaEdad))
        {
            objJugador.Edad = nuevaEdad;
        }
        Console.WriteLine("Ingrese el nuevo número de camiseta del jugador (deje en blanco para mantener el actual):");
        string nuevoNumeroInput = Console.ReadLine();
        if (int.TryParse(nuevoNumeroInput, out int nuevoNumero))
        {
            objJugador.Numero = nuevoNumero;
        }
        Console.WriteLine("Ingrese la nueva posición del jugador (deje en blanco para mantener la actual):");
        string nuevaPosicion = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaPosicion))
        {
            objJugador.Posicion = nuevaPosicion;
        }
        Console.WriteLine("Ingrese la nueva nacionalidad del jugador (deje en blanco para mantener la actual):");
        string nuevaNacionalidad = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(nuevaNacionalidad))
        {
            objJugador.Nacionalidad = nuevaNacionalidad;
        }
        Console.WriteLine("Ingrese la nueva cantidad de goles marcados por el jugador (deje en blanco para mantener la actual):");
        string nuevosGolesInput = Console.ReadLine();
        if (int.TryParse(nuevosGolesInput, out int nuevosGoles))
        {
            objJugador.GolesMarcados = nuevosGoles;
        }
        Console.WriteLine("Ingrese la nueva estatura del jugador (en metros, deje en blanco para mantener la actual):");
        string nuevaEstaturaInput = Console.ReadLine();
        if (double.TryParse(nuevaEstaturaInput, out double nuevaEstatura))
        {
            objJugador.Estatura = nuevaEstatura;
        }
        Console.WriteLine("Jugador actualizado exitosamente:");
    }
    else
    {
        Console.WriteLine("Jugador no encontrado.");
    }
    Console.ReadLine();
}

void BuscarJugadores()
{
    Console.Clear();
    Console.WriteLine("=== Buscar Jugadores ===");
    Console.WriteLine("Ingrese el nombre del jugador a buscar:");
    string nombreIngresado = Console.ReadLine();
    Jugador objJugador = DateBase.jugadores.Find(j => j.Nombre.Equals(nombreIngresado, StringComparison.OrdinalIgnoreCase));
    if (objJugador != null)
    {
        Console.WriteLine("Jugador encontrado:");
        Console.WriteLine("-------------------------");
        objJugador.Imprimir();
    }
    else
    {
        Console.WriteLine("Jugador no encontrado.");
    }
    Console.ReadLine();
}

void ListarJugadores()
{
    Console.Clear();
    Console.WriteLine("=== Jugadores Creados ===");
    foreach (Jugador jugador in DateBase.jugadores)
    { 
        jugador.Imprimir();
        Console.WriteLine("-------------------------");
    }
    Console.ReadLine();
}

void crearPartido()
{
    Console.Clear();
    Console.WriteLine("=== CREAR PARTIDO ===");
    Console.WriteLine("Ingrese el nombre del equipo local:");
    string nombreLocal = Console.ReadLine();

    Console.WriteLine("Ingrese el nombre del director técnico del equipo local:");
    string dtLocal = Console.ReadLine();

    Console.WriteLine($"Ingrese el año de fundación del equipo local (entre 1800 y {DateTime.Now.Year}):");
    int añoLocal;
    while (!int.TryParse(Console.ReadLine(), out añoLocal) || añoLocal < 1800 || añoLocal > DateTime.Now.Year)
    {
        Console.WriteLine($"Año inválido. Ingrese un año entre 1800 y {DateTime.Now.Year}:");
    }

    Console.WriteLine("Ingrese el nombre del equipo visitante:");
    string nombreVisitante = Console.ReadLine();

    Console.WriteLine("Ingrese el nombre del director técnico del equipo visitante:");
    string dtVisitante = Console.ReadLine();

    Console.WriteLine($"Ingrese el año de fundación del equipo visitante (entre 1800 y {DateTime.Now.Year}):");
    int añoVisitante;
    while (!int.TryParse(Console.ReadLine(), out añoVisitante) || añoVisitante < 1800 || añoVisitante > DateTime.Now.Year)
    {
        Console.WriteLine($"Año inválido. Ingrese un año entre 1800 y {DateTime.Now.Year}:");
    }

    Console.WriteLine("Ingrese la fecha del partido (formato: yyyy-MM-dd):");
    string fechaInput = Console.ReadLine();
    Console.WriteLine("Ingrese el lugar del partido:");
    string lugar = Console.ReadLine();
    Console.WriteLine("Ingrese el nombre del árbitro principal:");
    string arbitroPrincipal = Console.ReadLine();
    Console.WriteLine("Ingrese el precio de la entrada:");
    double precioEntrada = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("¿Es un partido de asistencia clave? (true/false):");
    bool esAsistenciaClave = Convert.ToBoolean(Console.ReadLine());

    Partido objPartido = new Partido(
        new Equipo(nombreLocal, "", dtLocal, añoLocal, 0),
        new Equipo(nombreVisitante, "", dtVisitante, añoVisitante, 0),
        DateTime.Parse(fechaInput), lugar, arbitroPrincipal, precioEntrada, esAsistenciaClave);
                                                                                                
    Console.WriteLine("Partido creado exitosamente:");
    Console.ReadLine();

}

void crearEquipo()
{
    Console.Clear();
    Console.WriteLine("=== CREAR EQUIPO ===");
    Console.WriteLine("Ingrese el nombre del equipo:");
    string nombre = Console.ReadLine();
    Console.WriteLine("Ingrese la ciudad del equipo:");
    string ciudad = Console.ReadLine();
    Console.WriteLine("Ingrese el nombre del dt del equipo:");
    string dt = Console.ReadLine();
    Console.WriteLine("Ingrese el año de fundación del equipo:");
    int anioFundacion = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ingrese el presupuesto del equipo:");
    double presupuesto = Convert.ToDouble(Console.ReadLine());

    Equipo objEquipo = new Equipo(nombre, ciudad, dt, anioFundacion, presupuesto);
    Console.WriteLine("Equipo creado exitosamente:");
    Console.ReadLine();
}

void crearJugador()
{
    Console.Clear();
    Console.WriteLine("=== CREAR JUGADOR ===");
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
    string golesInput = Console.ReadLine();
    Console.WriteLine("Ingrese la estatura del jugador (en metros):");
    double estatura = Convert.ToDouble(Console.ReadLine());

    Jugador objJugador = new Jugador(nombre, edad, numero, posicion, nacionalidad, Convert.ToInt32(golesInput), estatura);
    DateBase.jugadores.Add(objJugador);
    Console.WriteLine("Jugador creado exitosamente:");
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