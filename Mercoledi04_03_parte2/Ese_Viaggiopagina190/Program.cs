using System;

namespace AgenziaViaggi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creazione prenotazione
            PrenotazioneViaggio viaggio = new PrenotazioneViaggio("MILANO BY NIGHT");

            Console.WriteLine("=== GESTIONE PRENOTAZIONI VIAGGIO ===");
            viaggio.VisualizzaStato();

            // Test 1: Prenotazione normale
            viaggio.PrenotaPosti(10);
            viaggio.VisualizzaStato();

            // Test 2: Prenotazione eccessiva (deve fallire)
            viaggio.PrenotaPosti(15); 
            viaggio.VisualizzaStato();

            // Test 3: Annullamento
            viaggio.AnnullaPrenotazione(4);
            viaggio.VisualizzaStato();

            // Test 4: Prenotazione finale
            viaggio.PrenotaPosti(8);
            viaggio.VisualizzaStato();

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}