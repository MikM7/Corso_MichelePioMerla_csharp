namespace EsercitoApp
{
    public class Fante : Soldato
    {
        private string _arma = "";

        public string Arma
        {
            get { return _arma; }
            set { _arma = value; }
        }

        public override void Descrizione()
        {
            base.Descrizione();
            Console.WriteLine($"| ARMA: {Arma,-10} | (Fante)");
        }
    }
}