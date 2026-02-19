using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
    
        int[] numeriBase=new int[5]; 

        numeriBase[0]=10;
        numeriBase[1]=20;

        int somma=numeriBase[0]+numeriBase[1];

        Console.WriteLine("--- ESEMPIO ARRAY ---");
        Console.WriteLine("IL VALORE NELLA POSIZIONE numeri[0]: " + numeriBase[0]);
        Console.WriteLine("IL VALORE NELLA POSIZIONE numeri[1]: " + numeriBase[1]);
        Console.WriteLine("La SOMMA è: " + somma);

        Console.WriteLine("\n************* ESEMPIO VOTI CON ARRAY ***********");

        int[] voti=new int[5];

        for (int i=0;i<5;i++)
        {
            Console.Write("Inserisci il voto " + (i + 1) + ": ");
            voti[i]=int.Parse(Console.ReadLine());
        }

        int sommaVoti=0;
        for (int i=0;i<5;i++)
        {
            sommaVoti=sommaVoti+voti[i];
        }

        float media=(float)sommaVoti / 5;
        Console.WriteLine("La media dei voti è: " + media);

        Console.WriteLine("\n************* ESEMPIO FOR EACH ***********"); 
        string parola="CSharp";
        Console.WriteLine("CARATTERI DELLA STRINGA:");
        foreach (char carattere in parola)
        {
            Console.WriteLine(carattere);
        }

        Console.WriteLine("\n******************* ESERCITAZIONE ARRAY *******************************");
        bool ripeti=true;

        while(ripeti)
        {
            Console.WriteLine("\n--- CONFIGURAZIONE ARRAY ---");
            Console.WriteLine("Cosa vuoi inserire? (1 = Testo, 2 = Numeri)");
            string scelta=Console.ReadLine();

            Console.WriteLine("Quanto deve essere lungo l'array?");
            int lunghezza=int.Parse(Console.ReadLine());

            if (scelta=="1")
            {
                string[] parole=new string[lunghezza];
                for (int i=0;i<lunghezza; i++)
                {
                    Console.Write($"Inserisci la parola {i + 1}: ");
                    parole[i]=Console.ReadLine();
                }

                Console.WriteLine("\nEcco il tuo array di stringhe:");
                foreach (string testo in parole)
                {
                    Console.WriteLine("- " + testo);
                }
            }
            else
            {
                int[] numeriInseriti=new int[lunghezza]; 
                for (int i=0;i<lunghezza;i++)
                {
                    Console.Write($"Inserisci il numero {i + 1}: ");
                    numeriInseriti[i]=int.Parse(Console.ReadLine());
                }

                Console.WriteLine("\nEcco il tuo array di numeri:");
                foreach (int n in numeriInseriti)
                {
                    Console.WriteLine("- " + n);
                }
            }


            Console.WriteLine("\n--- ESERCIZIO *******CONTEGGIO CIFRE***** ---");

            Console.Write("Inserisci una frase: ");
            string fraseCifre = Console.ReadLine();

            int contaCifre=0; 
            
            foreach (char c in fraseCifre)
            {
                if (char.IsDigit(c)) contaCifre++;
            }
            Console.WriteLine("Numero di cifre trovate: " + contaCifre);

            Console.WriteLine("\n--- ESERCIZIO ********** RIMOZIONE SPAZI********** ---");
            Console.Write("Inserisci una frase con spazi: ");
            string fraseConSpazi = Console.ReadLine();
            string senzaSpazi = "";
            foreach (char c in fraseConSpazi)
            {
                if (c != ' ') senzaSpazi += c;
            }
            Console.WriteLine("Frase senza spazi: " + senzaSpazi);

            Console.WriteLine("\n--- ESERCIZIO ************** CONTEGGIO VOCALI********** ---");
            Console.Write("Inserisci una frase per contare le vocali: ");
            string fraseVocali = Console.ReadLine();
            int nVocali = ContaVocali(fraseVocali);
            Console.WriteLine("Numero di vocali: " + nVocali);


            Console.WriteLine("\n--- ESERCIZIO **********PASSWORD CONTROLLO************");
            Console.WriteLine("Scrivi la tua password:");
            string password = Console.ReadLine();

            if (IsPasswordValida(password))
            {
                Console.WriteLine("La password va bene!");
            }
            else
            {
                Console.WriteLine("La password non è valida.");
            }

            Console.WriteLine("\n--- ESERCIZIO **********ANALISI TESTO COMPLETA************");
            Console.WriteLine("Inserisci una frase da analizzare:");
            string fraseAnalisi = Console.ReadLine();
            AnalizzaTesto(fraseAnalisi);


            Console.WriteLine("\nVuoi ricominciare tutto il blocco esercizi? (s/n)");
            string risposta=Console.ReadLine().ToLower();
            if (risposta!="s")
            {
                ripeti=false;
                Console.WriteLine("Programma terminato. Arrivederci!");
                Console.WriteLine("Premi un tasto per uscire...");
                Console.ReadKey();
            }
        }
    }
    
    static bool IsPasswordValida(string pwd) 
    {
        if (pwd.Length < 8)
        {
            return false;
        }

        if (pwd.StartsWith(" ") || pwd.EndsWith(" "))
        {
            return false;
        }

        bool haLetteraGrande = false;
        bool haNumero = false;

        foreach (char carattere in pwd)
        {
            if (char.IsUpper(carattere))
            {
                haLetteraGrande = true;
            }

            if (char.IsDigit(carattere))
            {
                haNumero = true;
            }
        }

        if (haLetteraGrande == true && haNumero == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    static int ContaVocali(string testo)
    {
        int contatore = 0;
        string vocali = "aeiouAEIOU"; 
        foreach (char c in testo)
        {
            if (vocali.Contains(c.ToString()))
            {
                contatore++;
            }
        }
        return contatore;
    }

    static void AnalizzaTesto(string testo)
    {
        int conteggioLettere = 0;
        int conteggioSpazi = 0;
        int conteggioPunteggiatura = 0;

        foreach (char carattere in testo)
        {
            if (char.IsLetter(carattere))
            {
                conteggioLettere++;
            }

            if (char.IsWhiteSpace(carattere))
            {
                conteggioSpazi++;
            }

            if (char.IsPunctuation(carattere))
            {
                conteggioPunteggiatura++;
            }
        }

        string[] listaParole = testo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int conteggioParole = listaParole.Length;

        Console.WriteLine("------------------------------");
        Console.WriteLine("RISULTATI DELL'ANALISI:");
        Console.WriteLine("Numero di lettere: " + conteggioLettere);
        Console.WriteLine("Numero di spazi: " + conteggioSpazi);
        Console.WriteLine("Segni di punteggiatura: " + conteggioPunteggiatura);
        Console.WriteLine("Numero di parole: " + conteggioParole);
        Console.WriteLine("------------------------------");
    }
}