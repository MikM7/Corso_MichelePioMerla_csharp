using System;


namespace GarageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Veicolo> garage = new List<Veicolo>();
            bool esci = false;

            while (!esci)
            {
                Console.WriteLine("\n=== MENU GARAGE ===");
                Console.WriteLine("1. Aggiungi Auto");
                Console.WriteLine("2. Aggiungi Moto");
                Console.WriteLine("3. Visualizza Veicoli");
                Console.WriteLine("4. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine() ?? "";

                switch (scelta)
                {
                    case "1":
                        Console.Write("Marca: "); string ma = Console.ReadLine() ?? "";
                        Console.Write("Modello: "); string mo = Console.ReadLine() ?? "";
                        Console.Write("Porte: "); int p = int.Parse(Console.ReadLine() ?? "0");
                        garage.Add(new Auto(ma, mo, p));
                        break;
                    case "2":
                        Console.Write("Marca: "); string mma = Console.ReadLine() ?? "";
                        Console.Write("Modello: "); string mmo = Console.ReadLine() ?? "";
                        Console.Write("Manubrio: "); string man = Console.ReadLine() ?? "";
                        garage.Add(new Moto(mma, mmo, man));
                        break;
                    case "3":
                        Console.WriteLine("\n--- LISTA VEICOLI ---");
                        foreach (Veicolo v in garage) { v.StampaInfo(); }
                        break;
                    case "4":
                        esci = true;
                        break;
                }
            }
        }
    }
}