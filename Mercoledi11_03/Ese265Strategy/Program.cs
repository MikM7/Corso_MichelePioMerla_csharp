using System;

namespace SistemaPagamenti
{
    public interface IPaymentStrategy
    {
        void Pay(decimal importo);
    }
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal importo) 
        {
            Console.WriteLine($" Pagamento di {importo}€ effettuato con Carta di Credito.");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal importo) 
        {
            Console.WriteLine($"🅿️ Pagamento di {importo}€ effettuato tramite PayPal.");
        }
    }

    public class BitcoinPayment : IPaymentStrategy
    {
        public void Pay(decimal importo) 
        {
            Console.WriteLine($"₿ Pagamento di {importo}€ effettuato in Bitcoin (Blockchain confermata).");
        }
    }
    public class PaymentContext
    {
        private IPaymentStrategy _strategy;
        public void SetStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecutePayment(decimal importo)
        {
            if (_strategy == null)
            {
                Console.WriteLine(" Errore: Seleziona prima un metodo di pagamento!");
            }
            else
            {
                _strategy.Pay(importo);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext context = new PaymentContext();
            decimal importoDaPagare = 100m;

            Console.WriteLine("=== CHECKOUT ONLINE ===");
            Console.WriteLine($"Totale da pagare: {importoDaPagare}€");
            Console.WriteLine("\nScegli il metodo di pagamento:");
            Console.WriteLine("1. Carta di Credito");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Bitcoin");
            Console.Write("\nInserisci scelta (1-3): ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    context.SetStrategy(new CreditCardPayment());
                    break;
                case "2":
                    context.SetStrategy(new PayPalPayment());
                    break;
                case "3":
                    context.SetStrategy(new BitcoinPayment());
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    return;
            }
            context.ExecutePayment(importoDaPagare);

            Console.WriteLine("\nGrazie per l'acquisto! Premi un tasto per uscire.");
            Console.ReadKey();
        }
    }
}