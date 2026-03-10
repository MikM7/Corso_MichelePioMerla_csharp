using System;


public interface IBevanda
{
    string NomeCompleto();
    double PrezzoTotale();
}

public class Caffe : IBevanda
{
    public string NomeCompleto() => "Caffè";
    public double PrezzoTotale() => 1.00;
}

public class Te : IBevanda
{
    public string NomeCompleto() => "Tè";
    public double PrezzoTotale() => 1.20;
}


public abstract class StratoIngrediente : IBevanda
{
    protected IBevanda _bevandaInterna; 
    public StratoIngrediente(IBevanda b) => _bevandaInterna = b;

    public virtual string NomeCompleto() => _bevandaInterna.NomeCompleto();
    public virtual double PrezzoTotale() => _bevandaInterna.PrezzoTotale();
}

public class ConPanna : StratoIngrediente
{
    public ConPanna(IBevanda b) : base(b) { }
    public override string NomeCompleto() => base.NomeCompleto() + " + soffice Panna";
    public override double PrezzoTotale() => base.PrezzoTotale() + 0.80;
}

public class ConLatte : StratoIngrediente
{
    public ConLatte(IBevanda b) : base(b) { }
    public override string NomeCompleto() => base.NomeCompleto() + " + un goccio di Latte";
    public override double PrezzoTotale() => base.PrezzoTotale() + 0.50;
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Esempio uso: dotnet run -- caffe panna latte");
            return;
        }
        IBevanda mioOrdine;
        if (args[0].ToLower() == "te") mioOrdine = new Te();
        else mioOrdine = new Caffe();
        for (int i = 1; i < args.Length; i++)
        {
            string scelta = args[i].ToLower();

            if (scelta == "panna")
            {
                mioOrdine = new ConPanna(mioOrdine);
                Console.WriteLine("-> Aggiunta Panna!");
            }
            else if (scelta == "latte")
            {
                mioOrdine = new ConLatte(mioOrdine);
                Console.WriteLine("-> Aggiunto Latte!");
            }
        }
        Console.WriteLine("\n--- SCONTRINO FINALE ---");
        Console.WriteLine($"Prodotto: {mioOrdine.NomeCompleto()}");
        Console.WriteLine($"Prezzo: {mioOrdine.PrezzoTotale()} Euro");
    }
}