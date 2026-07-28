using System;
using System.Collections.Generic;
using System.Text;
using TorneoPOO_VÉLIZZAMBRANO.Generales;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Jugador
    {
        // ATRIBUTOS EXISTENTES
        private string nombre;
        private int edad;
        private int numero;
        private string posicion;
        private int id; 

        // NUEVOS ATRIBUTOS 
        private string nacionalidad;
        private int golesMarcados;
        private double estatura;
        private string fichado; // Nuevo atributo para indicar si el jugador está fichado o no
        private Equipo equipo_actual; // Nuevo atributo para almacenar el equipo actual del jugador

        // PROPIEDADES EXISTENTES
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Posicion { get => posicion; set => posicion = value; }

        // NUEVAS PROPIEDADES
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public int GolesMarcados { get => golesMarcados; set => golesMarcados = value; }
        public double Estatura { get => estatura; set => estatura = value; }
        public string Fichado { get => fichado; }

        public int Id { get => id; set => id = value; } 

        // CONSTRUCTOR ACTUALIZADO
        public Jugador(string nombre, int edad, int numero, string posicion, string nacionalidad, int golesMarcados, double estatura)
        {
            // Validaciones existentes
            if (!EsMayorEdad(edad))
            {
                throw new ArgumentException("El jugador debe ser mayor de edad.");
            }
            if (!EsNumeroValido(numero))
            {
                throw new ArgumentException("El número del jugador no es válido (debe estar entre 1 y 99).");
            }

            // NUEVAS VALIDACIONES
            if (string.IsNullOrWhiteSpace(nacionalidad))
            {
                throw new ArgumentException("La nacionalidad no puede estar vacía.");
            }
            if (golesMarcados < 0)
            {
                throw new ArgumentException("La cantidad de goles marcados no puede ser negativa.");
            }
            if (estatura < 1.0 || estatura > 2.5)
            {
                throw new ArgumentException("La estatura debe estar en un rango realista (entre 1.0 y 2.5 metros).");
            }

            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
            this.Nacionalidad = nacionalidad;
            this.GolesMarcados = golesMarcados;
            this.Estatura = estatura;
            this.fichado = "No"; // Inicialmente, el jugador no está fichado
            this.equipo_actual = null; // Inicialmente, el jugador no pertenece a ningún equipo
            if (DateBase.Jugadores.Count == 0)
            {
                this.id = 1; // Si no hay jugadores, el primer ID será 1
            }
            else
            {
                this.id = DateBase.Jugadores.Max(x => x.id) + 1; // Asignar un ID único basado en el máximo existente
            }
        }

        // METODOS EXISTENTES
        public void Presentar()
        {
            Console.WriteLine($"Hola, soy {this.Nombre} ({this.Nacionalidad}), tengo {this.Edad} años, mido {this.Estatura}m, llevo {this.GolesMarcados} goles y mi número es el {this.Numero}.");
        }

        public Boolean EsMayorEdad(int edad)
        {
            return edad >= 18;
        }

        public Boolean EsNumeroValido(int numero)
        {
            return numero > 0 && numero < 100;
        }

        public void CambiarPosicion(string nuevaPosicion)
        {
            Console.WriteLine($"El jugador {this.Nombre} ha cambiado su posición de '{this.Posicion}' a '{nuevaPosicion}'.");
            this.Posicion = nuevaPosicion;
        }

        public void Imprimir()
        {
            Console.WriteLine($"Id: {this.Id}");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Edad: {this.Edad}");
            Console.WriteLine($"Número: {this.Numero}");
            Console.WriteLine($"Posición: {this.Posicion}");
            Console.WriteLine($"Nacionalidad: {this.Nacionalidad}");
            Console.WriteLine($"Goles Marcados: {this.GolesMarcados}");
            Console.WriteLine($"Estatura: {this.Estatura}m");
            Console.WriteLine($"Fichado: {this.Fichado}");
            Console.WriteLine($"Equipo Actual: {(this.equipo_actual != null ? this.equipo_actual.Nombre : "Sin equipo")}");
        }

        public void Fichar(Equipo objEquipoFichado)
        {
            this.fichado = "Sí";
            this.equipo_actual = objEquipoFichado;
        }


    }
}