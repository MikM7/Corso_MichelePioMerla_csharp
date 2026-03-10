using System;

namespace GarageApp
{
    public class Veicolo
    {
        public string Marca;
        public string Modello;

        public Veicolo(string marca, string modello)
        {
            Marca = marca;
            Modello = modello;
        }

        public virtual void StampaInfo()
        {
            Console.Write($"| MARCA: {Marca,-10} | MODELLO: {Modello,-10} ");
        }
    }
}