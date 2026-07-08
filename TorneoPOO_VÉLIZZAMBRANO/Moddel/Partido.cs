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


        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar)
        {
            Local = local;
            Visitante = visitante;
            Fecha = fecha;
            Lugar = lugar;
        }

        
         public void MostrarResumen()
         {
            Console.WriteLine($"Partido entre {this.Local.Nombre} y {this.Visitante.Nombre} se jugará el {this.Fecha.ToShortDateString()} en {this.Lugar}");

         }

        //Acciones: programar, mostrar resumen.
    }
}
