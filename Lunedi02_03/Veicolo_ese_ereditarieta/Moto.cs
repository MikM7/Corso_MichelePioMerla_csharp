using System;

namespace GestoreGarage
{
    public class Moto : Veicolo
    {
        public string TipoManubrio { get; set; }

        public Moto(string marca, string modello, string tipoManubrio) : base(marca, modello)
        {
            TipoManubrio = tipoManubrio;
        }

        public override void StampaInfo()
        {
            base.StampaInfo();
            Console.WriteLine(", Manubrio: " + TipoManubrio + " (Tipologia: MOTO)");
        }
    }
}