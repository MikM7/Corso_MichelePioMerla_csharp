using System;

namespace PasticceriaApp
{
    public interface ITorta
    {
        string Descrizione();
    }

    public class TortaCioccolato : ITorta
    {
        public string Descrizione() => "Torta al cioccolato";
    }

    public class TortaVaniglia : ITorta
    {
        public string Descrizione() => "Torta alla vaniglia";
    }

    public class TortaFrutta : ITorta
    {
        public string Descrizione() => "Torta alla frutta";
    }

    public abstract class DecoratoreTorta : ITorta
    {
        protected ITorta tortaBase; 

        public DecoratoreTorta(ITorta tortaDaDecorare)
        {
            tortaBase = tortaDaDecorare;
        }

        public virtual string Descrizione() => tortaBase.Descrizione();
    }

    public class ConPanna : DecoratoreTorta
    {
        public ConPanna(ITorta torta) : base(torta) { }
        public override string Descrizione() => tortaBase.Descrizione() + " + panna";
    }

    public class ConFragole : DecoratoreTorta
    {
        public ConFragole(ITorta torta) : base(torta) { }
        public override string Descrizione() => tortaBase.Descrizione() + " + fragole";
    }

    public class ConGlassa : DecoratoreTorta
    {
        public ConGlassa(ITorta torta) : base(torta) { }
        public override string Descrizione() => tortaBase.Descrizione() + " + glassa";
    }

    public static class TortaFactory
    {
        public static ITorta CreaTortaBase(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "cioccolato": return new TortaCioccolato();
                case "vaniglia": return new TortaVaniglia();
                case "frutta": return new TortaFrutta();
                default: return new TortaVaniglia();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BENVENUTI NELLA PASTICCERIA FACTORY ===");
            Console.Write("Scegli la base (cioccolato, vaniglia, frutta): ");
            string scelta = Console.ReadLine() ?? "";

            ITorta laMiaTorta = TortaFactory.CreaTortaBase(scelta);

            bool aggiuntaInCorso = true;
            while (aggiuntaInCorso)
            {
                Console.WriteLine($"\nStato attuale: {laMiaTorta.Descrizione()}");
                
                Console.WriteLine("Cosa vuoi aggiungere?");
                Console.WriteLine("1. Panna | 2. Fragole | 3. Glassa | 0. Fine ordine");
                Console.Write("Scelta: ");
                string extra = Console.ReadLine() ?? "";

                switch (extra)
                {
                    case "1": laMiaTorta = new ConPanna(laMiaTorta); break;
                    case "2": laMiaTorta = new ConFragole(laMiaTorta); break;
                    case "3": laMiaTorta = new ConGlassa(laMiaTorta); break;
                    case "0": aggiuntaInCorso = false; break;
                    default: Console.WriteLine("Scelta non valida!"); break;
                }
            }

            Console.Clear();
            Console.WriteLine("*******************************************");
            Console.WriteLine("            SCONTRINO FINALE              ");
            Console.WriteLine("*******************************************");
            Console.WriteLine($"ORDINE: {laMiaTorta.Descrizione()}");
            Console.WriteLine("*******************************************");

            Console.WriteLine("\nPremi SPAZIO per uscire.");
            Console.ReadKey();
        }
    }
}