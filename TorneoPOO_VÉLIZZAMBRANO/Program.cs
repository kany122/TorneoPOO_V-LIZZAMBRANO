using TorneoPOO_VÉLIZZAMBRANO.Moddel;

Jugador objJugador1 = new Jugador();

objJugador1.Nombre = "Piero Hincapié";
objJugador1.Numero = 4;
objJugador1.Posicion = "Defensa";
objJugador1.Edad = 25;


Jugador objJugador2 = new Jugador();

objJugador2.Nombre = "Enner Valencia";
objJugador2.Numero = 7;
objJugador2.Posicion = "Delantero";
objJugador2.Edad = 32;


Equipo objEquipo1 = new Equipo();

objEquipo1.Nombre = "Emelec";
objEquipo1.Ciudad = "Guayaquil";
objEquipo1.Jugadores = new List<Jugador>();

objEquipo1.AgregarJugador(objJugador1);
objEquipo1.AgregarJugador(objJugador2);



objEquipo1.ListarPlantilla();

Jugador objJugador3 = new Jugador();

objJugador3.Nombre = "Moiséc Caicedo";
objJugador3.Numero = 5;
objJugador3.Posicion = "Medio Campo";
objJugador3.Edad = 23;


Jugador objJugador4 = new Jugador();

objJugador4.Nombre = "Neiser Reascos";
objJugador4.Numero = 24;
objJugador4.Posicion = "Lateral";
objJugador4.Edad = 45;


Equipo objEquipo2 = new Equipo();

objEquipo2.Nombre = "Barcelona";
objEquipo2.Ciudad = "Guayaquil";
objEquipo2.Jugadores = new List<Jugador>();

objEquipo2.AgregarJugador(objJugador3);
objEquipo2.AgregarJugador(objJugador4);



objEquipo2.ListarPlantilla();

Partido objPartido1 = new Partido();
objPartido1.Programar(objEquipo1, objEquipo2, DateTime.Now, "Guayaquil");
objPartido1.MostrarResumen();