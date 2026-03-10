using System;

namespace AeroportoApp
{
    public class VoloAereo
    {
        private int _postiOccupati;

        public const int MaxPosti = 150;

        public string CodiceVolo { get; set; }

        public int PostiOccupati
        {
            get { return _postiOccupati; }
        }

        public int PostiLiberi
        {
            get { return MaxPosti - _postiOccupati; }
        }

        public VoloAereo(string codice)
        {
            CodiceVolo = codice;
            _postiOccupati = 0;
        }

        // Metodo prenotazione
        public bool EffettuaPrenotazione(int numeroPosti)
        {
            if (numeroPosti > 0 && numeroPosti <= PostiLiberi)
            {
                _postiOccupati += numeroPosti;
                Console.WriteLine($" Prenotazione di {numeroPosti} posti riuscita.");
                return true;
            }
            Console.WriteLine($" Errore: Posti insufficienti o numero non valido per {numeroPosti} posti.");
            return false;
        }

        // Metodo annullare
        public bool AnnullaPrenotazione(int numeroPosti)
        {
            if (numeroPosti > 0 && numeroPosti <= _postiOccupati)
            {
                _postiOccupati -= numeroPosti;
                Console.WriteLine($" Annullamento di {numeroPosti} posti riuscito.");
                return true;
            }
            Console.WriteLine($" Errore: Impossibile annullare {numeroPosti} posti.");
            return false;
        }

        // Visualizzazione stato
        public void VisualizzaStato()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine($"VOLO: {CodiceVolo}");
            Console.WriteLine($"Posti Occupati: {PostiOccupati} / {MaxPosti}");
            Console.WriteLine($"Posti Liberi:   {PostiLiberi}");
            Console.WriteLine("------------------------------------\n");
        }
    }
}