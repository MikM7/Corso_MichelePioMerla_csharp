using System;

// VARIABILI, TIPI, CONST --- 16 Lunedì Febbraio 2026 --- 1° Lezione
class Program
{   
    const double PIGRECO = 3.14159;
    const int GIORNISETTIMANA = 7;

    static void Main(string[] args)
    {
        // --- DICHIARAZIONE VARIABILI ---
        int numero = 10;
        float decimaleFloat = 3.14f;
        char lettera = 'A';
        bool condizione = true;
        string saluto = "Ciao a tutti";

        Console.WriteLine("Numero: " + numero);
        Console.WriteLine("decimaleFloat: " + decimaleFloat);
        Console.WriteLine("Lettera: " + lettera);
        Console.WriteLine("Condizione: " + condizione);
        Console.WriteLine("Saluto: " + saluto);

        Console.WriteLine("\n--- Visualizziamo COSTANTI ---\n");
        Console.WriteLine("Pi Greco: " + PIGRECO);
        Console.WriteLine("Giorni in una settimana: " + GIORNISETTIMANA);

        // --- CASTING ---
        int intero = 42;
        double numeroGrande = intero;
        Console.WriteLine("\n-- CASTING IMPLICITO");
        Console.WriteLine("Convertito in DOUBLE: " + numeroGrande);

        double pi = 3.14159;
        int circaPI = (int)pi;
        Console.WriteLine("\n-- CASTING ESPLICITO");
        Console.WriteLine($"Il numero del PIGRECO per intero è: {pi}");
        Console.WriteLine($"Ma CONVERTITO in int è: {circaPI}");

        // --- INPUT DA TASTIERA ---
        Console.WriteLine("\n-- INPUT DA TASTIERA --");
        Console.Write("Come ti chiami? ");
        string nome2 = Console.ReadLine();
        Console.WriteLine($"Ciao {nome2}!");

        // --- CONVERSIONE STRINGA -> NUMERO ---
        Console.WriteLine("\n-- CONVERSIONE DA STRINGA A UN NUMERO");
        Console.Write("DAMMI UN NUMERO: ");
        string n1 = Console.ReadLine();
        Console.Write("DAMMI UN ALTRO NUMERO: ");
        string n2 = Console.ReadLine();

        int numero1 = int.Parse(n1);
        int numero2 = int.Parse(n2);
        Console.WriteLine($"La somma è: {numero1 + numero2}");

        // --- OPERATORI ---
        Console.WriteLine("\n---- OPERATORI ----");
        int m = 10, n = 3;

        // Nota: le operazioni e variabili vanno dentro le graffe { } 
        // per essere visualizzate correttamente con il simbolo $
        Console.WriteLine($"INCREMENTO iniziale (m++): {m++}");
        Console.WriteLine($"Valore di m dopo l'incremento: {m}");
        
        Console.WriteLine($"DECREMENTO iniziale (n--): {n--}");
        Console.WriteLine($"Valore di n dopo il decremento: {n}");

        Console.WriteLine($"La SOMMA tra i due numeri è: {m + n}");
        Console.WriteLine($"La DIFFERENZA tra i due numeri è: {m - n}");
        Console.WriteLine($"La MOLTIPLICAZIONE tra i due numeri è: {m * n}");
        Console.WriteLine($"La DIVISIONE tra i due numeri è: {m / n}");
        Console.WriteLine($"MODULO ovvero RESTO: {m % n}");

        

    }
}