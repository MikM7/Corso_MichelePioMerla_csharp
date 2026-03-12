using System;

namespace GamingSetupApp
{
    // 1. OBSERVER PATTERN
    public interface IOsservatore
    {
        void Aggiorna(string messaggio);
    }

    public class AmicoOnline : IOsservatore
    {
        private string _nome;
        public AmicoOnline(string nome) { _nome = nome; }

        public void Aggiorna(string msg)
        {
            Console.WriteLine("[NOTIFICA PER " + _nome + "]: " + msg);
        }
    }
    // 2. SOTTOSISTEMA
    public class Monitor
    {
        public void Accendi() { Console.WriteLine("Monitor: Visualizzazione logo 4K..."); }
        public void Spegni() { Console.WriteLine("Monitor: Standby..."); }
    }

    public class Tastiera
    {
        public void IlluminaRGB() { Console.WriteLine("Tastiera: Luci LED RGB attivate!"); }
        public void Spegni() { Console.WriteLine("Tastiera: Luci disattivate."); }
    }

    public class SchedaVideo
    {
        public void InizializzaDriver() { Console.WriteLine("GPU: Driver caricati, ventole al 20%."); }
        public void Stop() { Console.WriteLine("GPU: Raffreddamento in corso e arresto."); }
    }
    // 3. FACADE PATTERN
    public class GamingSetupFacade
    {
        private Monitor _monitor;
        private Tastiera _tastiera;
        private SchedaVideo _gpu;
        private List<IOsservatore> _amici = new List<IOsservatore>();

        public GamingSetupFacade()
        {
            _monitor = new Monitor();
            _tastiera = new Tastiera();
            _gpu = new SchedaVideo();
        }

        public void AggiungiAmico(IOsservatore amico)
        {
            _amici.Add(amico);
        }

        public void AvviaPostazione()
        {
            Console.WriteLine("\n--- AVVIO POSTAZIONE GAMING ---");
            _gpu.InizializzaDriver();
            _monitor.Accendi();
            _tastiera.IlluminaRGB();
            foreach (IOsservatore amico in _amici)
            {
                amico.Aggiorna("Il tuo amico è entrato in gioco! Unisciti alla lobby.");
            }
        }

        public void SpegniPostazione()
        {
            Console.WriteLine("\n--- SPEGNIMENTO IN CORSO ---");
            _tastiera.Spegni();
            _monitor.Spegni();
            _gpu.Stop();
            Console.WriteLine("Postazione pronta per il riposo.");
        }
    }
    // 4. SINGLETON PATTERN (Solo una postazione)
    public class GestorePostazione
    {
        private static GestorePostazione _istanza;
        private GamingSetupFacade _facade;

        private GestorePostazione()
        {
            _facade = new GamingSetupFacade();
        }

        public static GestorePostazione GetIstanza()
        {
            if (_istanza == null)
            {
                _istanza = new GestorePostazione();
            }
            return _istanza;
        }

        public GamingSetupFacade GetGamingSetup()
        {
            return _facade;
        }
    }
    // 5. CLIENT (Il giocatore)
    class Program
    {
        static void Main(string[] args)
        {
            GestorePostazione gestore = GestorePostazione.GetIstanza();
            GamingSetupFacade postazione = gestore.GetGamingSetup();
            postazione.AggiungiAmico(new AmicoOnline("Marco_Gamer99"));

            postazione.AvviaPostazione();

            Console.WriteLine("\n... Stai giocando a un titolo tripla A ...");
            System.Threading.Thread.Sleep(2000);

            postazione.SpegniPostazione();

            Console.ReadKey();
        }
    }
}