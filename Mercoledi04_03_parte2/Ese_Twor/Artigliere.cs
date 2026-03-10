namespace EsercitoApp
{
    public class Artigliere : Soldato
    {
        private int _calibro;

        public int Calibro
        {
            get { return _calibro; }
            set { _calibro = value > 0 ? value : 1; } // Solo valori positivi
        }

        public override void Descrizione()
        {
            base.Descrizione();
            Console.WriteLine($"| CALIBRO: {Calibro + "mm",-8} | (Artigliere)");
        }
    }
}