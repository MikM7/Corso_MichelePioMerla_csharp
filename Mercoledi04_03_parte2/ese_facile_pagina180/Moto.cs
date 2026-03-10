using System;

namespace GarageApp
{
    public class Moto : Veicolo // Eredita da Veicolo
    {
        public string TipoManubrio;

        public Moto(string marca, string modello, string manubrio) : base(marca, modello)
        {
            TipoManubrio = manubrio;
        }

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine($"| MANUBRIO: {TipoManubrio,-10} | (Moto)");
        }
    }
}