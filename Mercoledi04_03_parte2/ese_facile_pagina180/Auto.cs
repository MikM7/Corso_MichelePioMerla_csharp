using System;

namespace GarageApp
{
    public class Auto : Veicolo 
    {
        public int NumeroPorte;

        public Auto(string marca, string modello, int porte) : base(marca, modello)
        {
            NumeroPorte = porte;
        }

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine($"| PORTE: {NumeroPorte,-2} | (Auto)");
        }
    }
}