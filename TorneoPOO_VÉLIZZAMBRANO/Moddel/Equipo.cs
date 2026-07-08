using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public List<Jugador> Jugadores { get; set; }



        public Equipo(string nombre, string ciudad)
        {
            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.Jugadores = new List<Jugador>();
        }



        //impedir agregar jugador nulo
        public void AgregarJugador(Jugador objJugador)
        {
           
            if (objJugador == null)
            {
                Console.WriteLine("Error: No se puede agregar un jugador nulo a la lista.");
                return; 
            }

            this.Jugadores.Add(objJugador);
            Console.WriteLine($"Jugador {objJugador.Nombre} agregado correctamente");
        }

        public void ListarPlantilla()
        {
            Console.WriteLine($"La lista de jugadores del equipo {this.Nombre} de la ciudad de {this.Ciudad} es:");
            foreach (Jugador objJugador in Jugadores)
            {
                objJugador.Presentar();
            }
        }

        public void MostrarResumen()
        {
            Console.WriteLine($"El equipo {this.Nombre} tiene actualmente {this.Jugadores.Count} jugadores registrados.");
        }



    }
}
