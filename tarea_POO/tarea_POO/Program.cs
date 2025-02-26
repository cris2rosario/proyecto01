using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea_POO
{
    internal class Program
    {
      
            class Motor
        {
            public int LitrosAceite { get; private set; }
            public int Potencia { get; }

            public Motor(int potencia)
            {
                Potencia = potencia;
                LitrosAceite = 0;
            }

            public void AgregarAceite(int cantidad)
            {
                LitrosAceite += cantidad;
            }
        }

        class Coche
        {
            public string Marca { get; }
            public string Modelo { get; }
            public Motor Motor { get; }
            public double CostoAverias { get; private set; }
            public List<string> HistorialAverias { get; }

            public Coche(string marca, string modelo, int potenciaMotor)
            {
                Marca = marca;
                Modelo = modelo;
                Motor = new Motor(potenciaMotor);
                CostoAverias = 0;
                HistorialAverias = new List<string>();
            }

            public void AgregarAveria(string averia, double costo)
            {
                CostoAverias += costo;
                HistorialAverias.Add(averia);

                if (averia.ToLower() == "aceite")
                {
                    Motor.AgregarAceite(10);
                }
            }
        }

        class Garaje
        {
            private Coche _cocheActual;
            private int _cochesAtendidos;

            public bool RecibirCoche(Coche coche, string averia)
            {
                if (_cocheActual != null)
                    return false;

                _cocheActual = coche;
                _cochesAtendidos++;

                double costo = new Random().Next(150, 600);
                coche.AgregarAveria(averia, costo);

                return true;
            }

            public void LiberarCoche()
            {
                _cocheActual = null;
            }
        }

        class Programa
        {
            static void Main()
            {
                Garaje taller = new Garaje();
                Coche auto1 = new Coche("Mazda", "CX-5", 130);
                Coche auto2 = new Coche("Ford", "Focus", 150);

                string[] averias = { "transmisión", "aceite", "frenos", "motor" };
                foreach (var averia in averias)
                {
                    taller.RecibirCoche(auto1, averia);
                    taller.LiberarCoche();
                    taller.RecibirCoche(auto2, averia);
                    taller.LiberarCoche();
                }

                MostrarInfoCoche(auto1);
                MostrarInfoCoche(auto2);
            }

            static void MostrarInfoCoche(Coche coche)
            {
                Console.WriteLine($"{coche.Marca} {coche.Modelo}: ${coche.CostoAverias} en reparaciones, {coche.Motor.LitrosAceite} litros de aceite.");
                Console.WriteLine("Historial de averías: " + string.Join(", ", coche.HistorialAverias));
            }
        }

    }
}

