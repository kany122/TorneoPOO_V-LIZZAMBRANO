using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Partido
    {
        // ATRIBUTOS EXISTENTES
        private Equipo local;
        private Equipo visitante;
        private DateTime fecha;
        private string Lugar;



        // NUEVOS ATRIBUTOS 
        private string arbitroPrincipal;
        private double precioEntrada;
        private bool esAsistenciaClave;



        // PROPIEDADES EXISTENTES
        public Equipo Local { get => local; set => local = value; }
        public Equipo Visitante { get => visitante; set => visitante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Lugar1 { get => Lugar; set => Lugar = value; }



        // NUEVAS PROPIEDADES 
        public string ArbitroPrincipal { get => arbitroPrincipal; set => arbitroPrincipal = value; }
        public double PrecioEntrada { get => precioEntrada; set => precioEntrada = value; }
        public bool EsAsistenciaClave { get => esAsistenciaClave; set => esAsistenciaClave = value; }



        // CONSTRUCTOR ACTUALIZADO
        public Partido(Equipo local, Equipo visitante, DateTime fecha, string lugar, string arbitroPrincipal, double precioEntrada, bool esAsistenciaClave)
        {

            // Validaciones de equipos
            if (local == null || visitante == null)
            {
                Console.WriteLine("Error: Los equipos local y visitante no pueden ser nulos.");
                return;
            }

            if (local.Nombre == visitante.Nombre)
            {
                Console.WriteLine("Error: El equipo local y el visitante no pueden ser el mismo.");
                return;
            }


            // NUEVAS VALIDACIONES
            if (string.IsNullOrWhiteSpace(arbitroPrincipal))
            {
                throw new ArgumentException("Debe asignarse un árbitro principal para el partido.");
            }
            if (precioEntrada < 0)
            {
                throw new ArgumentException("El precio de la entrada no puede ser negativo.");
            }

            this.Local = local;
            this.Visitante = visitante;
            this.Fecha = fecha;
            this.Lugar1 = lugar;
            this.ArbitroPrincipal = arbitroPrincipal;
            this.PrecioEntrada = precioEntrada;
            this.EsAsistenciaClave = esAsistenciaClave;
        }



        // METODOS EXISTENTES
        public void MostrarResumen()
        {
            string tipoPartido = EsAsistenciaClave ? "¡PARTIDO DE ALTO RIESGO / CLAVE!" : "Partido Regular";
            Console.WriteLine($"[{tipoPartido}] {this.Local.Nombre} vs {this.Visitante.Nombre} se jugará el {this.Fecha.ToShortDateString()} en {this.Lugar1}.");
            Console.WriteLine($"Árbitro: {this.ArbitroPrincipal} | Precio Entrada: ${this.PrecioEntrada}");
        }

        public void CambiarSede(string nuevoLugar)
        {
            Console.WriteLine($"[AVISO]: El partido ha sido reprogramado de '{this.Lugar1}' hacia: '{nuevoLugar}'.");
            this.Lugar1 = nuevoLugar;
        }
    }
}