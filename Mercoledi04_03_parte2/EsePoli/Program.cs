using System;

namespace OfficinaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Veicolo> officina = new List<Veicolo>();

            officina.Add(new Auto { Targa = "AA123BB" });
            officina.Add(new Moto { Targa = "CC456DD" });
            officina.Add(new Camion { Targa = "EE789FF" });

            Console.WriteLine("=== BENVENUTI NELL'OFFICINA MECCANICA ===\n");

            
            foreach (Veicolo v in officina)
            {
                
                v.Ripara();
            }

            Console.WriteLine("\nLavori completati. Premi un tasto per uscire.");
            Console.ReadKey();
        }
    }
}