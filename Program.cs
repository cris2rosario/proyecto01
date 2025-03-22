using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia_2
{
    internal class Program
    {
        class Hamburguesa
        {
            public string TipoPan { get; set; }
            public string TipoCarne { get; set; }
            public double PrecioBase { get; set; }
            public List<(string, double)> IngredientesAdicionales { get; set; } = new List<(string, double)>();
            public int MaxIngredientes { get; set; } = 4;

            public Hamburguesa(string tipoPan, string tipoCarne, double precioBase)
            {
                TipoPan = tipoPan;
                TipoCarne = tipoCarne;
                PrecioBase = precioBase;
            }

            public void AgregarIngrediente(string ingrediente, double precio)
            {
                if (IngredientesAdicionales.Count < MaxIngredientes)
                {
                    IngredientesAdicionales.Add((ingrediente, precio));
                }
                else
                {
                    Console.WriteLine("No se pueden agregar más ingredientes adicionales.");
                }
            }

            public double CalcularPrecioTotal()
            {
                double total = PrecioBase;
                foreach (var ingrediente in IngredientesAdicionales)
                {
                    total += ingrediente.Item2;
                }
                return total;
            }

            public void MostrarDetalle()
            {
                Console.WriteLine($"Hamburguesa con pan {TipoPan} y carne {TipoCarne}");
                Console.WriteLine($"Precio base: {PrecioBase:C}");
                foreach (var ingrediente in IngredientesAdicionales)
                {
                    Console.WriteLine($"+ {ingrediente.Item1}: {ingrediente.Item2:C}");
                }
                Console.WriteLine($"Total: {CalcularPrecioTotal():C}\n");
            }
        }

        class HamburguesaSaludable : Hamburguesa
        {
            public HamburguesaSaludable(string tipoCarne, double precioBase)
                : base("Pan Integral", tipoCarne, precioBase)
            {
                MaxIngredientes = 6;
            }
        }

        class HamburguesaPremium : Hamburguesa
        {
            public HamburguesaPremium(string tipoCarne, double precioBase)
                : base("Pan Brioche", tipoCarne, precioBase)
            {
                IngredientesAdicionales.Add(("Papas", 3.00));
                IngredientesAdicionales.Add(("Bebida", 2.50));
                MaxIngredientes = 0; // No se permiten más adicionales
            }
        }

        class MainProgram
        {
            static void Main()
            {
                Hamburguesa clasica = new Hamburguesa("Pan Blanco", "Res", 5.00);
                clasica.AgregarIngrediente("Lechuga", 0.50);
                clasica.AgregarIngrediente("Tomate", 0.75);
                clasica.MostrarDetalle();

                HamburguesaSaludable saludable = new HamburguesaSaludable("Pollo", 6.50);
                saludable.AgregarIngrediente("Aguacate", 1.00);
                saludable.AgregarIngrediente("Pepino", 0.75);
                saludable.MostrarDetalle();

                HamburguesaPremium premium = new HamburguesaPremium("Angus", 8.00);
                premium.MostrarDetalle();
            }
        }

    }
}
