using System;
using System.Collections.Generic;

// 1. IL "CONTRATTO" PER CHI ASCOLTA
public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}

// 2. IL "CONTRATTO" PER CHI COMANDA
public interface ISoggetto
{
    void Registra(IObserver o);
    void Rimuovi(IObserver o);
    void Notifica(string nomeUtente);
}

// 3. L'OGGETTO DATI
public class Utente
{
    public string Nome { get; set; }
    public override string ToString() => $"[Profilo Utente: {Nome}]";
}

// 4. LA FABBRICA (Statica)
public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente { Nome = nome };
    }
}

// 5. IL SOGGETTO CONCRETO (Il Motore del sistema)
public class GestoreCreazioneUtente : ISoggetto
{
    private readonly List<IObserver> _listaOsservatori = new List<IObserver>();

    public void Registra(IObserver o) => _listaOsservatori.Add(o);
    public void Rimuovi(IObserver o) => _listaOsservatori.Remove(o);

    // Il metodo che avvisa tutti i moduli registrati
    public void Notifica(string nomeUtente)
    {
        foreach (var osservatore in _listaOsservatori)
        {
            osservatore.NotificaCreazione(nomeUtente);
        }
    }

    public void CreaUtente(string nome)
    {
        // A. Crea fisicamente l'oggetto usando la Factory
        Utente nuovoUtente = UserFactory.Crea(nome);
        Console.WriteLine($"\nSISTEMA: Creato {nuovoUtente}");

        // B. SCATENA L'EVENTO: Avvisa i moduli
        Notifica(nome);
    }
}

// 6. GLI OSSERVATORI CONCRETI (I Moduli reattivi)
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente) => 
        Console.WriteLine($"LOG: Scrittura nel database... L'utente '{nomeUtente}' è stato registrato.");
}

public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente) => 
        Console.WriteLine($"MARKETING: Invio email di benvenuto a '{nomeUtente}'...");
}

// 7. IL MAIN (Messa in funzione)
class Program
{
    static void Main()
    {
        // Setup del sistema
        GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
        
        // Iscrizione dei moduli
        gestore.Registra(new ModuloLog());
        gestore.Registra(new ModuloMarketing());

        Console.WriteLine("--- SISTEMA DI GESTIONE UTENTI ATTIVO ---");

        while (true)
        {
            Console.Write("\nInserisci il nome del nuovo utente (o 'exit' per uscire): ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit") break;

            // Il comando che fa partire a catena le notifiche
            gestore.CreaUtente(input);
        }
    }
}