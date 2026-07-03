using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoPOO_VÉLIZZAMBRANO.Moddel
{
    public class Equipo
    {
        
        public string Nombre { get; set; }

        public string Origen { get; set; }

        public int AñoFundacion { get; set; }

        public int NumeroIntegrantes { get; set; }

        public string Entrenador { get; set; }

      

        //Acciones agregar jugador, listar plantilla.
        public void PresentarEquipo()
        {
            Console.WriteLine($"El equipo {this.Nombre} fue fundado en el año {this.AñoFundacion}, tiene {this.NumeroIntegrantes} integrantes y su entrenador es {this.Entrenador}");
        }





    }
}
