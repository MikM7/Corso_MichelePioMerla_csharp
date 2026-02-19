using System;

class Program
{
    static void Main(string[] args)
    {
      /* bool continua=true;
       while(continua)
        {
            Console.WriteLine("ciclo in esecuzione");
            continua=bool.Parse(Console.ReadLine());

        }
        int continua2=0;
        while(continua2<10)
        {
            Console.WriteLine("CICLO IN ESECUZIONE");
            continua2=continua2+1;
            Console.WriteLine(continua2);
        }
        */
        //ESERCIZIO CON CICLI
        int somma=0 , numero=0;

        Console.WriteLine("Inserisci numeri positivi (inserisci un numero negativo per terminare):");

        while (true)
        {
            numero=int.Parse(Console.ReadLine());

            if(numero<0)
            {
                break;
            }

            somma=somma+numero;
        }

        Console.WriteLine("La somma totale è: " + somma);
//------------------------------------------------------------------------------------------------------------
        const int NUMERO_SEGRETO=1999;
        int tentativo=0;

        Console.WriteLine("=== INDOVINA IL NUMERO SEGRETO ===");
        Console.WriteLine("Ho pensato a un numero. Prova a indovinarlo!");

        while(true)
        {
            Console.Write("\nInserisci il tuo tentativo: ");
            tentativo=int.Parse(Console.ReadLine());

            if (tentativo==NUMERO_SEGRETO)
            {
                Console.WriteLine("Complimenti! Hai indovinato il numero segreto.");
                break;
            }
            else if (tentativo < NUMERO_SEGRETO)
            {
                Console.WriteLine("Il numero segreto è MAGGIORE.");
            }
            else
            {
                Console.WriteLine("Il numero segreto è MINORE.");
            }
        }
        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
}
