using System;

class Program
{
    const int ETA_MINIMA=18;
    static void Main(string[] args)
    {
        int a=100;
        int b=20;

        Console.WriteLine($"Valore a: {a}");
        Console.WriteLine($"Valore b: {b}");
        if(a>b)
        {
            Console.WriteLine($"Il valore {a} è maggiore del valore {b}");
        }
        Console.WriteLine("Fine del confronto.");
        //-------------------------------------------------------------------------------------------------------
        Console.WriteLine("ESERCIZI CON IF");
         //ESERCITAZIONE CON IF
        double etaVisualizzazione;
        Console.Write("INSERISCI LA TUA ETA': ");
        string input=Console.ReadLine();
        int etaUtente=int.Parse(input);
        etaVisualizzazione=etaUtente; 
        Console.WriteLine($"--- Verifichiamo l'età: {etaVisualizzazione} ---");

        if(etaUtente>=ETA_MINIMA)
        {
            Console.WriteLine("FANTASTICO: Sei maggiorenne!");
            Console.WriteLine($"{etaUtente} è maggiore o uguale a {ETA_MINIMA}");
        }
        else
        {
            Console.WriteLine("MI DISPIACE--SEI MINORENNE--NON PUOI EFFETTUARE L'ACCESSO!");
        }

         Console.WriteLine("----------BENVENUTO DA ZARA--------");
        
        Console.Write("Inserisci il prezzo del prodotto: ");
        input = Console.ReadLine();
        
        //CONVERSIONE ESPLICITA (Casting da stringa a double) ********ricordati questo**********quando trovi * OCCHIO
        double prezzo=double.Parse(input);

        if(prezzo>100)
        {
            double sconto=prezzo*0.10; 
            prezzo=prezzo-sconto;
            Console.WriteLine("Sconto del 10% applicato.");
        }

     
        Console.WriteLine($"Il prezzo finale e': {prezzo} Euro");
        Console.WriteLine("------------------ULTIMO ESERCIZIO finale-------------------------------");

        //--------------------------------------------------------------------------------------
        Console.Write("Inserisci il primo numero (int): ");
        int num1=int.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero (int): ");
        int num2=int.Parse(Console.ReadLine());

        Console.Write("Inserisci il terzo numero (int): ");
        int num3=int.Parse(Console.ReadLine());

        Console.WriteLine($"\nHai inserito i numeri: {num1}, {num2} e {num3}");
        double media = (double)(num1 + num2 + num3) / 3;
        Console.WriteLine($"La tua media esatta e': {media}");
        if (media >= 60)
        {
            Console.WriteLine("ESITO: HAI SUPERATO L'ESAME!");
        }
        else
        {
            Console.WriteLine("ESITO: ESAME FALLITO.");
        }
        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
      
}