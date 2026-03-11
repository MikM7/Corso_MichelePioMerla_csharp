using System;

namespace RistorantePatternCompleto
{
    // 1. SINGLETON PATTERN (Gestione Cassa Unica)
    public class CassaRistorante
    {
        private static CassaRistorante _istanza;
        private double _totaleIncassato = 0;

        private CassaRistorante() { } // Costruttore privato

        public static CassaRistorante GetIstanza()
        {
            if (_istanza == null)
            {
                _istanza = new CassaRistorante();
            }
            return _istanza;
        }

        public void AggiungiAlTotale(double importo)
        {
            _totaleIncassato = _totaleIncassato + importo;
        }

        public double GetTotale()
        {
            return _totaleIncassato;
        }
    }
    // 2. OBSERVER PATTERN (Notifica al Cliente)
    public interface IOsservatore 
    { 
        void Notifica(string messaggio); 
    }

    public class Cliente : IOsservatore
    {
        private string _nome;
        public Cliente(string nome)
        {
            _nome = nome;
        }
        public void Notifica(string msg)
        {
            Console.WriteLine("[NOTIFICA PER " + _nome.ToUpper() + "]: " + msg);
        }
    }
    // 3. STRATEGY PATTERN (Cottura)
    public interface IPreparazioneStrategia 
    { 
        string Prepara(string descrizione); 
    }

    public class CotturaAlForno : IPreparazioneStrategia
    {
        public string Prepara(string descrizione)
        {
            return "[FORNO] " + descrizione + " cotta al calore del legno.";
        }
    }

    public class CotturaFritto : IPreparazioneStrategia
    {
        public string Prepara(string descrizione)
        {
            return "[FRITTO] " + descrizione + " dorata in olio bollente.";
        }
    }
    // 4. COMPONENTE BASE E DECORATOR (Piatti e Extra)
    public interface IPiatto 
    { 
        string Descrizione(); 
        double Prezzo(); 
    }

    public class Pizza : IPiatto 
    { 
        public string Descrizione() { return "Pizza Margherita"; }
        public double Prezzo() { return 7.00; }
    }

    public abstract class IngredienteExtra : IPiatto
    {
        protected IPiatto piattoBase;
        public IngredienteExtra(IPiatto piatto) { piattoBase = piatto; }
        public abstract string Descrizione();
        public abstract double Prezzo();
    }

    public class ConFormaggio : IngredienteExtra
    {
        public ConFormaggio(IPiatto p) : base(p) { }
        public override string Descrizione() 
        { 
            return piattoBase.Descrizione() + " + Formaggio fuso"; 
        }
        public override double Prezzo() 
        { 
            return piattoBase.Prezzo() + 1.50; 
        }
    }

    // 5. FACTORY PATTERN (Creazione Base)
    public static class PiattoFactory
    {
        public static IPiatto Crea(string tipo)
        {
            if (tipo.ToLower() == "pizza")
            {
                return new Pizza();
            }
            else
            {
                throw new Exception("Piatto non disponibile!");
            }
        }
    }
    public class Chef
    {
        private IPreparazioneStrategia _strategia;
        private List<IOsservatore> _clienti = new List<IOsservatore>();

        public void AggiungiCliente(IOsservatore c) { _clienti.Add(c); }
        public void ImpostaCottura(IPreparazioneStrategia s) { _strategia = s; }

        public void Cucina(IPiatto piatto)
        {
            if (_strategia != null)
            {
                string risultato = _strategia.Prepara(piatto.Descrizione());
                
                // Registra l'incasso nel Singleton
                CassaRistorante.GetIstanza().AggiungiAlTotale(piatto.Prezzo());

                // Notifica gli osservatori
                foreach (IOsservatore c in _clienti)
                {
                    c.Notifica("Il piatto '" + risultato + "' è pronto! Totale: " + piatto.Prezzo() + "€");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Chef loChef = new Chef();
            loChef.AggiungiCliente(new Cliente("Studente"));

            Console.WriteLine("=== RISTORANTE 5 DESIGN PATTERNS (SINTASSI CLASSICA) ===");

            // Factory
            IPiatto mioOrdine = PiattoFactory.Crea("pizza");

            // Decorator
            mioOrdine = new ConFormaggio(mioOrdine);

            // Strategy
            loChef.ImpostaCottura(new CotturaAlForno());

            // Esecuzione
            loChef.Cucina(mioOrdine);

            // Singleton
            Console.WriteLine("\n[CASSA]: Totale incassato oggi: " + CassaRistorante.GetIstanza().GetTotale() + "€");
            
            Console.ReadKey();
        }
    }
}