using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_VÉLIZZAMBRANO.Generales;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Equipo
    {
        // ATRIBUTOS EXISTENTES
        private string nombre;
        private string ciudad;
        private List<Jugador> jugadores;
        private int id;



        // NUEVOS ATRIBUTOS 
        private string directorTecnico;
        private int añoFundacion;
        private double presupuesto;
        private string colorUniforme; // Nuevo atributo para el color del uniforme del equipo



        // PROPIEDADES EXISTENTES
        public string Nombre { get => nombre; set => nombre = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }



        // NUEVAS PROPIEDADES 
        public string DirectorTecnico { get => directorTecnico; set => directorTecnico = value; }
        public int AñoFundacion { get => añoFundacion; set => añoFundacion = value; }
        public double Presupuesto { get => presupuesto; set => presupuesto = value; }
        public string ColorUniforme { get => colorUniforme; set => colorUniforme = value; }
        public int Id { get => id; set => id = value; }



        // CONSTRUCTOR ACTUALIZADO
        public Equipo(string nombre, string ciudad, string directorTecnico, int añoFundacion, double presupuesto)
        {
            // NUEVAS VALIDACIONES
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del equipo no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(directorTecnico))
            {
                throw new ArgumentException("El nombre del Director Técnico no puede estar vacío.");
            }
            if (añoFundacion < 1800 || añoFundacion > DateTime.Now.Year)
            {
                throw new ArgumentException($"El año de fundación debe estar entre 1800 y el año actual ({DateTime.Now.Year}).");
            }
            if (presupuesto < 0)
            {
                throw new ArgumentException("El presupuesto del equipo no puede ser negativo.");
            }

            this.Nombre = nombre;
            this.Ciudad = ciudad;
            this.DirectorTecnico = directorTecnico;
            this.AñoFundacion = añoFundacion;
            this.Presupuesto = presupuesto;
            this.Jugadores = new List<Jugador>();
            if (DateBase.Equipos.Count == 0)
            {
                this.id = 1; // Si no hay equipos, el primer ID será 1
            }
            else
            {
                this.id = DateBase.Equipos.Max(x => x.id) + 1; // Asignar un ID único basado en el máximo existente
            }

        }



        // METODOS EXISTENTES
        public void AgregarJugador(Jugador objJugador)
        {
            if (objJugador == null)
            {
                Console.WriteLine("Error: No se puede agregar un jugador nulo a la lista.");
                return;
            }

            this.Jugadores.Add(objJugador);
            Console.WriteLine($"Jugador {objJugador.Nombre} agregado correctamente al equipo {this.Nombre}.");
        }

        public void ListarPlantilla()
        {
            Console.WriteLine($"La plantilla de {this.Nombre} (Fundado en {this.AñoFundacion}, DT: {this.DirectorTecnico}) es:");
            foreach (Jugador objJugador in Jugadores)
            {
                objJugador.Imprimir();
                Console.WriteLine("----------------------------");
            }
        }

        public void Imprimir()
        {
            Console.WriteLine($"Id: {this.Id}");
            Console.WriteLine($"Equipo: {this.Nombre}");
            Console.WriteLine($"Ciudad: {this.Ciudad}");
            Console.WriteLine($"Director Técnico: {this.DirectorTecnico}");
            Console.WriteLine($"Año de Fundación: {this.AñoFundacion}");
            Console.WriteLine($"Presupuesto: ${this.Presupuesto}");
            Console.WriteLine($"Color del Uniforme: {this.ColorUniforme}");
            Console.WriteLine($"Número de Jugadores: {this.Jugadores.Count}");
            ListarPlantilla();
        }

        public void MostrarResumen()
        {
            Console.WriteLine($"El equipo {this.Nombre} tiene actualmente {this.Jugadores.Count} jugadores registrados.");
        }

        public void MostrarTotalJugadores()
        {
            Console.WriteLine($"El equipo {this.Nombre} tiene actualmente {this.Jugadores.Count} jugadores registrados.\n");
        }
    }
}