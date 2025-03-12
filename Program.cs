using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centralita
{
    public class Llamada
    {
        protected string numOrigen;
        protected string numDestino;
        protected double duracion;

        public Llamada(string origen, string destino, double duracion)
        {
            this.numOrigen = origen;
            this.numDestino = destino;
            this.duracion = duracion;
        }

        public string GetNumOrigen() => numOrigen;
        public string GetNumDestino() => numDestino;
        public double GetDuracion() => duracion;

        public virtual double CalcularPrecio() => 0.0;
    }

    public class LlamadaLocal : Llamada
    {
        private const double PRECIO_POR_SEGUNDO = 0.15;

        public LlamadaLocal(string origen, string destino, double duracion)
        : base(origen, destino, duracion) { }

        public override double CalcularPrecio() => duracion * PRECIO_POR_SEGUNDO;
    }

    public class LlamadaProvincial : Llamada
    {
        private int franja;

        public LlamadaProvincial(string origen, string destino, double duracion, int franja)
        : base(origen, destino, duracion)
        {
            this.franja = franja;
        }

        public override double CalcularPrecio()
        {
            double precioPorSegundo = 0.0;

            switch (franja)
            {
                case 1:
                    precioPorSegundo = 0.20;
                    break;
                case 2:
                    precioPorSegundo = 0.25;
                    break;
                case 3:
                    precioPorSegundo = 0.30;
                    break;
                default:
                    throw new ArgumentException("Franja horaria inválida");
            }

            return duracion * precioPorSegundo;
        }
    }

    public class Centralita
    {
        private List<Llamada> llamadas = new List<Llamada>();
        private int contadorLlamadas = 0;
        private double totalFacturado = 0.0;

        public void RegistrarLlamada(Llamada llamada)
        {
            llamadas.Add(llamada);
            contadorLlamadas++;
            totalFacturado += llamada.CalcularPrecio();
            Console.WriteLine($"Llamada registrada: {llamada.GetNumOrigen()} a {llamada.GetNumDestino()} - Duración: {llamada.GetDuracion()}s - Precio: {llamada.CalcularPrecio()}€");
        }

        public int GetTotalLlamadas() => contadorLlamadas;
        public double GetTotalFacturado() => totalFacturado;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Centralita centralita = new Centralita();

            // Registrar llamadas
            centralita.RegistrarLlamada(new LlamadaLocal("123456789", "987654321", 60));
            centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 80, 2));
            centralita.RegistrarLlamada(new LlamadaProvincial("123456789", "987654321", 120, 1));

            // Informe de total de llamadas y facturación
            Console.WriteLine($"Total de llamadas: {centralita.GetTotalLlamadas()}");
            Console.WriteLine($"Total facturado: {centralita.GetTotalFacturado()}€");
        }
    }
}
