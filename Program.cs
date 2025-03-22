using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_Repaso
{
    internal class Program
    {
            class Autobus
            {
            public string Nombre { get; set; }
            public int CapacidadTotal { get; set; }
            public int PasajerosActuales { get; set; }
            public int PrecioPasaje { get; set; }

            public Autobus(string nombre, int capacidadTotal, int precioPasaje)
            {
                Nombre = nombre;
                CapacidadTotal = capacidadTotal;
                PrecioPasaje = precioPasaje;
                PasajerosActuales = 0;
            }

            public void VenderPasaje(int cantidad)
            {
                if (PasajerosActuales + cantidad <= CapacidadTotal)
                {
                    PasajerosActuales += cantidad;
                }
                else
                {
                    Console.WriteLine("No hay suficientes asientos disponibles.");
                }
            }

            public int CalcularVentas()
            {
                return PasajerosActuales * PrecioPasaje;
            }

            public int AsientosDisponibles()
            {
                return CapacidadTotal - PasajerosActuales;
            }

            public void MostrarEstado()
            {
                Console.WriteLine($"{Nombre} {PasajerosActuales} Pasajeros Ventas {CalcularVentas()}, quedan {AsientosDisponibles()} asientos disponibles");
            }
        
        class Program
        {
            static void Main()
            {
                List<Autobus> autobuses = new List<Autobus>
        {
            new Autobus("Auto Bus Platinum", 22, 1000),
            new Autobus("Auto Bus Gold", 15, 1500)
        };

                autobuses[0].VenderPasaje(5);
                autobuses[1].VenderPasaje(3);

                foreach (var bus in autobuses)
                {
                    bus.MostrarEstado();
                }
            }
        }


    }
}
}
