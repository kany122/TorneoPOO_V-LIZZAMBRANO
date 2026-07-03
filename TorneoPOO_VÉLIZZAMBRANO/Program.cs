using TorneoPOO_VÉLIZZAMBRANO.Moddel;

Jugador objJugador1 = new Jugador();

objJugador1.Nombre = "Piero Hincapié";
objJugador1.Numero = 4;
objJugador1.Posicion = "Defensa";
objJugador1.Edad = 25;

objJugador1.Presentar();

Jugador objJugador2 = new Jugador();

objJugador2.Nombre = "Enner Valencia";
objJugador2.Numero = 7;
objJugador2.Posicion = "Delantero";
objJugador2.Edad = 32;

objJugador2.Presentar();


Equipo objEquipo1 = new Equipo();

objEquipo1.Nombre = "Barcelona SC";
objEquipo1.Origen = "Guayaquil";
objEquipo1.AñoFundacion = 1925;
objEquipo1.NumeroIntegrantes = 25;
objEquipo1.Entrenador = "Fabián Bustos";


objEquipo1.PresentarEquipo();



