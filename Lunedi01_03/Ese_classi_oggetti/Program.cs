using System;

public class Libro
{
    public string Titolo { get; set; }
    public string Autore { get; set; }
    public int AnnoPubblicazione { get; set; }

    // CONSTRUTTORE
    public Libro(string titolo, string autore, int anno)
    {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = anno;
    }

    // Come vogliamo che venga stampato il libro
    public override string ToString()
{
    return $"SCHEDA LIBRO:\n" +
           $"--------------------------\n" +
           $"Titolo:  {Titolo}\n" +
           $"Autore:  {Autore}\n" +
           $"Anno:    {AnnoPubblicazione}\n" +
           $"--------------------------";
}
    // Regola per l'uguaglianza
    public override bool Equals(object obj)
    {
        if (obj is Libro altroLibro)
        {
            return Titolo == altroLibro.Titolo && Autore == altroLibro.Autore;
        }
        return false;
    }

    //Vediamo se il libro è uguale
    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore);
    }
}

class Program
{
    static void Main(String[] args)
    {
        // Creiamo i due libri
        Libro libro1 = new Libro("CORSO C#","ITCONSULTING", 2026);
        Libro libro2 = new Libro("CORSO C#", "ITCONSULTING",2026);

        Console.WriteLine("...Controlliamo...");
        Console.WriteLine(libro1.ToString());

        Console.WriteLine("\n--- Controlliamo...");
        Console.WriteLine($"I libri sono uguali? {libro1.Equals(libro2)}");

        Console.WriteLine("\n--- TEST HASHCODE ---");
        Console.WriteLine($"Hash 1: {libro1.GetHashCode()}");
        Console.WriteLine($"Hash 2: {libro2.GetHashCode()}");
        
        // Fermiamo la console per leggere il risultato
        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
}