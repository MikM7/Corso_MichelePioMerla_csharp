using System;

namespace CalcolatriceApp
{
    public interface IStrategiaOperazione
    {
        double Calcola(double a, double b);
    }
    public class SommaStrategia : IStrategiaOperazione
    {
        public double Calcola(double a, double b) => a + b;
    }

    public class SottrazioneStrategia : IStrategiaOperazione
    {
        public double Calcola(double a, double b) => a - b;
    }

    public class MoltiplicazioneStrategia : IStrategiaOperazione
    {
        public double Calcola(double a, double b) => a * b;
    }

    public class DivisioneStrategia : IStrategiaOperazione
    {
        public double Calcola(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("⚠️ Errore: Impossibile dividere per zero!");
                return 0;
            }
            return a / b;
        }
    }
    public class Calcolatrice
    {
        private IStrategiaOperazione _strategia;
        public void ImpostaStrategia(IStrategiaOperazione nuovaStrategia)
        {
            _strategia = nuovaStrategia;
        }

        public void EseguiOperazione(double a, double b)
        {
            if (_strategia == null)
            {
                Console.WriteLine(" Seleziona prima un'operazione!");
                return;
            }

            double risultato = _strategia.Calcola(a, b);
            Console.WriteLine("\n*********************************");
            Console.WriteLine($"* RISULTATO: {risultato,-18} *");
            Console.WriteLine("*********************************");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calcolatrice miaCalcolatrice = new Calcolatrice();
            bool continua = true;

            while (continua)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n=== CALCOLATRICE DINAMICA STRATEGY ===");
                Console.ResetColor();

                try
                {
                    Console.Write("Inserisci il primo numero: ");
                    double n1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Inserisci il secondo numero: ");
                    double n2 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("\nScegli l'operazione:");
                    Console.WriteLine("CLICCA 1. (+) Somma");
                    Console.WriteLine("CLICCA 2. (-) Sottrazione");
                    Console.WriteLine("CLICCA 3. (*) Moltiplicazione");
                    Console.WriteLine("CLICCA 4. (/) Divisione");
                    Console.WriteLine("CLICCA 0. Esci");
                    Console.Write("Scelta > ");
                    string scelta = Console.ReadLine();

                    switch (scelta)
                    {
                        case "1": miaCalcolatrice.ImpostaStrategia(new SommaStrategia()); break;
                        case "2": miaCalcolatrice.ImpostaStrategia(new SottrazioneStrategia()); break;
                        case "3": miaCalcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia()); break;
                        case "4": miaCalcolatrice.ImpostaStrategia(new DivisioneStrategia()); break;
                        case "0": continua = false; continue;
                        default: Console.WriteLine("Scelta non valida!"); continue;
                    }

                    miaCalcolatrice.EseguiOperazione(n1, n2);
                }
                catch (Exception)
                {
                    Console.WriteLine(" Errore: Inserisci solo numeri validi!");
                }
            }

            Console.WriteLine("\nProgramma terminato. Grazie per aver usato Strategy Calc!");
        }
    }
}