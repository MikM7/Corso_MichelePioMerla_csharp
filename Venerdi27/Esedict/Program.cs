using System;

class Program
{
    static void Main()
    {
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n=== SELEZIONA L'ESERCIZIO ===");
            Console.WriteLine("1. Rubrica Telefonica");
            Console.WriteLine("2. Conteggio Frequenza Parole");
            Console.WriteLine("3. Gestione Magazzino");
            Console.WriteLine("4. Esci");
            Console.Write("\nScelta: ");

            string scelta = Console.ReadLine();

            if (scelta == "1")
            {
                // Esercizio 1: Rubrica
                System.Collections.Generic.Dictionary<string, string> rubrica = new System.Collections.Generic.Dictionary<string, string>();
                for (int i = 0; i < 3; i++)
                {
                    Console.Write("Inserisci Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Inserisci Numero: ");
                    string numero = Console.ReadLine();
                    rubrica[nome] = numero;
                }
                Console.WriteLine("\nRubrica completa:");
                foreach (var c in rubrica) Console.WriteLine(c.Key + ": " + c.Value);
            }
            else if (scelta == "2")
            {
                // Esercizio 2: Conteggio Parole
                Console.WriteLine("Inserisci una frase:");
                string frase = Console.ReadLine();
                string[] parole = frase.Split(' ');
                System.Collections.Generic.Dictionary<string, int> freq = new System.Collections.Generic.Dictionary<string, int>();

                foreach (string p in parole)
                {
                    if (!string.IsNullOrWhiteSpace(p))
                    {
                        string chiave = p.ToLower();
                        if (freq.ContainsKey(chiave)) freq[chiave]++;
                        else freq[chiave] = 1;
                    }
                }
                foreach (var coppia in freq) Console.WriteLine(coppia.Key + ": " + coppia.Value);
            }
            else if (scelta == "3")
            {
                // Esercizio 3: Magazzino
                System.Collections.Generic.Dictionary<string, int> magazzino = new System.Collections.Generic.Dictionary<string, int>();
                string opz = "";
                while (opz != "5")
                {
                    Console.WriteLine("\n1.Agg 2.Rim 3.Cer 4.Sta 5.Indietro");
                    opz = Console.ReadLine();
                    if (opz == "1")
                    {
                        Console.Write("Prodotto: "); string p = Console.ReadLine();
                        Console.Write("Qta: "); int q = int.Parse(Console.ReadLine());
                        if (magazzino.ContainsKey(p)) magazzino[p] += q; else magazzino[p] = q;
                    }
                    else if (opz == "2")
                    {
                        Console.Write("Rimuovi: "); magazzino.Remove(Console.ReadLine());
                    }
                    else if (opz == "3")
                    {
                        Console.Write("Cerca: ");
                        string c = Console.ReadLine();
                        if (magazzino.TryGetValue(c, out int v)) Console.WriteLine("Disp: " + v);
                        else Console.WriteLine("Assente.");
                    }
                    else if (opz == "4")
                    {
                        foreach (var x in magazzino) Console.WriteLine(x.Key + ": " + x.Value);
                    }
                }
            }
            else if (scelta == "4")
            {
                continua = false;
            }
        }
    }
}
