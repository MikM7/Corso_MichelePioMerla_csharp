using System;

// 1. IL "REQUISITO" (L'Interfaccia)
public interface IOrecchioDigitale 
{
    void ReagisciAlMessaggio(string notizia);
}

// 2. Il Soggetto - NewsAgency
public class AltoparlanteNotizie
{
    // La nostra rubrica di contatti che vogliono sentire
    private readonly List<IOrecchioDigitale> _listaAscoltatori = new List<IOrecchioDigitale>();
    private string _contenutoNotizia;
    public string NotiziaDaGridare
    {
        get => _contenutoNotizia;
        set 
        {
            _contenutoNotizia = value;
            InformaTuttiGliOrecchiInAscolto(); 
        }
    }

    public void RegistraNuovoAscoltatore(IOrecchioDigitale ascoltatore) => _listaAscoltatori.Add(ascoltatore);

    private void InformaTuttiGliOrecchiInAscolto()
    {
        foreach (var orecchio in _listaAscoltatori)
        {
            orecchio.ReagisciAlMessaggio(_contenutoNotizia);
        }
    }
}

// 3. I "REATTORI" (I Subscriber Concreti)
public class SmartphoneDelCliente : IOrecchioDigitale
{
    public void ReagisciAlMessaggio(string notizia) => 
        Console.WriteLine($"[BEEP-BEEP] Lo Smartphone mostra: {notizia}");
}

public class ServerEmailAziendale : IOrecchioDigitale
{
    public void ReagisciAlMessaggio(string notizia) => 
        Console.WriteLine($"[INVIANDO MAIL...] Il Server scrive: {notizia}");
}


public class Program
{
    public static void Main()
    {
        // Creiamo
        var agenzia = new AltoparlanteNotizie();

        // Creiamo chi deve reagire
        var cellulare = new SmartphoneDelCliente();
        var mailer = new ServerEmailAziendale();

        //(registriamo)
        agenzia.RegistraNuovoAscoltatore(cellulare);
        agenzia.RegistraNuovoAscoltatore(mailer);

        // --- SIMULAZIONE ---
        Console.WriteLine(">>> L'Agenzia riceve un flash news...");
        
        agenzia.NotiziaDaGridare = "ATTENZIONE: Il corso di C# è finito!";
    }
}