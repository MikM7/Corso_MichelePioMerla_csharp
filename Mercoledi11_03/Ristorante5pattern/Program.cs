using System;

namespace RistorantePatterns
{

    // INTERFACCIA PIATTO
    public interface IPiatto
    {
        string Descrizione();
        string Prepara();
    }

    // PIATTI BASE
    public class Pizza : IPiatto
    {
        public string Descrizione()
        {
            return "Pizza base";
        }

        public string Prepara()
        {
            return "Preparazione base pizza";
        }
    }

    public class Hamburger : IPiatto
    {
        public string Descrizione()
        {
            return "Hamburger base";
        }

        public string Prepara()
        {
            return "Preparazione base hamburger";
        }
    }

    public class Insalata : IPiatto
    {
        public string Descrizione()
        {
            return "Insalata base";
        }

        public string Prepara()
        {
            return "Preparazione base insalata";
        }
    }
    // FACTORY PATTERN
    public static class PiattoFactory
    {
        public static IPiatto Crea(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "pizza":
                    return new Pizza();

                case "hamburger":
                    return new Hamburger();

                case "insalata":
                    return new Insalata();

                default:
                    throw new Exception("Tipo non valido");
            }
        }
    }
    // DECORATOR PATTERN

    public abstract class IngredienteExtra : IPiatto
    {
        protected IPiatto piatto;

        public IngredienteExtra(IPiatto p)
        {
            piatto = p;
        }

        public virtual string Descrizione()
        {
            return piatto.Descrizione();
        }

        public virtual string Prepara()
        {
            return piatto.Prepara();
        }
    }

    public class ConFormaggio : IngredienteExtra
    {
        public ConFormaggio(IPiatto p) : base(p) { }

        public override string Descrizione()
        {
            return piatto.Descrizione() + ", formaggio";
        }
    }

    public class ConBacon : IngredienteExtra
    {
        public ConBacon(IPiatto p) : base(p) { }

        public override string Descrizione()
        {
            return piatto.Descrizione() + ", bacon";
        }
    }

    public class ConSalsa : IngredienteExtra
    {
        public ConSalsa(IPiatto p) : base(p) { }

        public override string Descrizione()
        {
            return piatto.Descrizione() + ", salsa";
        }
    }

    // STRATEGY PATTERN
    public interface IPreparazioneStrategia
    {
        string Prepara(string descrizione);
    }

    public class Fritto : IPreparazioneStrategia
    {
        public string Prepara(string descrizione)
        {
            return descrizione + " preparato fritto";
        }
    }

    public class AlForno : IPreparazioneStrategia
    {
        public string Prepara(string descrizione)
        {
            return descrizione + " preparato al forno";
        }
    }

    public class AllaGriglia : IPreparazioneStrategia
    {
        public string Prepara(string descrizione)
        {
            return descrizione + " preparato alla griglia";
        }
    }

    // SINGLETON CHEF
    public class Chef
    {
        private static Chef instance;

        private IPreparazioneStrategia strategia;

        private Chef() { }

        public static Chef Instance
        {
            get
            {
                if (instance == null)
                    instance = new Chef();

                return instance;
            }
        }

        public void SetStrategia(IPreparazioneStrategia s)
        {
            strategia = s;
        }

        public string PreparaPiatto(IPiatto p)
        {
            return strategia.Prepara(p.Descrizione());
        }
    }

    // BUILDER PATTERN
    public class PiattoBuilder
    {
        private IPiatto piatto;

        public PiattoBuilder(string tipo)
        {
            piatto = PiattoFactory.Crea(tipo);
        }

        public void AggiungiFormaggio()
        {
            piatto = new ConFormaggio(piatto);
        }

        public void AggiungiBacon()
        {
            piatto = new ConBacon(piatto);
        }

        public void AggiungiSalsa()
        {
            piatto = new ConSalsa(piatto);
        }

        public IPiatto GetPiatto()
        {
            return piatto;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Scegli piatto (pizza, hamburger, insalata):");
            string tipo = Console.ReadLine();

            PiattoBuilder builder = new PiattoBuilder(tipo);

            Console.WriteLine("Aggiungere formaggio? (s/n)");
            if (Console.ReadLine() == "s")
                builder.AggiungiFormaggio();

            Console.WriteLine("Aggiungere bacon? (s/n)");
            if (Console.ReadLine() == "s")
                builder.AggiungiBacon();

            Console.WriteLine("Aggiungere salsa? (s/n)");
            if (Console.ReadLine() == "s")
                builder.AggiungiSalsa();

            IPiatto piatto = builder.GetPiatto();

            Console.WriteLine("Scegli preparazione (forno, fritto, griglia):");
            string prep = Console.ReadLine();

            IPreparazioneStrategia strategia;

            switch (prep)
            {
                case "forno":
                    strategia = new AlForno();
                    break;

                case "fritto":
                    strategia = new Fritto();
                    break;

                default:
                    strategia = new AllaGriglia();
                    break;
            }

            Chef chef = Chef.Instance;
            chef.SetStrategia(strategia);

            Console.WriteLine("\n--- RISULTATO ---");
            Console.WriteLine("Descrizione: " + piatto.Descrizione());
            Console.WriteLine("");
            Console.WriteLine("Preparazione: " + chef.PreparaPiatto(piatto));
        }
    }
}