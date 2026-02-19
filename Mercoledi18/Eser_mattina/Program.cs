using System;

class Program
{
    //MERCOLEDI 18 Feb2026 Merla Michele Pio cicli eserczio bancomat password somma numeri calcolatri (WHILE, DO WHILE, SWITCH, FOR )
    static void Main(string[]args)
    {
        string continua="";
        do
        {
            Console.Clear();
            Console.WriteLine("Ciao! Oggi cosa vuoi fare?");
            Console.WriteLine("");
            Console.WriteLine("1. [Bancomat Poste]");
            Console.WriteLine("2. [Password] --3 tentativi--)");
            Console.WriteLine("3. [Somma dei numeri]--cliccando zero si termina");
            Console.WriteLine("4. [Calcolatrice]");
            Console.WriteLine("5. [TABELLINE A MONITOR]");
            Console.WriteLine("6. [MEDIA SOMMA A MONITOR]");
            Console.WriteLine("7. [FATTORIALE DI UN NUMERO]");
            Console.WriteLine("8. [REGISTRAZIONE E COUNTDOWN]");
            Console.WriteLine("");
            Console.Write("HAI SELEZIONATO___: ");
            
            if (!int.TryParse(Console.ReadLine(), out int sceltaMenu)) continue;

            switch(sceltaMenu)
            {
                case 1:
                    double saldo=0;
                    int tasto=0;
                    Console.WriteLine("--- Bancomat Poste ---");
                    while(tasto!=4)
                    {
                        Console.WriteLine("\nSaldo attuale: €"+saldo);
                        Console.WriteLine("1. Visualizza saldo\n2. Deposito\n3. Prelievo\n4. Esci");
                        Console.Write("HAI SELEZIONATO___: ");
                        if(!int.TryParse(Console.ReadLine(),out tasto))continue;
                        switch(tasto)
                        {
                            case 1:
                                Console.WriteLine("Saldo: "+saldo);
                                break;
                            case 2:
                                Console.Write("Importo deposito: €");
                                if(double.TryParse(Console.ReadLine(),out double deposito)&&deposito>0)saldo+=deposito;
                                else Console.WriteLine("Errore: Importo non valido!");
                                break;
                            case 3:
                                Console.Write("Importo prelievo: €");
                                if(double.TryParse(Console.ReadLine(),out double prelievo)&&prelievo>0)
                                {
                                    if(prelievo>saldo)Console.WriteLine("Errore: Saldo insufficiente!");
                                    else saldo-=prelievo;
                                }
                                else Console.WriteLine("Errore: Importo non valido!");
                                break;
                            case 4:
                                Console.WriteLine("_____Arrivederci___");
                                break;
                        }
                    }
                    break;
                case 2:
                    int passwordCorretta=1234;
                    int tentativi=0;
                    bool indovinata=false;
                    Console.WriteLine("--- LOGIN SICURO ---");
                    do
                    {
                        Console.Write("Inserisci la password numerica: ");
                        if(int.TryParse(Console.ReadLine(), out int passwordInserita))
                        {
                            tentativi++;
                            if(passwordInserita==passwordCorretta)
                            {
                                Console.WriteLine("Accesso consentito!");
                                indovinata=true;
                            }
                            else Console.WriteLine("Password errata. Tentativi rimasti: "+(3-tentativi));
                        }
                        else Console.WriteLine("Inserire solo numeri!");
                    }while(indovinata==false&&tentativi<3);
                    if(indovinata==false)Console.WriteLine("Tentativi esauriti. Account bloccato.");
                    break;
                case 3:
                    int numero;
                    int somma=0;
                    int contatore=0;
                    Console.WriteLine("Inserisci numeri interi (digita 0 per terminare):");
                    do
                    {
                        Console.Write("Inserisci un numero: ");
                        if(int.TryParse(Console.ReadLine(), out numero))
                        {
                            if(numero!=0)
                            {
                                somma=somma+numero;
                                contatore=contatore+1;
                            }
                        }
                    }while(numero!=0);
                    Console.WriteLine("\n--- RISULTATI ---");
                    Console.WriteLine("Somma totale: "+somma);
                    Console.WriteLine("Numeri inseriti: "+contatore);
                    break;
                case 4:
                    string scelta;
                    do
                    {
                        Console.WriteLine("\n--- CALCOLATRICE ---");
                        Console.Write("Inserisci il primo numero: ");
                        if(double.TryParse(Console.ReadLine(), out double n1))
                        {
                            Console.Write("Inserisci l'operazione (+,-,*,/): ");
                            string op=Console.ReadLine();
                            Console.Write("Inserisci il secondo numero: ");
                            if(double.TryParse(Console.ReadLine(), out double n2))
                            {
                                double risultato=0;
                                if(op=="+")
                                {
                                    risultato=n1+n2;
                                }
                                else if(op=="-")
                                {
                                    risultato=n1-n2;
                                }
                                else if(op=="*")
                                {
                                    risultato=n1*n2;
                                }
                                else if(op=="/")
                                {
                                    if(n2!=0)
                                    {
                                        risultato=n1/n2;
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Errore: Impossibile dividere per zero!");
                                    }
                                }
                                Console.WriteLine("Risultato: "+risultato);
                            }
                        }
                        Console.Write("\nVuoi fare un'altra operazione? (s/n): ");
                        scelta=Console.ReadLine().ToLower();
                    }while(scelta=="s");
                    break;
                case 5:
                    Console.WriteLine("\n--- TABELLINE A MONITOR ---");
                    Console.Write("Inserisci un numero intero: ");
                    if(int.TryParse(Console.ReadLine(),out int numTabellina))
                    {
                        for(int i=1;i<=10;i++)Console.WriteLine(numTabellina+" x "+i+" = "+(numTabellina*i));
                    }
                    else Console.WriteLine("Errore: Inserimento non valido!");
                    break;
                case 6:
                    Console.WriteLine("\n--- MEDIA SOMMA A MONITOR ---");
                    Console.Write("Quanti numeri vuoi inserire? ");
                    if(int.TryParse(Console.ReadLine(),out int q)&&q>0)
                    {
                        double s=0;
                        for(int i=1;i<=q;i++)
                        {
                            Console.Write("Inserisci numero "+i+": ");
                            if(double.TryParse(Console.ReadLine(),out double n))s+=n;
                            else{Console.WriteLine("Errore!");i--;}
                        }
                        Console.WriteLine("SOMMA: "+s);
                        Console.WriteLine("MEDIA: "+(s/q));
                    }
                    else Console.WriteLine("Quantità non valida!");
                    break;
                case 7:
                    Console.WriteLine("\n--- FATTORIALE DI UN NUMERO ---");
                    Console.Write("Inserisci un numero intero positivo: ");
                    if(int.TryParse(Console.ReadLine(),out int nFatt)&&nFatt>=0)
                    {
                        long fattoriale=1;
                        for(int i=1;i<=nFatt;i++)fattoriale=fattoriale*i;
                        Console.WriteLine("Il fattoriale di "+nFatt+" è: "+fattoriale);
                    }
                    else Console.WriteLine("###ERRORE###: devi inserire un numero positivo!");
                    break;
                case 8:
                    string sceltaRegistrazione = "";
                    do
                    {
                        Console.WriteLine("\n--- AREA REGISTRAZIONE ---");
                        Console.WriteLine("1. Registrati e Accedi");
                        Console.WriteLine("2. Esci e torna al menu");
                        Console.Write("Scelta: ");
                        string opz = Console.ReadLine();

                        switch (opz)
                        {
                            case "1":
                                Console.WriteLine("--- REGISTRAZIONE ---");
                                Console.Write("Nome: ");
                                string nomeregistra = Console.ReadLine(); 
                                Console.Write("Password: ");
                                string passwordregistra = Console.ReadLine(); 
                                Console.WriteLine("--- LOGIN ---");
                                Console.Write("Inserisci Nome: ");
                                string nomelogin = Console.ReadLine(); 
                                Console.Write("Inserisci Password: ");
                                string passwordlogin = Console.ReadLine(); 
                                if (nomelogin == nomeregistra && passwordlogin == passwordregistra) 
                                {
                                    Console.WriteLine("ACCESSO ESEGUITO");
                                    Console.Write("Secondi per il countdown: ");
                                    if (int.TryParse(Console.ReadLine(), out int sec)) 
                                    {
                                        for (int i = sec; i >= 0; i--) Console.WriteLine(i); 
                                    }
                                }
                                else Console.WriteLine("Accesso negato! Dati errati.");
                                break;
                            case "2":
                                sceltaRegistrazione = "fine";
                                break;
                            default:
                                Console.WriteLine("Scelta non valida!");
                                break;
                        }

                        if (sceltaRegistrazione != "fine")
                        {
                            Console.WriteLine("\nVuoi TORNARE in --area registrazione--? (s/n)");
                            if (Console.ReadLine().ToLower() != "s") sceltaRegistrazione = "fine";
                        }

                    } while (sceltaRegistrazione != "fine");
                    break;
                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }
            Console.WriteLine("\n*********************************************************************");
            Console.WriteLine("Vuoi tornare al menu principale? (s/n)");
            Console.WriteLine("*********************************************************************");
            continua=Console.ReadLine().ToLower();
        } while(continua=="s");

        Console.WriteLine("*********************************************************************");
        Console.WriteLine("\nTask successfully completed. Premi un tasto per uscire");
        Console.ReadKey();
    }
}