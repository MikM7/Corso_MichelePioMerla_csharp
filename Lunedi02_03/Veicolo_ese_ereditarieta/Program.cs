using System;

namespace GestoreGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            Veicolo[] garage = new Veicolo[10];
            int indice = 0;
            bool continua = true;

            while (continua)
            {
                Console.WriteLine("\n--- MENU GESTIONE GARAGE ---");
                Console.WriteLine("1. Inserisci Auto");
                Console.WriteLine("2. Inserisci Moto");
                Console.WriteLine("3. Visualizza Tutti i Veicoli");
                Console.WriteLine("4. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();

                if ((scelta == "1" || scelta == "2") && indice >= 10)
                {
                    Console.WriteLine("Il garage è pieno!");
                    continue;
                }

                switch (scelta)
                {
                    case "1":
                        Console.Write("Marca: "); string maA = Console.ReadLine();
                        Console.Write("Modello: "); string moA = Console.ReadLine();
                        Console.Write("Numero Porte: "); int p = int.Parse(Console.ReadLine());
                        garage[indice++] = new Auto(maA, moA, p);
                        Console.WriteLine("Auto aggiunta!");
                        break;

                    case "2":
                        Console.Write("Marca: "); string maM = Console.ReadLine();
                        Console.Write("Modello: "); string moM = Console.ReadLine();
                        Console.Write("Tipo Manubrio: "); string man = Console.ReadLine();
                        garage[indice++] = new Moto(maM, moM, man);
                        Console.WriteLine("Moto aggiunta!");
                        break;

                    case "3":
                        Console.WriteLine("\n--- LISTA VEICOLI ---");
                        if (indice == 0) Console.WriteLine("Garage vuoto.");
                        for (int i = 0; i < indice; i++)
                        {
                            garage[i].StampaInfo();
                        }
                        break;

                    case "4":
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
    }
}