using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bisiesto_Cris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce el año, para revisar si es bisiesto:  ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int año))
            {
                if (EsAñoBisiesto(año))
                {
                    Console.WriteLine($"El año {año} es bisiesto.");
                }
                else
                {
                    Console.WriteLine($"El año {año} no es bisiesto.");
                }
            }
            else
            {
               Console.WriteLine("Favor introduce un numero entero.");
            }
        }

        static bool EsAñoBisiesto(int año)
        {
           return (año % 4 == 0 && (año % 100 != 0 || año % 400 == 0));
        }

    }
    }

