using System;

class Program
{
    static void Main(string[] args)
    {
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- MENU ESERCIZI METODI ---");
            Console.WriteLine("1. Raddoppia (ref)");
            Console.WriteLine("2. Aggiusta Data (ref)");
            Console.WriteLine("3. Dividi (out)");
            Console.WriteLine("4. Analizza Parola (out)");
            Console.WriteLine("5. Aggiorna Punteggio (ref/out)");
            Console.WriteLine("6. Elabora Studente (ref/out/return)");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'opzione: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1": EseguiEsercizio1(); break;
                case "2": EseguiEsercizio2(); break;
                case "3": EseguiEsercizio3(); break;
                case "4": EseguiEsercizio4(); break;
                case "5": EseguiEsercizio5(); break;
                case "6": EseguiEsercizio6(); break;
                case "0": continua = false; break;
                default: Console.WriteLine("Scelta non valida."); break;
            }
        }
    }

    // --- metodo ESERCIZIO 1 ---
    static void EseguiEsercizio1()
    {
        Console.Write("Inserisci un numero: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine($"Valore prima: {n}");
        Raddoppia(ref n);
        Console.WriteLine($"Valore dopo: {n}");
    }
    static void Raddoppia(ref int numero) { numero *= 2; }

    // --- metodo ESERCIZIO 2 ---
    static void EseguiEsercizio2()
    {
        int g = 31, m = 12, a = 2023;
        Console.WriteLine($"Data originale: {g}/{m}/{a}");
        AggiustaData(ref g, ref m, ref a);
        Console.WriteLine($"Data aggiustata: {g}/{m}/{a}");
    }
    static void AggiustaData(ref int g, ref int m, ref int a)
    {
        if (g > 30) { g = 1; m++; }
        if (m > 12) { m = 1; a++; }
    }

    // --- metodo ESERCIZIO 3 ---
    static void EseguiEsercizio3()
    {
        Dividi(10, 3, out int q, out int r);
        Console.WriteLine($"10 diviso 3: Quoziente {q}, Resto {r}");
    }
    static void Dividi(int a, int b, out int quoziente, out int resto)
    {
        quoziente = a / b;
        resto = a % b;
    }

    // --- metodo ESERCIZIO 4 ---
    static void EseguiEsercizio4()
    {
        Console.Write("Inserisci una parola/frase: ");
        string testo = Console.ReadLine();
        AnalizzaParola(testo, out int v, out int c, out int s);
        Console.WriteLine($"Vocali: {v}, Consonanti: {c}, Spazi: {s}");
    }
    static void AnalizzaParola(string frase, out int vocali, out int consonanti, out int spazi)
    {
        vocali = 0; consonanti = 0; spazi = 0;
        string v = "aeiouAEIOU";
        foreach (char ch in frase)
        {
            if (char.IsWhiteSpace(ch)) spazi++;
            else if (v.Contains(ch)) vocali++;
            else if (char.IsLetter(ch)) consonanti++;
        }
    }

    // --- metodo ESERCIZIO 5 ---
    static void EseguiEsercizio5()
    {
        int punteggio = 0;
        int totale = 0;
        double media;
        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Inserisci bonus turno {i}: ");
            int b = int.Parse(Console.ReadLine());
            AggiornaPunteggio(ref punteggio, b, ref totale, out media, i);
            if (i == 3) Console.WriteLine($"Media finale: {media}");
        }
    }
    static void AggiornaPunteggio(ref int corr, int bonus, ref int tot, out double media, int turno)
    {
        corr += bonus;
        tot += corr;
        media = (turno == 3) ? tot / 3.0 : 0;
    }

    // --- metodo ESERCIZIO 6 ---
    static void EseguiEsercizio6()
    {
        double v1 = 5.5, v2 = 6.0;
        bool promosso = ElaboraStudente(ref v1, ref v2, 1.0, out double media, out bool esito);
        Console.WriteLine($"La Media: {media}, Sei Promosso...: {esito}");
        Console.WriteLine(promosso ? "Lo studente ha passato l'anno!" : "Studente bocciato.");
    }
    static bool ElaboraStudente(ref double n1, ref double n2, double bonus, out double media, out bool promosso)
    {
        n1 = Math.Min(n1 + bonus, 10);
        n2 = Math.Min(n2 + bonus, 10);
        media = (n1 + n2) / 2.0;
        promosso = media >= 6;
        return promosso;
    }
}