using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arreglos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Seleccione el programa que desea ejecutar (1-6):");
            Console.WriteLine("1. Determinar la posición del mayor número en el arreglo");
            Console.WriteLine("2. Determinar la posición del mayor número par en el arreglo");
            Console.WriteLine("3. Determinar la posición del mayor número primo en el arreglo");
            Console.WriteLine("4. Contar cuántos números comienzan con un dígito primo");
            Console.WriteLine("5. Determinar la posición del número primo con más dígitos pares");
            Console.WriteLine("6. Determinar las posiciones de los números con más de 3 dígitos");
            int option = int.Parse(Console.ReadLine());

            string description = "";
            if (option == 1)
                description = "Este programa encuentra la posición del número más grande en el arreglo.";
            else if (option == 2)
                description = "Este programa encuentra la posición del número par más grande en el arreglo.";
            else if (option == 3)
                description = "Este programa encuentra la posición del número primo más grande en el arreglo.";
            else if (option == 4)
                description = "Este programa cuenta cuántos números en el arreglo comienzan con un dígito primo.";
            else if (option == 5)
                description = "Este programa encuentra la posición del número primo que tiene más dígitos pares.";
            else if (option == 6)
                description = "Este programa encuentra las posiciones de los números con más de 3 dígitos en el arreglo.";
            else
            {
                Console.WriteLine("Opción no válida");
                return;
            }

            Console.WriteLine(description);

            int[] numbers = new int[10];
            Console.WriteLine("Ingrese 10 números enteros:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Número {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            switch (option)
            {
                case 1:
                    Console.WriteLine($"Posición del mayor número: {FindMaxPosition(numbers)}");
                    break;
                case 2:
                    Console.WriteLine($"Posición del mayor número par: {FindMaxEvenPosition(numbers)}");
                    break;
                case 3:
                    Console.WriteLine($"Posición del mayor número primo: {FindMaxPrimePosition(numbers)}");
                    break;
                case 4:
                    Console.WriteLine($"Cantidad de números que comienzan en dígito primo: {CountNumbersStartingWithPrime(numbers)}");
                    break;
                case 5:
                    Console.WriteLine($"Posición del número primo con más dígitos pares: {FindPrimeWithMostEvenDigitsPosition(numbers)}");
                    break;
                case 6:
                    Console.WriteLine($"Posiciones de números con más de 3 dígitos: {string.Join(", ", FindNumbersWithMoreThanThreeDigits(numbers))}");
                    break;
            }
        }

        static int FindMaxPosition(int[] arr)
        {
            return Array.IndexOf(arr, arr.Max());
        }

        static int FindMaxEvenPosition(int[] arr)
        {
            int maxEven = arr.Where(x => x % 2 == 0).DefaultIfEmpty(int.MinValue).Max();
            return Array.IndexOf(arr, maxEven);
        }

        static int FindMaxPrimePosition(int[] arr)
        {
            var primes = arr.Where(IsPrime).ToArray();
            if (primes.Length == 0) return -1;
            return Array.IndexOf(arr, primes.Max());
        }

        static int CountNumbersStartingWithPrime(int[] arr)
        {
            return arr.Count(x => IsPrime(int.Parse(x.ToString()[0].ToString())));
        }

        static int FindPrimeWithMostEvenDigitsPosition(int[] arr)
        {
            var primeNumbers = arr.Where(IsPrime).ToList();
            if (primeNumbers.Count == 0) return -1;

            var primeWithMostEvenDigits = primeNumbers.OrderByDescending(x => x.ToString().Count(d => "02468".Contains(d))).FirstOrDefault();
            return Array.IndexOf(arr, primeWithMostEvenDigits);
        }

        static int[] FindNumbersWithMoreThanThreeDigits(int[] arr)
        {
            return arr.Select((x, i) => new { x, i }).Where(n => Math.Abs(n.x) >= 1000).Select(n => n.i).ToArray();
        }

        static bool IsPrime(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i * i <= num; i++)
                if (num % i == 0) return false;
            return true;

        }
    }
}
