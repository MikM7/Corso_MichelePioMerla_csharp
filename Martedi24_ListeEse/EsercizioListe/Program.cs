using System; 

class Program
{
    static void Main(string[] args)
    {
        string scelta; // Variabile per memorizzare l'input dell'utente
        do
        {
            Console.Clear(); // Pulisce la console a ogni ritorno al menu

            Console.WriteLine("Seleziona il programma da eseguire (1, 2 o 3) oppure 0 per uscire:");
            scelta = Console.ReadLine(); // Legge la scelta dell'utente

           
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

            // Se l'utente non esce, aspetta un input prima di tornare al menu
            if (scelta != "0")
            {
                Console.WriteLine("\nPremi un tasto per tornare al menu...");
                Console.ReadKey();
            }

        } while (scelta != "0"); // Ciclo finché la scelta non è 0
    }

    static void EseguiProgramma1()
    {
        Console.Clear();
        Console.WriteLine("--- PROGRAMMA 1 ---");
        
        // a. Dichiarazione e istanza di una lista di interi vuota
        List<int> numeri = new List<int>();

        // b. & c. Ciclo for per richiedere esattamente 5 numeri
        Console.WriteLine("Inserisci 5 numeri interi:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Numero {i + 1}: ");
            // tenta di convertire il testo in numero per evitare errori di runtime
            if (int.TryParse(Console.ReadLine(), out int n)) 
            {
                numeri.Add(n); // Aggiunge il numero alla lista
            }
            else 
            { 
                Console.WriteLine("Errore: inserire un numero intero."); 
                i--; // Se l'input è sbagliato, riporta indietro l'indice per ripetere il turno
            }
        }

        // d. Rimozione di un elemento specifico
        Console.WriteLine("\nQuale numero vuoi rimuovere?");
        if (int.TryParse(Console.ReadLine(), out int daRimuovere))
        {
            // Il metodo Remove restituisce un booleano: true se rimosso, false se non trovato
            bool rimosso = numeri.Remove(daRimuovere); 
            if (rimosso) Console.WriteLine("Numero rimosso.");
            else Console.WriteLine("Numero non trovato.");
        }

        // e. Stampa finale della lista con un ciclo foreach
        Console.WriteLine("\nLista finale:");
        foreach (int n in numeri)
        {
            Console.Write(n + " "); // Stampa ogni numero separato da uno spazio
        }
        Console.WriteLine();
    }

    static void EseguiProgramma2()
    {
        Console.Clear();
        Console.WriteLine("--- PROGRAMMA 2 ---");
        
        // a. Creazione generatore di numeri casuali
        Random rnd = new Random();
        List<int> casuali = new List<int>();
        
        // Genera 10 numeri casuali compresi tra 1 e 100
        for (int i = 0; i < 10; i++) 
        {
            casuali.Add(rnd.Next(1, 101));
        }

        // b. Visualizzazione della lista generata
        Console.WriteLine("Lista generata: " + string.Join(", ", casuali));

        // c. & d. Ricerca della posizione di un numero
        Console.Write("\nInserisci un numero da cercare: ");
        if (int.TryParse(Console.ReadLine(), out int cerca))
        {
            // IndexOf restituisce la posizione (da 0 in su) o -1 se non esiste
            int indice = casuali.IndexOf(cerca);
            if (indice != -1) 
                Console.WriteLine($"Trovato all'indice: {indice}");
            else 
                Console.WriteLine("Messaggio: Numero non trovato.");
        }

        // e. Filtraggio numeri pari
        List<int> pari = new List<int>(); // Nuova lista per i numeri pari
        foreach (int n in casuali)
        {
            // Se il resto della divisione per 2 è zero, il numero è pari
            if (n % 2 == 0)
            {
                pari.Add(n);
            }
        }
        
        // Stampa il conteggio dei pari e l'elenco
        Console.WriteLine($"\nNumeri pari trovati ({pari.Count}): {string.Join(", ", pari)}");
    }

    static void EseguiProgramma3()
    {
        Console.Clear();
        Console.WriteLine("--- PROGRAMMA 3 ---");
        
        // a. Generazione lista di 15 numeri tra 1 e 20
        Random rnd = new Random();
        List<int> lista = new List<int>();
        for (int i = 0; i < 15; i++) 
        {
            lista.Add(rnd.Next(1, 21));
        }

        // b. Stampa lista con duplicati
        Console.WriteLine("Lista originale: " + string.Join(", ", lista));

        // c. Algoritmo per rimuovere i duplicati
        List<int> unici = new List<int>();
        foreach (int n in lista) 
        {
            // Se il numero non è ancora presente nella lista 'unici', lo aggiungo
            if (!unici.Contains(n)) 
            {
                unici.Add(n);
            }
        }

        // d. Ordinamento della lista in ordine crescente
        unici.Sort();

        // e. Stampa finale dei valori unici e ordinati
        Console.WriteLine("Lista finale (unici e ordinati): " + string.Join(", ", unici));
    }
}