using System;



    // --- 1. ASTRAZIONE ---
   
    public abstract class Persona
    {
        // --- 2. INCAPSULAMENTO ---
        private string _nome;
        public string Nome 
        { 
            get => _nome; 
            set => _nome = !string.IsNullOrWhiteSpace(value) ? value : "Sconosciuto"; 
        }

        public string IdBadge { get; protected set; } // Solo le classi figlie possono impostarlo

        public Persona(string nome, string idBadge)
        {
            Nome = nome;
            IdBadge = idBadge;
        }

        public abstract void RegistraIngresso();
    }

    // --- 3. EREDITARIETÀ ---

    public class Dipendente : Persona
    {
        public string Reparto { get; set; }

        public Dipendente(string nome, string idBadge, string reparto) 
            : base(nome, idBadge) 
        {
            Reparto = reparto;
        }

        // --- 4. POLIMORFISMO ---
        public override void RegistraIngresso()
        {
            Console.WriteLine($"[LOG DIPENDENTE] {Nome} (Badge: {IdBadge}) è entrato nel reparto {Reparto} alle {DateTime.Now.ToShortTimeString()}.");
        }
    }


    public class Visitatore : Persona
    {
        public string ResponsabileAccompagnatore { get; set; }

        public Visitatore(string nome, string idBadge, string responsabile) 
            : base(nome, idBadge)
        {
            ResponsabileAccompagnatore = responsabile;
        }

        public override void RegistraIngresso()
        {
            Console.WriteLine($"[LOG VISITATORE] {Nome} (Badge Temporaneo: {IdBadge}) è entrato. Accompagnato da: {ResponsabileAccompagnatore}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA GESTIONALE ACCESSI AZIENDALI ===\n");
            List<Persona> ingressiDelGiorno = new List<Persona>();

            ingressiDelGiorno.Add(new Dipendente("Giacomo Macchia", "DIP-101", "Sviluppo Software"));
            ingressiDelGiorno.Add(new Visitatore("Lorenzo Russi", "VIS-89", "Ing. Verdi"));
            ingressiDelGiorno.Add(new Dipendente("Sara Neri", "DIP-002", "Risorse Umane"));

            foreach (var p in ingressiDelGiorno)
            {
                p.RegistraIngresso();
            }

            Console.WriteLine("\nMonitoraggio completato. Premi un tasto per uscire...");
            Console.ReadKey();
        }
    }