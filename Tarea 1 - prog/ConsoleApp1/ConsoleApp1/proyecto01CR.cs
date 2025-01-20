using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            while (true)
                {
                    Console.WriteLine("Seleccione el ejercicio que desea ejecutar (1-10) o 0 para salir:");
                    int opcion = int.Parse(Console.ReadLine());

                    if (opcion == 0) break;

                    EjecutarEjercicio(opcion);
                }
        }

            static void EjecutarEjercicio(int opcion)
            {
                switch (opcion)
                {
                    case 1:
                        CalcularSumaDigitos();
                        break;
                    case 2:
                        DeterminarPrimoYNegativo();
                        break;
                    case 3:
                        VerificarDigitosPrimos();
                        break;
                    case 4:
                        VerificarSumaPar();
                        break;
                    case 5:
                        EncontrarPosicionMayor();
                        break;
                    case 6:
                        VerificarMultiploDigitos();
                        break;
                    case 7:
                        DeterminarMayorTresNumeros();
                        break;
                    case 8:
                        VerificarCapicua();
                        break;
                    case 9:
                        CompararSegundoYPenultimo();
                        break;
                    case 10:
                        MostrarRangoNumerico();
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }

            static void CalcularSumaDigitos()
            {
                Console.WriteLine("El ejercicio es: Leer un número entero de dos dígitos y determinar la suma de sus dígitos");
                Console.WriteLine("Ingrese un número entero de dos dígitos:");
                int numero = int.Parse(Console.ReadLine());
                int suma = (numero / 10) + (numero % 10);
                Console.WriteLine($"La suma de los dígitos es: {suma}");
            }

            static void DeterminarPrimoYNegativo()
            {
                Console.WriteLine("El ejercicio es:  Leer un número entero de dos dígitos y determinar si es primo y además si es negativo.");
                Console.WriteLine("Ingrese un número entero de dos dígitos:");
                int valor = int.Parse(Console.ReadLine());
                bool esPrimo = EsPrimo(Math.Abs(valor));
                Console.WriteLine($"El número es {(esPrimo ? "primo" : "no primo")} y {(valor < 0 ? "negativo" : "positivo")}.");
            }

            static void VerificarDigitosPrimos()
            {
            Console.WriteLine("El ejercicio es: Leer un número entero de dos dígitos y determinar si sus dos dígitos son primos.");
            Console.WriteLine("Ingrese un número entero de dos dígitos:");
                int num = int.Parse(Console.ReadLine());
                int digito1 = num / 10;
                int digito2 = num % 10;
                Console.WriteLine($"Ambos dígitos son {(EsPrimo(digito1) && EsPrimo(digito2) ? "primos" : "no primos")}.");
            }

            static void VerificarSumaPar()
            {
            Console.WriteLine("Leer dos números enteros de dos dígitos y determinar si la suma de los dos números origina un número par.");
            Console.WriteLine("Ingrese el primer número entero de dos dígitos:");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el segundo número entero de dos dígitos:");
                int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"La suma de los números es {((num1 + num2) % 2 == 0 ? "par" : "impar")}.");
        }

            static void EncontrarPosicionMayor()
            {
                Console.WriteLine("Leer un número entero de tres dígitos y determinar en qué posición está el mayor dígito.");
                Console.WriteLine("Ingrese un número entero de tres dígitos:");
                int num = int.Parse(Console.ReadLine());
                int[] digitos = { num / 100, (num / 10) % 10, num % 10 };
                int posicion = Array.IndexOf(digitos, Math.Max(digitos[0], Math.Max(digitos[1], digitos[2]))) + 1;
                Console.WriteLine($"El dígito mayor está en la posición: {posicion}");
            }

            static void VerificarMultiploDigitos()
            {
                Console.WriteLine("Leer un número entero de tres dígitos y determinar si algún dígito es múltiplo de los otros.");
                Console.WriteLine("Ingrese un número entero de tres dígitos:");
                int numero = int.Parse(Console.ReadLine());
                int d1 = numero / 100;
                int d2 = (numero / 10) % 10;
                int d3 = numero % 10;
                Console.WriteLine($"Algún dígito es múltiplo de los otros: {(d1 % d2 == 0 || d1 % d3 == 0 || d2 % d3 == 0 ? "Sí" : "No")}");
            }

            static void DeterminarMayorTresNumeros()
            {
                Console.WriteLine(" Leer tres números enteros y determinar cuál es el mayor. Usar solamente dos variables.");
                Console.WriteLine("Ingrese tres números enteros:");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());
                a = Math.Max(a, b);
                a = Math.Max(a, c);
                Console.WriteLine($"El número mayor es: {a}");
            }

            static void VerificarCapicua()
            {
                Console.WriteLine("Leer un número entero de cinco dígitos y determinar si es un número Capicúa. ");
                Console.WriteLine("Ingrese un número entero de cinco dígitos:");
                string valor = Console.ReadLine();
                Console.WriteLine($"El número es {(valor == RevertirTexto(valor) ? "Capicúa" : "no Capicúa")}.");
            }

            static void CompararSegundoYPenultimo()
            {
                Console.WriteLine("Leer un número entero de cuatro dígitos y determinar si el segundo dígito es igual al penúltimo.");
                Console.WriteLine("Ingrese un número entero de cuatro dígitos:");
                string texto = Console.ReadLine();
                Console.WriteLine($"El segundo dígito es {(texto[1] == texto[2] ? "igual" : "diferente")} al penúltimo.");
            }

            static void MostrarRangoNumerico()
            {
            Console.WriteLine("Leer dos números enteros y si la diferencia entre los dos es menor o igual a 10 " +
                "entonces mostrar en pantalla todos los enteros comprendidos entre el menor y el mayor de los números leídos.");
            Console.WriteLine("Ingrese el primer número entero:");
                int inicio = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el segundo número entero:");
                int fin = int.Parse(Console.ReadLine());
                int menor = Math.Min(inicio, fin);
                int mayor = Math.Max(inicio, fin);
                if (mayor - menor <= 10)
                {
                    for (int i = menor; i <= mayor; i++)
                        Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine("La diferencia entre los números es mayor a 10.");
                }
            }

            static bool EsPrimo(int numero)
            {
                if (numero < 2) return false;
                for (int i = 2; i <= Math.Sqrt(numero); i++)
                {
                    if (numero % i == 0) return false;
                }
                return true;
            }

            static string RevertirTexto(string texto)
            {
                char[] caracteres = texto.ToCharArray();
                Array.Reverse(caracteres);
                return new string(caracteres);
            }
        }
    }

