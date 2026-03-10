using System;


namespace EsercitoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldato> plotone = new List<Soldato>();
            bool esci = false;

            while (!esci)
            {
                Console.WriteLine("\n=== GESTIONALE PLOTONE ===");
                Console.WriteLine("1. Aggiungi Fante");
                Console.WriteLine("2. Aggiungi Artigliere");
                Console.WriteLine("3. Visualizza Plotone");
                Console.WriteLine("4. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        Fante f = new Fante();
                        Console.Write("Nome: "); f.Nome = Console.ReadLine() ?? "";
                        Console.Write("Grado: "); f.Grado = Console.ReadLine() ?? "";
                        Console.Write("Anni Servizio: "); f.AnniServizio = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Arma: "); f.Arma = Console.ReadLine() ?? "";
                        plotone.Add(f);
                        break;

                    case "2":
                        Artigliere a = new Artigliere();
                        Console.Write("Nome: "); a.Nome = Console.ReadLine() ?? "";
                        Console.Write("Grado: "); a.Grado = Console.ReadLine() ?? "";
                        Console.Write("Anni Servizio: "); a.AnniServizio = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Calibro (mm): "); a.Calibro = int.Parse(Console.ReadLine() ?? "1");
                        plotone.Add(a);
                        break;

                    case "3":
                        Console.WriteLine("\n--- MEMBRI DEL PLOTONE ---");
                        if (plotone.Count == 0) Console.WriteLine("Nessun soldato registrato.");
                        foreach (Soldato s in plotone)
                        {
                            s.Descrizione(); // Chiama l'override corretto grazie al polimorfismo
                        }
                        break;

                    case "4":
                        esci = true;
                        break;
                }
            }
        }
    }
}