using System;

    public interface IPagamento
    {
        void EseguiPagamento(decimal importo);
        void MostraMetodo();
    }

    // --- 2. IMPLEMENTAZIONI ---

    // Pagamento con Carta
    public class PagamentoCarta : IPagamento
    {
        public string Circuito { get; set; }

        public PagamentoCarta(string circuito)
        {
            Circuito = circuito;
        }

        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento di {importo} euro con carta (Circuito: {Circuito})");
        }

        public void MostraMetodo()
        {
            Console.WriteLine("Metodo: Carta di credito");
        }
    }

    public class PagamentoContanti : IPagamento
    {
        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento di {importo} euro in contanti");
        }

        public void MostraMetodo()
        {
            Console.WriteLine("Metodo: Contanti");
        }
    }

    // Pagamento PayPal
    public class PagamentoPayPal : IPagamento
    {
        public string EmailUtente { get; set; }

        public PagamentoPayPal(string email)
        {
            EmailUtente = email;
        }

        public void EseguiPagamento(decimal importo)
        {
            Console.WriteLine($"Pagamento di {importo} euro tramite PayPal da: {EmailUtente}");
        }

        public void MostraMetodo()
        {
            Console.WriteLine("Metodo: PayPal");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IPagamento> metodiPagamento = new List<IPagamento>();
            metodiPagamento.Add(new PagamentoCarta("Mastercard"));
            metodiPagamento.Add(new PagamentoContanti());
            metodiPagamento.Add(new PagamentoPayPal("michelepiomerla038@gmail.com"));

            Console.WriteLine("--- Elaborazione Pagamenti ---\n");

            foreach (IPagamento p in metodiPagamento)
            {
                p.MostraMetodo();
                p.EseguiPagamento(150.50m);
                Console.WriteLine("------------------------------");
            }

            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
