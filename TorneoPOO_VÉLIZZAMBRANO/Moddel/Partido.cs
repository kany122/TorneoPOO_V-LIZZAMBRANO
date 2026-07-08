using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Partido
    {
        public Equipo Local { get; set; }

        public Equipo Visitante { get; set; }
        public DateTime Fecha { get; set; }

        public string Lugar { get; set; }

        // validar que local y visitante sean distintos
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar)
        {
            
            if (local != null && visitante != null && local.Nombre == visitante.Nombre)
            {
                Console.WriteLine("Error: El equipo Local y el Visitante no pueden ser el mismo.");
                return;
            }

            Local = local;
            Visitante = visitante;
            Fecha = fecha;
            Lugar = lugar;
        }


        public void MostrarResumen()
        {
            Console.WriteLine($"Partido entre {this.Local.Nombre} y {this.Visitante.Nombre} se jugará el {this.Fecha.ToShortDateString()} en {this.Lugar}");

        }


        public void CambiarSede(string nuevoLugar)
        {
            Console.WriteLine($"[AVISO]: El partido ha sido reprogramado de '{this.Lugar}' hacia: '{nuevoLugar}'.");
            this.Lugar = nuevoLugar;
        }

    }
}
