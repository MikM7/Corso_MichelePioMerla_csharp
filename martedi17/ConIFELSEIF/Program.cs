using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== VALUTAZIONE SCOLASTICA ===");
        Console.Write("Inserisci un voto da 1 a 10: ");
        
        int voto = int.Parse(Console.ReadLine());
        if(voto < 1 || voto > 10)
        {
            Console.WriteLine("Errore: Il numero inserito non è compreso tra 1 e 10.");
        }
        else if(voto >= 1 && voto <= 4)
        {
            Console.WriteLine("Valutazione: INSUFFICIENTE");
        }
        else if(voto >= 5 && voto <= 6)
        {
            Console.WriteLine("Valutazione: SUFFICIENTE");
        }
        else if(voto >= 7 && voto <= 8)
        {
            Console.WriteLine("Valutazione: BUONO");
        }
        else
        {
            Console.WriteLine("Valutazione: OTTIMO");
        }

        //-------------------------------------
        Console.WriteLine("\nBMI vediamo un po");

        Console.Write("Inserisci altezza in metri (usa la virgola): ");
        double altezza = double.Parse(Console.ReadLine());

        Console.Write("Inserisci peso in kg: ");
        double peso = double.Parse(Console.ReadLine());

        double bmi = peso / (altezza * altezza);

        Console.WriteLine("Il tuo BMI è: " + bmi);

        if(bmi < 18.5)
        {
            Console.WriteLine("Categoria: Sottopeso");
        }
        else if(bmi >= 18.5 && bmi < 25)
        {
            Console.WriteLine("Categoria: Normopeso");
        }
        else if(bmi >= 25 && bmi <= 30)
        {
            Console.WriteLine("Categoria: Sovrappeso");
        }
        else
        {
            Console.WriteLine("Categoria: Obesita");
        }
        //------------------------------------------------------------
        Console.WriteLine("\nTEMPERATURA");
        Console.WriteLine("--- Convertitore di Temperatura ---");
        Console.Write("Inserisci la temperatura in Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        Console.WriteLine("\nScale disponibili: f, k, r");
        Console.Write("Scegli la scala: ");
        
        // Ho aggiunto .ToLower() così se scrivi 'F' o 'f' funziona lo stesso
        string scelta = Console.ReadLine().ToLower(); 

        double risultato = 0;
        string unita = "";
        
        if (scelta == "f")
        {
            risultato = (celsius * 9 / 5) + 32;
            unita = "Fahrenheit";
        }
        else if (scelta == "k")
        {
            risultato = celsius + 273.15;
            unita = "Kelvin";
        }
        else if (scelta == "r")
        {
            risultato = (celsius + 273.15) * 9 / 5;
            unita = "Rankine";
        }
        else
        {
            // MODIFICA: Ho tolto "return;". Ora stampa l'errore e va avanti.
            Console.WriteLine("Scelta non valida. Salto il calcolo della temperatura.");
        }
        
        if (unita != "") 
        {
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("Risultato: " + risultato + " " + unita);
            Console.WriteLine("------------------------------");
        }

        //SWITCH ------------------------------------------------------
        Console.WriteLine("\nesercizio prova con switch ");
        string giorno="lunedi";
        switch(giorno)
        {
            case "lunedi":
                Console.WriteLine("INIZIO SETTIMANA");
                break;
            case "venerdi":
                Console.WriteLine("QUASI WEEKEND");
                break;
            default:
                Console.WriteLine("altro giorno");
                break;
        }

        Console.Write("Inserisci un numero da 1 a 7: ");
        int numero = int.Parse(Console.ReadLine());

        switch (numero)
        {
            case 1:
                Console.WriteLine("Lunedì");
                break;
            case 2:
                Console.WriteLine("Martedì");
                break;
            case 3:
                Console.WriteLine("Mercoledì");
                break;
            case 4:
                Console.WriteLine("Giovedì");
                break;
            case 5:
                Console.WriteLine("Venerdì");
                break;
            case 6:
                Console.WriteLine("Sabato");
                break;
            case 7:
                Console.WriteLine("Domenica");
                break;
            default:
                Console.WriteLine("Numero non valido!");
                break;
        }

        //GEOMETRIA-------------------------------------------------------
        Console.WriteLine("\n--- GEOMETRIA ---");
        Console.WriteLine("1 (Quadrato), 2 (Cerchio), 3 (Triangolo)");
        int sceltaGeo=int.Parse(Console.ReadLine());

        switch (sceltaGeo)
        {
            case 1:
                Console.Write("Lato: ");
                double lato = double.Parse(Console.ReadLine());
                Console.WriteLine("Area: " + (lato * lato));
                break;
            case 2:
                Console.Write("Raggio: ");
                double raggio = double.Parse(Console.ReadLine());
                Console.WriteLine("Area: " + (raggio * raggio * 3.14));
                break;
            case 3:
                Console.Write("Base: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Altezza: ");
                double h = double.Parse(Console.ReadLine());
                Console.WriteLine("Area: " + (b * h / 2));
                break;
            default:
                Console.WriteLine("Errore scelta!");
                break;
        }

        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    } 
}