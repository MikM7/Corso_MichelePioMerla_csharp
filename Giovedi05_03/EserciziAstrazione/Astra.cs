using System;

   
    public abstract class DispositivoElettronico
    {
        
        public string Modello { get; set; }


        public DispositivoElettronico(string modello)
        {
            Modello = modello;
        }
        public abstract void Accendi();
        public abstract void Spegni();
        public virtual void MostraInfo()
        {
            Console.WriteLine($"Modello Dispositivo: {Modello}");
        }
    }

    public class Computer : DispositivoElettronico
    {
        public Computer(string modello) : base(modello) { }

        public override void Accendi()
        {
            Console.WriteLine("Il computer si avvia...");
        }

        public override void Spegni()
        {
            Console.WriteLine("Il computer si spegne.");
        }
    }
    public class Stampante : DispositivoElettronico
    {
        public Stampante(string modello) : base(modello) { }

        public override void Accendi()
        {
            Console.WriteLine("La stampante si accende.");
        }

        public override void Spegni()
        {
            Console.WriteLine("La stampante va in standby.");
        }
    }
