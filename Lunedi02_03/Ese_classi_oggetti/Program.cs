using System;

namespace EseClassi
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creiamo l'oggetto originale
            Libro libro1 = new Libro("CORSO C# febbraio-marzo", "ITCONSULTING", 2026);
            
            Console.WriteLine("--- TEST METODI SYSTEM.OBJECT ---");

            // 1. GetType()
            Console.WriteLine($"Tipo runtime: {libro1.GetType().FullName}");

            // 2. MemberwiseClone() (tramite il nostro metodo CreaCopia)
            Libro copia = libro1.CreaCopia();
            Console.WriteLine("\nCopia creata.");

            // 3. ReferenceEquals()
            // Controlla se sono lo stesso "pezzo di memoria"
            bool stessaMemoria = Object.ReferenceEquals(libro1, copia);
            Console.WriteLine($"Puntano alla stessa istanza? {stessaMemoria}"); // False

            // 4. Equals()
            // Controlla se il contenuto è uguale
            Console.WriteLine($"Contenuto uguale? {libro1.Equals(copia)}"); // True

            Console.WriteLine("\nPremi INVIO per chiudere e attivare la pulizia...");
            Console.ReadLine();
        }
    }
}