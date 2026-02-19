using System;

class Program
{
    const int PASSWORD_PC=1234;
    static void Main(string[] args)
    {
        Console.WriteLine("ESERCIZI IF-ELSE");
        Console.Write("Inserisci un numero intero: ");
        string input = Console.ReadLine();
        int numero = int.Parse(input);
        
        int resto=numero%2; //QUELLO CHE AVVIENE IN NUMERO%2 VIENE ASSEGNATO NELLA VARIABILE RESTO E L'ANDIAMO A CONFRONTARE.

        if(resto==0)
        {
            Console.WriteLine($"Il numero {numero} è PARI (Resto: {resto})"); //RESTO=0 NUMERO PARI
        }
        else
        {
            Console.WriteLine($"Il numero {numero} è DISPARI (Resto: {resto})"); //RESTO=1 NUMERO DIPSARI
        }

        //------------------------------------------------------------------------------------------
        Console.WriteLine("-----ESE2---password");
        Console.WriteLine("");
        Console.Write("INSERISCI LA PASSWORD NUMERICA: ");
        string input_tasto=Console.ReadLine();
        int passwordUtente=int.Parse(input_tasto); //CONVERSIONE ESPLICITA
        if (passwordUtente==PASSWORD_PC)
        {
            Console.WriteLine("ACCESSO CONSENTITO!");
        }
        else
        {
            Console.WriteLine("ACCESSO NEGATO!");
            Console.WriteLine("La password inserita è errata.");
        }
        //-----------------------------------------------------------------------------
          Console.WriteLine("-----ESE3 CALCOLATRICE---");
          Console.WriteLine("***calcolatrice addizione e sottrazione");

          Console.Write("Inserisci il primo numero: ");
        double num1=double.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        double num2=double.Parse(Console.ReadLine());

        Console.Write("Inserisci l'operatore (+ o -): ");
        string segno=Console.ReadLine();
        double risultato=0;
        if (segno=="+")
        {
            //CASTING IMPLICITO: sommiamo num1 + num2
            risultato=num1+num2;
            
            //CASTING ESPLICITO
            int risultatoIntero = (int)risultato;
            Console.WriteLine($"Risultato esatto: {risultato}");
            Console.WriteLine("Il valore arrotondato per difetto (casting esplicito) e': " + risultatoIntero);
        }
        else if(segno=="-")
        {
            risultato=num1-num2;
            Console.WriteLine("Hai scelto la sottrazione.");
            Console.WriteLine("Il risultato e': " + risultato);
        }
        else
        {
            Console.WriteLine("ERRORE: operatore non valido!");
        }








        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
      
}
