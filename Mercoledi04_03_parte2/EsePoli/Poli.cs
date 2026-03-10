using System;

namespace OfficinaApp
{
    public class Veicolo
    {
        public string Targa { get; set; } = "";

        public virtual void Ripara()
        {
            Console.WriteLine($"[TARGA: {Targa}] Il veicolo viene controllato.");
        }
    }

    public class Auto : Veicolo
    {
        public override void Ripara()
        {
            Console.WriteLine($"[TARGA: {Targa}] Controllo olio, freni e motore dell'auto.");
        }
    }

    public class Moto : Veicolo
    {
        public override void Ripara()
        {
            Console.WriteLine($"[TARGA: {Targa}] Controllo catena, freni e gomme della moto.");
        }
    }

    public class Camion : Veicolo
    {
        public override void Ripara()
        {
            Console.WriteLine($"[TARGA: {Targa}] Controllo sospensioni, freni rinforzati e carico del camion.");
        }
    }
}