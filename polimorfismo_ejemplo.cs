using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_polimorfica
{
    using System;

    namespace PolimorfismoEjemplo
    {
        // Clase base
        public class Ave
        {
            public string Nombre { get; set; }
            public string Color { get; set; }

            // Método común para mostrar información
            public void MostrarInfo()
            {
                Console.WriteLine($"Ave: {Nombre}, Color: {Color}");
            }

            // Método que será sobrescrito en las clases derivadas
            public virtual void ComportamientoDeVuelo()
            {
                Console.WriteLine("El ave vuela de forma general.");
            }

            // Método que será sobrescrito en las clases derivadas
            public virtual void Sonido()
            {
                Console.WriteLine("El ave hace un sonido.");
            }
        }

        // Clase derivada para un tipo específico de vuelo
        public class VueloRápido : Ave
        {
            public override void ComportamientoDeVuelo()
            {
                Console.WriteLine($"{Nombre} vuela rápidamente por el cielo.");
            }
        }

        // Clase derivada para otro tipo de vuelo
        public class VueloLento : Ave
        {
            public override void ComportamientoDeVuelo()
            {
                Console.WriteLine($"{Nombre} vuela lentamente, disfrutando del aire.");
            }
        }

        // Clase derivada para un sonido específico
        public class SonidoFuerte : Ave
        {
            public override void Sonido()
            {
                Console.WriteLine($"{Nombre} hace un sonido fuerte y ruidoso.");
            }
        }

        // Clase derivada para un sonido suave
        public class SonidoSuave : Ave
        {
            public override void Sonido()
            {
                Console.WriteLine($"{Nombre} hace un sonido suave y melodioso.");
            }
        }

        // Clase principal para probar el polimorfismo
        class Program
        {
            static void Main(string[] args)
            {
                // Instanciando las clases derivadas con comportamientos específicos
                Ave aguila = new VueloRápido { Nombre = "Águila Real", Color = "Marrón" };
                Ave paloma = new VueloLento { Nombre = "Paloma Mensajera", Color = "Blanca" };
                Ave loro = new SonidoFuerte { Nombre = "Loro Verde", Color = "Verde" };
                Ave canario = new SonidoSuave { Nombre = "Canario", Color = "Amarillo" };

                // Mostrar información y comportamientos para cada instancia
                aguila.MostrarInfo();
                aguila.ComportamientoDeVuelo();
                aguila.Sonido();
                Console.WriteLine();

                paloma.MostrarInfo();
                paloma.ComportamientoDeVuelo();
                paloma.Sonido();
                Console.WriteLine();

                loro.MostrarInfo();
                loro.ComportamientoDeVuelo();
                loro.Sonido();
                Console.WriteLine();

                canario.MostrarInfo();
                canario.ComportamientoDeVuelo();
                canario.Sonido();
            }
        }
    }

}
 