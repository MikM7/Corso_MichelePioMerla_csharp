using System;

namespace GestioneOperatori
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Operatore> listaOperatori = new List<Operatore>();
            bool esci = false;

            while (!esci)
            {
                Console.WriteLine("\n=== SISTEMA GESTIONE OPERATORI ===");
                Console.WriteLine("1. Aggiungi Operatore Emergenza");
                Console.WriteLine("2. Aggiungi Operatore Sicurezza");
                Console.WriteLine("3. Aggiungi Operatore Logistica");
                Console.WriteLine("4. Report Completo (Polimorfismo)");
                Console.WriteLine("5. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine() ?? "";

                if (scelta == "5") { esci = true; continue; }

                if (scelta == "4")
                {
                    Console.WriteLine("\n--- REPORT ATTIVITÀ ---");
                    foreach (Operatore op in listaOperatori)
                    {
                        Console.Write($"[{op.Nome.ToUpper()}] Turno: {op.Turno} -> ");
                        op.EseguiCompito(); 
                    }
                    continue;
                }
                Console.Write("Inserisci Nome: ");
                string n = Console.ReadLine() ?? "";
                Console.Write("Inserisci Turno (giorno/notte): ");
                string t = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        OperatoreEmergenza oe = new OperatoreEmergenza { Nome = n, Turno = t };
                        Console.Write("Livello Urgenza (1-5): ");
                        oe.LivelloUrgenza = int.Parse(Console.ReadLine() ?? "1");
                        listaOperatori.Add(oe);
                        break;
                    case "2":
                        OperatoreSicurezza os = new OperatoreSicurezza { Nome = n, Turno = t };
                        Console.Write("Area da sorvegliare: ");
                        os.AreaSorvegliata = Console.ReadLine() ?? "";
                        listaOperatori.Add(os);
                        break;
                    case "3":
                        OperatoreLogistica ol = new OperatoreLogistica { Nome = n, Turno = t };
                        Console.Write("Numero consegne: ");
                        ol.NumeroConsegne = int.Parse(Console.ReadLine() ?? "0");
                        listaOperatori.Add(ol);
                        break;
                }
            }
        }
    }
}