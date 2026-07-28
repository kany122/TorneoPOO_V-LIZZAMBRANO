using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_VÉLIZZAMBRANO.Moddel;

namespace TorneoPOO_VÉLIZZAMBRANO.Generales
{
    public static class DateBase
    {
        private static readonly string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        private static readonly string rutaArchivoJugadores = Path.Combine(rutaCarpeta, "jugadores.json");
        private static readonly string rutaArchivoEquipos = Path.Combine(rutaCarpeta, "equipos.json");
        private static readonly string rutaArchivoPartidos = Path.Combine(rutaCarpeta, "partidos.json");

        public static List<Jugador> Jugadores {  get; set; } = new List<Jugador>();
        public static List<Equipo> Equipos { get; set; } = new List<Equipo>();
        public static List<Partido> Partidos { get; set; } = new List<Partido>();

        public static void CargarDatos()
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            Jugadores = ArchivoJson.Cargar<Jugador>(rutaArchivoJugadores);
            Equipos = ArchivoJson.Cargar<Equipo>(rutaArchivoEquipos);
            Partidos = ArchivoJson.Cargar<Partido>(rutaArchivoPartidos);
        }

        public static void GuardarDatos()
        {
            ArchivoJson.Guardar(rutaArchivoJugadores, Jugadores);
            ArchivoJson.Guardar(rutaArchivoEquipos, Equipos);
            ArchivoJson.Guardar(rutaArchivoPartidos, Partidos);
        }

        public static void GuardarJugador()
        {
            ArchivoJson.Guardar(rutaArchivoJugadores, Jugadores);
        }
        public static void GuardarEquipo()
        {
            ArchivoJson.Guardar(rutaArchivoEquipos, Equipos);
        }
        public static void GuardarPartido()
        {
            ArchivoJson.Guardar(rutaArchivoPartidos, Partidos);
        }

    }
}
