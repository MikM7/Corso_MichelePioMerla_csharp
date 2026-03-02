using System;

namespace GestoreGarage
{
    public class Auto : Veicolo
    {
        public int NumeroPorte { get; set; }

        public Auto(string marca, string modello, int numeroPorte) : base(marca, modello)
        {
            NumeroPorte = numeroPorte;
        }

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine(", Porte: " + NumeroPorte + " (Tipologia: AUTO)");
        }
    }
}