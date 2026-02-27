using System;

namespace EserciziProgrammazione
{
    

    public class Studente
    {
        public string Nome;
        public int Matricola;
        public double MediaVoti;
    }

   public class Persona
    {
        public string Nome;
        public string Cognome;
        public int AnnoNascita;
    }

    public class Operazioni
    {
        public int Somma(int a, int b) => a + b;
        public int Moltiplica(int a, int b) => a * b;

        public void StampaRisultato(string operazione, int risultato)
        {
            Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
        }
    }

    public class Program
    {
        public static void Main()
        {
            // 1. ESERCIZIO STUDENTE
            Console.WriteLine("--- Esercizio Studente ---");
            Studente s1 = new Studente { Nome = "Michele Merla", Matricola = 0747, MediaVoti = 28.5 };
            Console.WriteLine($"Studente: {s1.Nome}, Media: {s1.MediaVoti}\n");

            // 2. ESERCIZIO PERSONA
            Console.WriteLine("--- Esercizio Persona ---");
            Persona p1 = new Persona { Nome = "Antonio", Cognome = "Natale", AnnoNascita = 1995 };
            Console.WriteLine($"{p1.Nome} {p1.Cognome} è nato nel {p1.AnnoNascita}\n");

            // 3. ESERCIZIO OPERAZIONI
            Console.WriteLine("--- Esercizio Operazioni ---");
            Operazioni op = new Operazioni();
            
            Console.Write("Inserisci il primo numero: ");
            int n1 = int.Parse(Console.ReadLine());
            Console.Write("Inserisci il secondo numero: ");
            int n2 = int.Parse(Console.ReadLine());

            op.StampaRisultato("Somma", op.Somma(n1, n2));
            op.StampaRisultato("Moltiplica", op.Moltiplica(n1, n2));

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}