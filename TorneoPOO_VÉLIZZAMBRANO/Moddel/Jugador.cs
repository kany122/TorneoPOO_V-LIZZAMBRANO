using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Jugador
    {
         //ATRIBUTOS O CARACTERISCAS
        public string Nombre { get; set; }
        
        public int Edad { get; set; }

        public int Numero { get; set; }

        public string Posicion { get; set; }


        //CONSTRUCTOR
        public Jugador(string nombre, int edad, int numero, string posicion)
        {
            if (!EsMayorEdad(edad))
            {
                throw new Exception("El jugador debe ser mayor de edad");
            }
            if (!EsNumeroValido(numero))    
            {
                throw new Exception("El número del jugador no es válido");
            }

            this.Nombre = nombre;
            this.Edad = edad;
            this.Numero = numero;
            this.Posicion = posicion;
        }






        //METODOS, COMPORTAMIENTOS O FUNCIONES
        public void Presentar()
        {
            Console.WriteLine($"Hola soy {this.Nombre} tengo {this.Edad} años y mi número es el {this.Numero}");
        }

        public Boolean EsMayorEdad(int edad)
        {
            return edad >= 18;
        }

        public Boolean EsNumeroValido(int numero)
        {
            if (numero > 0 && numero < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CambiarPosicion(string nuevaPosicion)
        {
            Console.WriteLine($"El jugador {this.Nombre} ha cambiado su posición de '{this.Posicion}' a '{nuevaPosicion}'.");
            this.Posicion = nuevaPosicion;
        }
    }
}
