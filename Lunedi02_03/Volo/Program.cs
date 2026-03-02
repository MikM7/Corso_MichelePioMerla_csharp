using System;

namespace GestoreGarage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione dell'oggetto volo
            VoloAereo mioVolo = new VoloAereo("AZ123");

            // Mostro lo stato iniziale
            mioVolo.VisualizzaStato();

            // 1. Prima prenotazione valida
            Console.WriteLine("Eseguo prenotazione di 50 posti...");
            mioVolo.EffettuaPrenotazione(50);
            mioVolo.VisualizzaStato();

            // 2. Seconda prenotazione valida
            Console.WriteLine("Eseguo prenotazione di 80 posti...");
            mioVolo.EffettuaPrenotazione(80);
            mioVolo.VisualizzaStato();

            // 3. Tentativo di prenotazione oltre il limite (130 + 30 = 160 > 150)
            Console.WriteLine("Eseguo prenotazione di 30 posti (dovrebbe fallire)...");
            mioVolo.EffettuaPrenotazione(30);
            mioVolo.VisualizzaStato();

            // 4. Annullamento parziale
            Console.WriteLine("Annullamento di 20 posti...");
            mioVolo.AnnullaPrenotazione(20);
            mioVolo.VisualizzaStato();

            // 5. Tentativo di annullamento non valido (più di quelli occupati)
            Console.WriteLine("Annullamento di 200 posti (dovrebbe fallire)...");
            mioVolo.AnnullaPrenotazione(200);
            mioVolo.VisualizzaStato();

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}