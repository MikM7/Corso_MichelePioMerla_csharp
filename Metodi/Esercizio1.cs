using System;

class Program
{
    public static void main(String[] args)    
    {
        string scelta;

        do
        {
            
            Console.WriteLine("\n--- MENU ESERCIZI ---");
            Console.WriteLine("1. Saluto Personalizzato");
            Console.WriteLine("2. Verifica Pari o Dispari");
            Console.WriteLine("3. Calcola Potenza");
            Console.WriteLine("0. Esci");
            Console.Write("Cosa vuoi fare? Scelta: ");
            
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il tuo nome: ");
                    string nome = Console.ReadLine();
                    StampaSaluto(nome);
                    break;

                case "2":
                    Console.Write("Inserisci un numero intero: ");
                    int n = int.Parse(Console.ReadLine());
                    VerificaPari(n);
                    break;

                case "3":
                    Console.Write("Inserisci la base: ");
                    int b = int.Parse(Console.ReadLine());
                    Console.Write("Inserisci l'esponente: ");
                    int e = int.Parse(Console.ReadLine());
                    int pot = CalcolaPotenza(b, e);
                    Console.WriteLine($"Risultato: {b}^{e} = {pot}");
                    break;

                case "0":
                    Console.WriteLine("Uscita in corso... Arrivederci!");
                    break;

                default:
                    Console.WriteLine("Scelta non valida, riprova.");
                    break;
            }

        } while (scelta != "0"); 
    }

    // --- METODI DEGLI ESERCIZI ---

    static void StampaSaluto(string nome)
    {
        Console.WriteLine($"Ciao {nome}!");
    }

    static void VerificaPari(int numero)
    {
        if (numero % 2 == 0)
            Console.WriteLine($"{numero} è Pari.");
        else
            Console.WriteLine($"{numero} è Dispari.");
    }

    static int CalcolaPotenza(int baseNum, int esponente)
    {
        int risultato = 1;
        for (int i = 0; i < esponente; i++)
        {
            risultato *= baseNum;
        }
        return risultato;
    }
}