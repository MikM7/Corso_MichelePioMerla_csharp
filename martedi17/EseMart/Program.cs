using System;

class Program
{
    static void Main(string[] args)
    {
        // --- PARTE 1: BENVENUTO E NOME ---
        Console.WriteLine("-- BENVENUTO --");
        Console.Write("Come ti chiami? ");
        // Aggiungiamo ?? "" per gestire il caso null
        string nomeutente = Console.ReadLine() ?? ""; 
        Console.WriteLine("Ciao " + nomeutente + "!");

        // --- PARTE 2: ETÀ E NUMERI ---
        Console.Write("Inserisci la tua età: ");
        int eta = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Inserisci un numero intero: ");
        int numero1 = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Inserisci un numero float (usa la virgola): ");
        float numero2 = float.Parse(Console.ReadLine() ?? "0");

        // --- PARTE 3: CALCOLI E CASTING ---
        float sommaFloat = numero1 + numero2;
        int sommaIntera = (int)(numero1 + numero2);

        Console.WriteLine("\n--- RISULTATI ---");
        Console.WriteLine($"Somma con decimali (float): {sommaFloat}");
        Console.WriteLine($"Somma troncata (int): {sommaIntera}");

        // --- PARTE 4: ALTEZZA E SOMMA FINALE ---
        Console.Write("Inserisci la tua altezza (es. 1,75): ");
        string inputAltezza = Console.ReadLine() ?? "0"; 
        float altezzaFloat = float.Parse(inputAltezza);

        int sommaFinale = (int)(eta + altezzaFloat);
        Console.WriteLine($"La somma tra l'età di {nome} ({eta}) e l'altezza ({altezzaFloat}) castata a intero è: {sommaFinale}");

        // --- PARTE 5: CALCIO E LOGICA ---
        Console.WriteLine("\nTI FARO' DOMANDE in ambito calcistico RISPONDI TRUE O FALSE");
        Console.WriteLine("-- CHI PUO' SCENDERE IN CAMPO --");
        Console.Write("COGNOME CALCIATORE? ");
        string cognome = Console.ReadLine() ?? "";

        Console.Write("È convocato? (true/false): ");
        bool convocato = bool.Parse(Console.ReadLine() ?? "false");
        
        Console.Write("Ha il certificato medico? (true/false): ");
        bool certificato = bool.Parse(Console.ReadLine() ?? "false");
        
        Console.Write("È il capitano? (true/false): ");
        bool capitano = bool.Parse(Console.ReadLine() ?? "false");
        
        Console.Write("È squalificato? (true/false): ");
        bool squalificato = bool.Parse(Console.ReadLine() ?? "false");

        bool puoGiocare = ((convocato && certificato) || capitano) && !squalificato;

        Console.WriteLine($"\nIl calciatore {cognome} può scendere in campo? {puoGiocare}");

        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
}