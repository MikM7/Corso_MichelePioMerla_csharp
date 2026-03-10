using System;

namespace GestoreGarage
{
    public class VoloAereo
    {
        // Costante
        public const int MaxPosti = 150;

        // Campo privato
        private int _postiOccupati;

        // Proprietà pubblica con get e set
        public string CodiceVolo { get; set; }

        // Proprietà in sola lettura (restituisce il valore del campo privato)
        public int PostiOccupati
        {
            get { return _postiOccupati; }
        }

        // Proprietà in sola lettura calcolata
        public int PostiLiberi
        {
            get { return MaxPosti - _postiOccupati; }
        }

        // Costruttore
        public VoloAereo(string codice)
        {
            CodiceVolo = codice;
            _postiOccupati = 0; // Inizialmente il volo è vuoto
        }

        // Metodo per prenotare
        public void EffettuaPrenotazione(int numeroPosti)
        {
            if (numeroPosti > 0 && numeroPosti <= PostiLiberi)
            {
                _postiOccupati += numeroPosti;
                Console.WriteLine("Prenotazione di " + numeroPosti + " posti effettuata con successo.");
            }
            else
            {
                Console.WriteLine("Errore: Posti insufficienti o numero non valido per il volo " + CodiceVolo);
            }
        }

        // Metodo per annullare
        public void AnnullaPrenotazione(int numeroPosti)
        {
            if (numeroPosti > 0 && numeroPosti <= _postiOccupati)
            {
                _postiOccupati -= numeroPosti;
                Console.WriteLine("Annullamento di " + numeroPosti + " posti effettuato.");
            }
            else
            {
                Console.WriteLine("Errore: Impossibile annullare " + numeroPosti + " posti.");
            }
        }

        // Metodo per visualizzare lo stato
        public void VisualizzaStato()
        {
            Console.WriteLine("\n--- STATO VOLO " + CodiceVolo + " ---");
            Console.WriteLine("Posti Occupati: " + PostiOccupati);
            Console.WriteLine("Posti Liberi: " + PostiLiberi);
            Console.WriteLine("Capienza Massima: " + MaxPosti);
            Console.WriteLine("--------------------------");
        }
    }
}