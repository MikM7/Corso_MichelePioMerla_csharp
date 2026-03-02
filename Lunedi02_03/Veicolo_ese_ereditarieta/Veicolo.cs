using System;

namespace GestoreGarage
{
    public class Veicolo
    {
        public string Marca { get; set; }
        public string Modello { get; set; }

        public Veicolo(string marca, string modello)
        {
            Marca = marca;
            Modello = modello;
        }

        public virtual void StampaInfo()
        {
            Console.Write("Marca: " + Marca + ", Modello: " + Modello);
        }
    }
}