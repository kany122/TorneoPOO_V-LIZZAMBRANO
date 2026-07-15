using System;
using TorneoPOO_VÉLIZZAMBRANO.Moddel;

try
{
    // === EQUIPO 1 ===

    // Nuevos params de Jugador: Nacionalidad, Goles, Estatura
    Jugador objJugador1 = new Jugador("Piero Hincapié", 25, 4, "Defensa", "Ecuatoriana", 2, 1.84);
    Jugador objJugador2 = new Jugador("Enner Valencia", 32, 7, "Delantero", "Ecuatoriana", 40, 1.77);



    // Nuevos params de Equipo: DT, Año de fundación, Presupuesto
    Equipo objEquipo1 = new Equipo("Emelec", "Guayaquil", "Leonel Álvarez", 1929, 1200000.50);
    objEquipo1.AgregarJugador(objJugador1);
    objEquipo1.AgregarJugador(objJugador2);



    // PRUEBA VALIDACIÓN 1: Agregar jugador nulo
    objEquipo1.AgregarJugador(null);
    objEquipo1.ListarPlantilla();



    // MÉTODO NUEVO DE EQUIPO: Mostrar total
    objEquipo1.MostrarTotalJugadores();



    // === EQUIPO 2 ===

    Jugador objJugador3 = new Jugador("Moisés Caicedo", 23, 5, "Medio Campo", "Ecuatoriana", 5, 1.78);
    Jugador objJugador4 = new Jugador("Neiser Reascos", 45, 24, "Lateral", "Ecuatoriana", 12, 1.72);

    Equipo objEquipo2 = new Equipo("Barcelona", "Guayaquil", "Segundo Castillo", 1925, 1500000.00);
    objEquipo2.AgregarJugador(objJugador3);
    objEquipo2.AgregarJugador(objJugador4);
    objEquipo2.ListarPlantilla();



    // MÉTODO NUEVO DE EQUIPO: Mostrar total
    objEquipo2.MostrarTotalJugadores();



    // === PROBAR MÉTODO DE JUGADOR ===
    objJugador1.CambiarPosicion("Mediocampista");
    Console.WriteLine();



    // === PARTIDO ===

    // Nuevos params de Partido: Árbitro, precio de entrada, ¿es clave? (true/false)
    Partido objPartido1 = new Partido(objEquipo1, objEquipo2, DateTime.Now, "Estadio Monumental", "Augusto Aragón", 10.50, true);

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
    Partido objPartidoInvalido = new Partido(objEquipo1, objEquipo1, DateTime.Now, "Guayaquil", "Augusto Aragón", 5.00, false);
    if (objPartidoInvalido != null && objPartidoInvalido.Local != null)
    {
        objPartidoInvalido.MostrarResumen();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\n[ERROR DETECTADO EN VALIDACIÓN]: {ex.Message}");
}