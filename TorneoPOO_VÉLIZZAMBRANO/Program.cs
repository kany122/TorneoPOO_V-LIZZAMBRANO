using TorneoPOO_VÉLIZZAMBRANO.Moddel;

// === EQUIPO 1 ===
Jugador objJugador1 = new Jugador("Piero Hincapié", 25, 4, "Defensa");
Jugador objJugador2 = new Jugador("Enner Valencia", 32, 7, "Delantero");

Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil");

objEquipo1.AgregarJugador(objJugador1);
objEquipo1.AgregarJugador(objJugador2);

// PRUEBA VALIDACIÓN 1: Agregar jugador nulo
objEquipo1.AgregarJugador(null);

objEquipo1.ListarPlantilla();

// MÉTODO NUEVO DE EQUIPO: Mostrar total
objEquipo1.MostrarTotalJugadores();


// === EQUIPO 2 ===
Jugador objJugador3 = new Jugador("Moisés Caicedo", 23, 5, "Medio Campo");
Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Lateral");

Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil");

objEquipo2.AgregarJugador(objJugador3);
objEquipo2.AgregarJugador(objJugador4);
objEquipo2.ListarPlantilla();

// MÉTODO NUEVO DE EQUIPO: Mostrar total
objEquipo2.MostrarTotalJugadores();


// === PROBAR MÉTODO DE JUGADOR ===
// MÉTODO NUEVO DE JUGADOR: Cambiar posición en la cancha
objJugador1.CambiarPosicion("Mediocampista");
Console.WriteLine();


// === PARTIDO ===
// Creamos el partido normal (válido)
Partido objPartido1 = new Partido(objEquipo1, objEquipo2, DateTime.Now, "Guayaquil");

// Usamos el 'if' por seguridad si la validación interna actúa
if (objPartido1.Local != null)
{
    objPartido1.MostrarResumen();

    // MÉTODO NUEVO DE PARTIDO: Cambiar el estadio de juego
    objPartido1.CambiarSede("Estadio Capwell");
    objPartido1.MostrarResumen();
}

Console.WriteLine();

// PRUEBA VALIDACIÓN 2: Forzar partido contra el mismo equipo
Console.WriteLine("--- Test de Validación: Mismo Equipo ---");
Partido objPartidoInvalido = new Partido(objEquipo1, objEquipo1, DateTime.Now, "Guayaquil");

if (objPartidoInvalido.Local != null)
{
    objPartidoInvalido.MostrarResumen();
}