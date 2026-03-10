using System;

namespace EsercitoApp
{
    public class Soldato
    {
        private string _nome = "";
        private string _grado = "";
        private int _anniServizio;

        public string Nome 
        { 
            get { return _nome; } 
            set { _nome = value; } 
        }

        public string Grado 
        { 
            get { return _grado; } 
            set { _grado = value; } 
        }

        public int AnniServizio
        {
            get { return _anniServizio; }
            set { _anniServizio = value >= 0 ? value : 0; }
        }

        public virtual void Descrizione()
        {
            Console.Write($"| NOME: {Nome,-12} | GRADO: {Grado,-10} | ANNI: {AnniServizio,-2} ");
        }
    }
}