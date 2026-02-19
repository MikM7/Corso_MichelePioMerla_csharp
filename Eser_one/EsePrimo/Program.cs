using System;

class Program
{
    static void Main(string[] args)
    {
        //ESE1_MERLA
        Console.WriteLine("-- BENVENUTO --");
        Console.Write("Come ti chiami? ");
        string nome=Console.ReadLine();
        Console.WriteLine("Ciao " + nome + "!");
        
        // --- SOMMA ---
        Console.WriteLine("\n--somma di due numeri--");
        int numero1=100, numero2=45;
        int somma=numero1+numero2;
        Console.WriteLine("La somma tra i due numeri è: " + somma);

        // --- SCONTO ---
        Console.WriteLine("\n--calcolo di un prezzo scontato--");
        double Prezzo=324.70;
        double sconto=0.20;
        double PrezzoScontato=Prezzo-(Prezzo*sconto);
        Console.WriteLine("Il prezzo"+Prezzo+" scontato del 20 percento è: " + PrezzoScontato);

        // --- NUM POSITIVO ---
        Console.WriteLine("\n--verifichiamo numero positivo--");
        float var;
        Console.Write("Inserisci un numero: ");
        var=float.Parse(Console.ReadLine());
        
        bool positivo=var>0;

        if (var>0)
        {
            Console.WriteLine("Il numero inserito è: " +var);
            Console.WriteLine("il numero da lei inserito è positivo? " +positivo);
        }
        else
        {
            Console.WriteLine("Il numero inserito è: " +var);
            Console.WriteLine("il numero da lei inserito è positivo? " +positivo);
        }
        Console.WriteLine("\nPremi INVIO per uscire...");
        Console.ReadLine(); 
    }
}