using System;

class Program
{
    static void Main(string[] args)
    {
        string scelta;
        do
        {
            Console.Clear();
            Console.WriteLine("Seleziona il programma da eseguire (1, 2 o 3) oppure 0 per uscire:");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    EseguiProgramma1();
                    break;
                case "2":
                    EseguiProgramma2();
                    break;
                case "3":
                    EseguiProgramma3();
                    break;
                case "0":
                    Console.WriteLine("Uscita in corso...");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            if (scelta != "0")
            {
                Console.WriteLine("\nPremi un tasto per tornare al menu...");
                Console.ReadKey();
            }

        } while (scelta != "0");
    }

    static void EseguiProgramma1()
    {
        Console.Clear();
        Console.WriteLine("--- PROGRAMMA 1 ---");
        // a. Crea una lista di interi vuota
        System.Collections.Generic.List<int> numeri = new System.Collections.Generic.List<int>();

        // b. & c. Chiede di inserire 5 numeri e li aggiunge
        Console.WriteLine("Inserisci 5 numeri interi:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Numero {i + 1}: ");
            if (int.TryParse(Console.ReadLine(), out int n)) numeri.Add(n);
            else { Console.WriteLine("Errore: inserire un numero intero."); i--; }
        }

        // d. Chiede e rimuove uno o più numeri
        Console.WriteLine("\nQuale numero vuoi rimuovere?");
        if (int.TryParse(Console.ReadLine(), out int daRimuovere))
        {
            bool rimosso = numeri.Remove(daRimuovere); 
            Console.WriteLine(rimosso ? "Numero rimosso." : "Numero non trovato.");
        }

        // e. Stampa tutti i numeri presenti
        Console.WriteLine("\nLista finale:");
        numeri.ForEach(n => Console.Write(n + " "));
        Console.WriteLine();
    }

    static void EseguiProgramma2()
    {
        Console.Clear();
        Console.WriteLine("--- PROGRAMMA 2 ---");
        // a. Genera lista di 10 numeri casuali tra 1 e 100
        Random rnd = new Random();
        System.Collections.Generic.List<int> casuali = new System.Collections.Generic.List<int>();
        for (int i = 0; i < 10; i++) casuali.Add(rnd.Next(1, 101));

        // b. Stampa la lista
        Console.WriteLine("Lista generata: " + string.Join(", ", casuali));

        // c. e d. Cerca un numero e stampa l'indice
        Console.Write("\nInserisci un numero da cercare: ");
        if (int.TryParse(Console.ReadLine(), out int cerca))
        {
            int indice = casuali.IndexOf(cerca);
            if (indice != -1) Console.WriteLine($"Trovato all'indice: {indice}");
            else Console.WriteLine("Messaggio: Numero non trovato.");
        }

        // e. Restituisce numeri pari (quanti e quali)
        System.Collections.Generic.List<int> pari = casuali.FindAll(n => n % 2 == 0);
        Console.WriteLine($"\nNumeri pari trovati ({pari.Count}): {string.Join(", ", pari)}");
    }

    static void EseguiProgramma3()
    {
        Console.Clear();
        Console.WriteLine("--- PROGRAMMA 3 ---");
        // a. Crea lista di almeno 15 numeri casuali tra 1 e 20
        Random rnd = new Random();
        System.Collections.Generic.List<int> lista = new System.Collections.Generic.List<int>();
        for (int i = 0; i < 15; i++) lista.Add(rnd.Next(1, 21));

        // b. Stampa lista originale
        Console.WriteLine("Lista originale: " + string.Join(", ", lista));

        // c. Rimuove duplicati mantenendo valori unici
        System.Collections.Generic.List<int> unici = new System.Collections.Generic.List<int>();
        foreach (int n in lista) if (!unici.Contains(n)) unici.Add(n);

        // d. Ordina in ordine crescente
        unici.Sort();

        // e. Stampa lista finale
        Console.WriteLine("Lista finale (unici e ordinati): " + string.Join(", ", unici));
    }
}