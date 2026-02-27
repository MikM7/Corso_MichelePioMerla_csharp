using System;

namespace GestioneDati
{

    class Studente
    {
        public string Nome;
        public int Matricola;
        public double MediaVoti;

        public Studente(string nome, int matricola, double mediaVoti)
        {
            Nome = nome;
            Matricola = matricola;
            MediaVoti = mediaVoti;
        }
    }

    class Persona
    {
        public string Nome;
        public string Cognome;
        public int AnnoNascita;

        public Persona(string nome, string cognome, int annoNascita)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoNascita = annoNascita;
        }
    }

    class Operazioni
    {
        
        public int Somma(int a, int b)
        {
            return a + b;
        }

        public int Moltiplica(int a, int b)
        {
            return a * b;
        }

        public void StampaRisultato(string operazione, int risultato)
        {
            Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
        }
    }


   public class Program
    {
        public static void Main(Strings[]args)
        {
            // 1. GESTIONE STUDENTE
            Console.WriteLine("\n=== DATI STUDENTE ===");
           
            Studente s1 = new Studente("Marco Dos Santos", 12345, 28.5);
            Studente s2 = new Studente("Lucia Ocampos", 78900, 26.5);

            Console.WriteLine($"Studente: {s1.Nome} | Matricola: {s1.Matricola} | Media: {s1.MediaVoti}");
            Console.WriteLine($"Studente: {s2.Nome} | Matricola: {s2.Matricola} | Media: {s2.MediaVoti}\n");

            // 2. GESTIONE PERSONA
            Console.WriteLine("=== DATI PERSONA ===");
            
            Persona p1 = new Persona("Sara", "Rossi", 1995);
            
            Console.WriteLine($"Nome Completo: {p1.Nome} {p1.Cognome} | Anno: {p1.AnnoNascita}\n");

            // 3. ESE DUE NUM SOMMA E PRODOTTI
            Console.WriteLine("=== OPERAZIONI MATEMATICHE ===");
            Operazioni calcoli = new Operazioni();
            
            Console.Write("Inserisci il primo valore: ");
            int n1 = int.Parse(Console.ReadLine());
            
            Console.Write("Inserisci il secondo valore: ");
            int n2 = int.Parse(Console.ReadLine());

            int risSomma = calcoli.Somma(n1, n2);
            int risMoltiplica = calcoli.Moltiplica(n1, n2);

            calcoli.StampaRisultato("Somma", risSomma);
            calcoli.StampaRisultato("Moltiplicazione", risMoltiplica);

            Console.WriteLine("\nPremi un tasto per terminare il programma...");
            Console.ReadKey();
        }
    }
}