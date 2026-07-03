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
        public void Programar(Equipo local, Equipo visitante, DateTime fecha, string lugar)
        {
            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar = lugar;
            Console.WriteLine("Partido programado correctamente");
        }
         public void MostrarResumen()
         {
            Console.WriteLine($"Partido entre {this.Local.Nombre} y {this.Visitante.Nombre} se jugará el {this.Fecha.ToShortDateString()} en {this.Lugar}");



         }
    }
}
