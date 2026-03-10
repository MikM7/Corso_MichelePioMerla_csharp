using System;

namespace AeroportoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione oggetto
            VoloAereo mioVolo = new VoloAereo("AZ123");

            Console.WriteLine("--- STATO INIZIALE volo ---");
            mioVolo.VisualizzaStato();

            mioVolo.EffettuaPrenotazione(50);
            mioVolo.VisualizzaStato();

            mioVolo.EffettuaPrenotazione(110); 
            mioVolo.VisualizzaStato();

            mioVolo.AnnullaPrenotazione(20);
            mioVolo.VisualizzaStato();

            mioVolo.EffettuaPrenotazione(30);
            mioVolo.VisualizzaStato();

            Console.WriteLine("Premi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}