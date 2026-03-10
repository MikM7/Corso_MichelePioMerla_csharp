using System;

namespace GestioneOperatori
{
    // 1. Classe Base
    public class Operatore
    {
        private string _nome = "";
        private string _turno = "giorno"; // Default

        public string Nome 
        { 
            get { return _nome; } 
            set { _nome = value; } 
        }

        public string Turno
        {
            get { return _turno; }
            set 
            { 
                // Controllo: solo giorno o notte
                string v = value.ToLower();
                _turno = (v == "giorno" || v == "notte") ? v : "giorno"; 
            }
        }

        public virtual void EseguiCompito()
        {
            Console.WriteLine("Operatore generico in servizio.");
        }
    }

    // 2. Classi Derivate
    public class OperatoreEmergenza : Operatore
    {
        private int _livelloUrgenza;
        public int LivelloUrgenza
        {
            get { return _livelloUrgenza; }
            set { _livelloUrgenza = (value >= 1 && value <= 5) ? value : 1; }
        }

        public override void EseguiCompito()
        {
            Console.WriteLine($"Gestione emergenza di livello {LivelloUrgenza}.");
        }
    }

    public class OperatoreSicurezza : Operatore
    {
        public string AreaSorvegliata { get; set; } = "";

        public override void EseguiCompito()
        {
            Console.WriteLine($"Sorveglianza dell'area: {AreaSorvegliata}.");
        }
    }

    public class OperatoreLogistica : Operatore
    {
        private int _numeroConsegne;
        public int NumeroConsegne
        {
            get { return _numeroConsegne; }
            set { _numeroConsegne = value >= 0 ? value : 0; }
        }

        public override void EseguiCompito()
        {
            Console.WriteLine($"Coordinamento di {NumeroConsegne} consegne.");
        }
    }
}