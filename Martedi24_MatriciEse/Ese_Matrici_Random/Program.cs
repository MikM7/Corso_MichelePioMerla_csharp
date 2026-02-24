using System;

class Program
{
    static void Main()
    {
        string scelta;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU ESERCIZI ===");
            Console.WriteLine("1. Matrici: Somma righe/colonne (Manuale)");
            Console.WriteLine("2. Matrici: Confronto 4x4 Casuali");
            Console.WriteLine("3. Matrici: Diagonali 5x5");
            Console.WriteLine("4. Random: Indovina numero");
            Console.WriteLine("5. Random: Lancio dadi");
            Console.WriteLine("6. Random: Simulazione Temperature");
            Console.WriteLine("0. Esci");
            Console.Write("\nScegli un esercizio: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1": EsercizioMatrici1(); break;
                case "2": EsercizioMatrici2(); break;
                case "3": EsercizioMatrici3(); break;
                case "4": EsercizioRandom1(); break;
                case "5": EsercizioRandom2(); break;
                case "6": EsercizioRandom3(); break;
                case "0": Console.WriteLine("Chiusura..."); break;
                default: Console.WriteLine("Scelta non valida!"); break;
            }

            if (scelta != "0")
            {
                Console.WriteLine("\nPremi un tasto per tornare al menu...");
                Console.ReadKey();
            }

        } while (scelta != "0");
    }

    // ---  MATRICI ---

    static void EsercizioMatrici1()
    {
        // Acquisizione dimensioni della matrice da tastiera
        Console.Write("Inserisci numero righe: "); int r = int.Parse(Console.ReadLine());
        Console.Write("Inserisci numero colonne: "); int c = int.Parse(Console.ReadLine());
        int[,] m = new int[r, c];
        int totale = 0;

        // Inserimento riga per riga
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                Console.Write($"Valore riga {i}, colonna {j}: ");
                m[i, j] = int.Parse(Console.ReadLine());
                totale += m[i, j];
            }
        }

        Console.WriteLine("\n--- RISULTATI ---");
        // Calcolo delle somme per ogni riga: resetta sommaR a ogni cambio riga
        // Somma ogni singola riga
        for (int i = 0; i < r; i++)
        {
            int sommaR = 0;
            for (int j = 0; j < c; j++) sommaR += m[i, j];
            Console.WriteLine($"Somma riga {i}: {sommaR}");
        }

        // Somma ogni singola colonna
        for (int j = 0; j < c; j++)
        {
            int sommaC = 0;
            for (int i = 0; i < r; i++) sommaC += m[i, j];
            Console.WriteLine($"Somma colonna {j}: {sommaC}");
        }

        Console.WriteLine($"Somma totale di tutti gli elementi: {totale}");
    }

    static void EsercizioMatrici2()
    {
        Random rnd = new Random();
        int[,] m1 = new int[4, 4];
        int[,] m2 = new int[4, 4];
        int vinceM1 = 0, vinceM2 = 0; // Contatori per determinare il vincitore finale

        // Generazione e stampa Matrice 1
        Console.WriteLine("\nMATRICE 1:");
        for (int i = 0; i < 4; i++) {
            int s1 = 0;
            for (int j = 0; j < 4; j++) {
                m1[i, j] = rnd.Next(1, 51); // Valore casuale tra 1 e 50
                Console.Write(m1[i, j] + "\t");
                s1 += m1[i, j];
            }
            Console.WriteLine($"| Somma riga: {s1}");
        }

        // Generazione e stampa Matrice 2
        Console.WriteLine("\nMATRICE 2:");
        for (int i = 0; i < 4; i++) {
            int s2 = 0;
            for (int j = 0; j < 4; j++) 
            {
                m2[i, j] = rnd.Next(1, 51);
                Console.Write(m2[i, j] + "\t");
                s2 += m2[i, j];
            }
            Console.WriteLine($"| Somma riga: {s2}");
        }
        //confronta le somme delle righe
        // Confronto righe
        for (int i = 0; i < 4; i++)
         {
            int s1 = 0, s2 = 0;
            for (int j = 0; j < 4; j++) 
            {
                s1 += m1[i, j];
                s2 += m2[i, j];
            }
            if (s1 > s2) vinceM1++; 
            else if (s2 > s1) vinceM2++;
        }

        Console.WriteLine("\n--- ESITO ---");
        Console.WriteLine($"Matrice 1 vince {vinceM1} righe.");
        Console.WriteLine($"Matrice 2 vince {vinceM2} righe.");

        if (vinceM1 > vinceM2) Console.WriteLine("Esito finale: VINCE MATRICE 1");
        else if (vinceM2 > vinceM1) Console.WriteLine("Esito finale: VINCE MATRICE 2");
        else Console.WriteLine("Esito finale: LE DUE MATRICI PAREGGIANO");
    }

    static void EsercizioMatrici3()
    {
        Random rnd = new Random();
        int[,] m = new int[5, 5];
        int d1 = 0, d2 = 0;

        Console.WriteLine("\nMATRICE 5x5:");
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                m[i, j] = rnd.Next(1, 21);
                Console.Write(m[i, j] + "\t");
                if (i == j) d1 += m[i, j]; // Diagonale principale
                if (i + j == 4) d2 += m[i, j]; // Diagonale secondaria
            }
            Console.WriteLine();
        }

        Console.WriteLine($"\nSomma Diagonale Principale: {d1}");
        Console.WriteLine($"Somma Diagonale Secondaria: {d2}");

        if (d1 > d2) Console.WriteLine("La somma maggiore è della Diagonale Principale.");
        else if (d2 > d1) Console.WriteLine("La somma maggiore è della Diagonale Secondaria.");
        else Console.WriteLine("Le due diagonali hanno la stessa somma.");
    }

    // --- RANDOM ---

    static void EsercizioRandom1()
    {
        int segreto = new Random().Next(1, 11);
        Console.Write("Indovina (1-10): ");
        int user = int.Parse(Console.ReadLine());
        Console.WriteLine(user == segreto ? "Bravo!" : $"Sbagliato, era {segreto}");
    }

    static void EsercizioRandom2()
    {
        Random rnd = new Random();
        int d1 = rnd.Next(1, 7), d2 = rnd.Next(1, 7);
        Console.WriteLine($"Dadi: {d1} e {d2}. Somma: {d1 + d2}");
    }

    static void EsercizioRandom3()
    {
        Random rnd = new Random();
        Console.Write("Giorni da simulare: ");
        int gg = int.Parse(Console.ReadLine());
        int minT = 10, maxT = 35;
        int[] temp = new int[gg];
        double somma = 0;

        for (int i = 0; i < gg; i++) {
            temp[i] = rnd.Next(minT, maxT + 1);
            somma += temp[i];
        }
        Array.Sort(temp);
        Console.WriteLine($"Min: {temp[0]}, Max: {temp[gg-1]}, Media: {somma/gg:F2}");
    }
}