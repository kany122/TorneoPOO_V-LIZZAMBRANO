using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Jugador
    {
        // ATRIBUTOS EXISTENTES
        private string nombre;
        private int edad;
        private int numero;
        private string posicion;

        // NUEVOS ATRIBUTOS 
        private string nacionalidad;
        private int golesMarcados;
        private double estatura;

        // PROPIEDADES EXISTENTES
        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Posicion { get => posicion; set => posicion = value; }

        // NUEVAS PROPIEDADES
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public int GolesMarcados { get => golesMarcados; set => golesMarcados = value; }
        public double Estatura { get => estatura; set => estatura = value; }

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
    }
}