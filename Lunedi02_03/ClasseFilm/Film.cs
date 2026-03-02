using System;

namespace VideotecaApp
{
    public class Film
    {
        public string Titolo = "";
        public string Regista = "";
        public int Anno;
        public string Genere = "";

        public Film(string titolo, string regista, int anno, string genere)
        {
            Titolo = titolo;
            Regista = regista;
            Anno = anno;
            Genere = genere;
        }

        public override string ToString()
        {
            
            return $"| {Titolo,-20} | {Regista,-18} | {Anno,-5} | {Genere,-12} |\n";
        }
    }
}