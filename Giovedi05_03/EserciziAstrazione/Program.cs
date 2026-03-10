 class Program
    {
        static void Main(string[] args)
        {
            // Creazione della lista di tipo astratto
            List<DispositivoElettronico> inventario = new List<DispositivoElettronico>();

            // Aggiunta degli oggetti concreti alla lista
            inventario.Add(new Computer("Workstation 2017"));
            inventario.Add(new Stampante("HP OfficeStamp"));

            Console.WriteLine("--- Esecuzione Metodi Polimorfici ---\n");
            foreach (DispositivoElettronico disp in inventario)
            {
                disp.MostraInfo();
                disp.Accendi();    
                disp.Spegni();    
                Console.WriteLine("-----------------------------------");
            }

            // Blocco console per leggere i risultati
            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
}