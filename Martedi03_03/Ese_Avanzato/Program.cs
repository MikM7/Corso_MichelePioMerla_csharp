class Program
    {
        static List<Corso> listaCorsi = new List<Corso>();

        static void Main(string[] args)
        {
            bool esci = false;
            while (!esci)
            {
                Console.WriteLine("\n--- GESTIONALE SCUOLA ARTISTICA ---");
                Console.WriteLine("[1] Aggiungi corso di Musica");
                Console.WriteLine("[2] Aggiungi corso di Pittura");
                Console.WriteLine("[3] Aggiungi corso di Danza");
                Console.WriteLine("[4] Aggiungi studente a un corso (per indice)");
                Console.WriteLine("[5] Visualizza tutti i corsi");
                Console.WriteLine("[6] Esegui metodo speciale (per indice)");
                Console.WriteLine("[7] Cerca corsi per nome docente");
                Console.WriteLine("[8] Esci");
                Console.Write("Scelta: ");

                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1": CreaCorso("Musica"); break;
                    case "2": CreaCorso("Pittura"); break;
                    case "3": CreaCorso("Danza"); break;
                    case "4": IscriviStudente(); break;
                    case "5": MostraCorsi(); break;
                    case "6": AzioneSpeciale(); break;
                    case "7": CercaPerDocente(); break;
                    case "8": esci = true; break;
                    default: Console.WriteLine("Opzione non valida!"); break;
                }
            }
        }

        static void CreaCorso(string tipo)
        {
            Console.Write("Nome: "); string nome = Console.ReadLine();
            Console.Write("Durata (ore): "); int ore = int.Parse(Console.ReadLine());
            Console.Write("Docente: "); string doc = Console.ReadLine();

            if (tipo == "Musica") {
                Console.Write("Strumento: "); string strum = Console.ReadLine();
                listaCorsi.Add(new CorsoMusica(nome, ore, doc, strum));
            } else if (tipo == "Pittura") {
                Console.Write("Tecnica: "); string tec = Console.ReadLine();
                listaCorsi.Add(new CorsoPittura(nome, ore, doc, tec));
            } else {
                Console.Write("Stile: "); string stile = Console.ReadLine();
                listaCorsi.Add(new CorsoDanza(nome, ore, doc, stile));
            }
            Console.WriteLine("Corso aggiunto!");
        }

        static void MostraCorsi()
        {
            if (listaCorsi.Count == 0) Console.WriteLine("Nessun corso presente.");
            for (int i = 0; i < listaCorsi.Count; i++)
                Console.WriteLine($"[{i}] {listaCorsi[i]}");
        }

        static void IscriviStudente()
        {
            MostraCorsi();
            if (listaCorsi.Count > 0) {
                Console.Write("Indice corso: "); int idx = int.Parse(Console.ReadLine());
                Console.Write("Nome studente: "); string s = Console.ReadLine();
                listaCorsi[idx].AggiungiStudente(s);
                Console.WriteLine("Studente aggiunto!");
            }
        }

        static void AzioneSpeciale()
        {
            MostraCorsi();
            if (listaCorsi.Count > 0) {
                Console.Write("Indice corso: "); int idx = int.Parse(Console.ReadLine());
                listaCorsi[idx].MetodoSpeciale();
            }
        }

        static void CercaPerDocente()
        {
            Console.Write("Inserisci nome docente: ");
            string cerca = Console.ReadLine();
            bool trovato = false;
            foreach (var c in listaCorsi) {
                if (c.Docente.IndexOf(cerca, StringComparison.OrdinalIgnoreCase) >= 0) {
                    Console.WriteLine(c.ToString());
                    trovato = true;
                }
            }
            if (!trovato) Console.WriteLine("Nessun corso trovato per questo docente.");
        }
    }