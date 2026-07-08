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

        //METODOS, COMPORTAMIENTOS O FUNCIONES
        public void Presentar()
        {
            Console.WriteLine($"Hola soy {this.Nombre} tengo {this.Edad} años y mi número es el {this.Numero}");
        }

        public Boolean EsMayorEdad()
        {
            if (this.Edad >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean EsNumeroValido()
        {
            if (this.Numero >0 && this.Numero < 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
