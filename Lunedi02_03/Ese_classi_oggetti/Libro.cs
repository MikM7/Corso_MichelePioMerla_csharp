using System;

// Il namespace deve essere identico a quello di Program.cs
namespace EseClassi 
{
    public class Libro
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public int AnnoPubblicazione { get; set; }

        // COSTRUTTORE
        public Libro(string titolo, string autore, int anno)
        {
            Titolo = titolo;
            Autore = autore;
            AnnoPubblicazione = anno;
        }

        // METODO 1: Equals (Confronta il CONTENUTO)
        public override bool Equals(object? obj)
        {
            if (obj is Libro altro)
            {
                return Titolo == altro.Titolo && Autore == altro.Autore;
            }
            return false;
        }

        // METODO 2: GetHashCode (Impronta digitale dell'oggetto)
        public override int GetHashCode()
        {
            return HashCode.Combine(Titolo, Autore);
        }

        // METODO 3: MemberwiseClone (Metodo spiegato dal docente)
        // Crea una "copia superficiale" dell'oggetto
        public Libro CreaCopia()
        {
            // Essendo protetto (protected), lo richiamiamo qui dentro
            return (Libro)this.MemberwiseClone();
        }

        // METODO 4: Finalize (Il distruttore)
        // Chiamato dal Garbage Collector prima di distruggere l'oggetto
        ~Libro()
        {
            Console.WriteLine($"[SISTEMA] Pulizia risorse per: {Titolo}");
        }

        public override string ToString()
        {
            return $"{Titolo} di {Autore}";
        }
    }
}