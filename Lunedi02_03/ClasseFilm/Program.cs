using System;

namespace VideotecaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Film[] raccolta = new Film[3];

            // 1. Inserimento (Il tuo codice)
            for (int i = 0; i < raccolta.Length; i++)
            {
                Console.WriteLine($"\nInserisci i dati del Film {i + 1}:");
                Console.Write("Titolo: "); string t = Console.ReadLine() ?? "";
                Console.Write("Regista: "); string r = Console.ReadLine() ?? "";
                Console.Write("Anno: "); int a = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Genere: "); string g = Console.ReadLine() ?? "";
                raccolta[i] = new Film(t, r, a, g);
            }

            // 2. Stampa Elenco
            Console.WriteLine("\n--- ELENCO FILM INSERITI ---");
            // Una sola riga per non farli volare
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine($"| {"TITOLO",-20} | {"REGISTA",-18} | {"ANNO",-5} | {"GENERE",-12} |");
            Console.WriteLine("------------------------------------------------------------------");
            
            for (int i = 0; i < raccolta.Length; i++)
            {
                Console.Write(raccolta[i].ToString());
            }

            // 3. Ricerca
            Console.Write("Quale genere vuoi cercare? ");
            string cercaGenere = Console.ReadLine() ?? "";

            Console.WriteLine($"\nFilm di genere '{cercaGenere}':");
            Console.WriteLine("------------------------------------------------------------------");
            
            bool trovato = false;
            for (int i = 0; i < raccolta.Length; i++)
            {
                if (raccolta[i].Genere.ToLower() == cercaGenere.ToLower())
                {
                    Console.Write(raccolta[i].ToString());
                    trovato = true;
                }
            }

            if (!trovato) Console.WriteLine("Nessun film trovato.");

            Console.WriteLine("\nPremi un tasto per chiudere.");
            Console.ReadKey();
        }
    }
}