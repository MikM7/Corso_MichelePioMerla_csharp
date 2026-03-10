CREATE DATABASE IF NOT EXISTS FestivalMusicale;
USE FestivalMusicale;

-- Tabella Artisti
CREATE TABLE Artista (
    IdArtista INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Tipo ENUM('Singolo', 'Band') NOT NULL
);

-- Tabella Palchi
CREATE TABLE Palco (
    IdPalco INT PRIMARY KEY,
    Nome VARCHAR(50) UNIQUE NOT NULL,
    Capacita INT NOT NULL CHECK (Capacita > 0)
);

-- Tabella Performance (Gestisce più giorni e più esibizioni)
CREATE TABLE Performance (
    IdPerf INT PRIMARY KEY,
    DataOra DATETIME NOT NULL,
    IdArtista INT NOT NULL,
    IdPalco INT NOT NULL,
    FOREIGN KEY (IdArtista) REFERENCES Artista(IdArtista),
    FOREIGN KEY (IdPalco) REFERENCES Palco(IdPalco)
);

-- Tabella Spettatori
CREATE TABLE Spettatore (
    IdSpettatore INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL
);

-- Tabella Biglietti (Prezzo variabile e tracciamento pagamenti)
CREATE TABLE Biglietto (
    IdBiglietto INT PRIMARY KEY,
    Prezzo DECIMAL(10,2) NOT NULL CHECK (Prezzo >= 0),
    DataPagamento DATE NOT NULL,
    IdSpettatore INT,
    IdPerf INT,
    FOREIGN KEY (IdSpettatore) REFERENCES Spettatore(IdSpettatore),
    FOREIGN KEY (IdPerf) REFERENCES Performance(IdPerf)
);

-- Tabella Collaborazioni (Relazione N-M tra artisti)
CREATE TABLE Collaborazione (
    IdArtista1 INT,
    IdArtista2 INT,
    IdPerf INT,
    PRIMARY KEY (IdArtista1, IdArtista2, IdPerf),
    FOREIGN KEY (IdArtista1) REFERENCES Artista(IdArtista),
    FOREIGN KEY (IdArtista2) REFERENCES Artista(IdArtista),
    FOREIGN KEY (IdPerf) REFERENCES Performance(IdPerf),
    CHECK (IdArtista1 < IdArtista2) 
);

-- Tabella Sponsor
CREATE TABLE Sponsor (
    IdSponsor INT PRIMARY KEY,
    NomeSponsor VARCHAR(100) NOT NULL
);

-- Tabella Sponsorizzazione (Associata a performance o artisti)
CREATE TABLE Sponsorizzazione (
    IdSponsor INT,
    IdPerf INT,
    Contributo DECIMAL(10,2),
    PRIMARY KEY (IdSponsor, IdPerf),
    FOREIGN KEY (IdSponsor) REFERENCES Sponsor(IdSponsor),
    FOREIGN KEY (IdPerf) REFERENCES Performance(IdPerf)
);

-- Tabella Staff Tecnico
CREATE TABLE Staff (
    IdStaff INT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Ruolo VARCHAR(50),
    IdPalco INT,
    FOREIGN KEY (IdPalco) REFERENCES Palco(IdPalco)
);

-- ==========================================================
-- 2. INSERIMENTO DATI COERENTI (DML)
-- ==========================================================

INSERT INTO Artista VALUES (1, 'Maneskin', 'Band'), (2, 'Coldplay', 'Band'), (3, 'Dua Lipa', 'Singolo'), (4, 'Pinguini Tattici', 'Band');
INSERT INTO Palco VALUES (1, 'Main Stage', 50000), (2, 'Green Stage', 15000);
INSERT INTO Performance VALUES 
(1, '2026-07-01 21:00:00', 1, 1), 
(2, '2026-07-01 23:00:00', 2, 1), 
(3, '2026-07-02 21:00:00', 1, 2), -- Maneskin su altro palco
(4, '2026-07-03 21:00:00', 3, 1);

INSERT INTO Spettatore VALUES (1, 'Mario Rossi', 'mario@test.it'), (2, 'Anna Verdi', 'anna@test.it');
INSERT INTO Biglietto VALUES 
(1, 90.00, '2026-06-01', 1, 1), (2, 95.00, '2026-06-02', 2, 1),
(3, 120.00, '2026-06-03', 1, 3), (4, 80.00, '2026-06-04', 2, 4);

INSERT INTO Collaborazione VALUES (1, 4, 1), (1, 4, 3); -- Collaborano 2 volte
INSERT INTO Sponsor VALUES (1, 'RedBull'), (2, 'Sony');
INSERT INTO Sponsorizzazione VALUES (1, 1, 5000), (1, 3, 3000), (1, 4, 2000);

-- ==========================================================
-- 3. RISOLUZIONE DELLE QUERY
-- ==========================================================

-- Q1: Numero performance per artista
SELECT Nome, (SELECT COUNT(*) FROM Performance WHERE IdArtista = Artista.IdArtista) as NumPerf FROM Artista;

-- Q2: Totale incasso per giorno
SELECT DATE(DataOra) AS Giorno, SUM(Prezzo) AS Totale 
FROM Performance P JOIN Biglietto B ON P.IdPerf = B.IdPerf GROUP BY Giorno;

-- Q3: Artisti su più di un palco
SELECT A.Nome FROM Artista A JOIN Performance P ON A.IdArtista = P.IdArtista 
GROUP BY A.Nome HAVING COUNT(DISTINCT IdPalco) > 1;

-- Q4: Palco con maggior numero spettatori
SELECT PA.Nome, COUNT(B.IdBiglietto) as Tot FROM Palco PA 
JOIN Performance PE ON PA.IdPalco = PE.IdPalco JOIN Biglietto B ON PE.IdPerf = B.IdPerf 
GROUP BY PA.Nome ORDER BY Tot DESC LIMIT 1;

-- Q5: Artista che ha generato maggior incasso
SELECT A.Nome, SUM(B.Prezzo) as Incasso FROM Artista A 
JOIN Performance P ON A.IdArtista = P.IdArtista JOIN Biglietto B ON P.IdPerf = B.IdPerf 
GROUP BY A.Nome ORDER BY Incasso DESC LIMIT 1;

-- Q6: Coppie artisti con almeno 2 collaborazioni
SELECT A1.Nome as Artista1, A2.Nome as Artista2 FROM Collaborazione C
JOIN Artista A1 ON C.IdArtista1 = A1.IdArtista JOIN Artista A2 ON C.IdArtista2 = A2.IdArtista
GROUP BY Artista1, Artista2 HAVING COUNT(*) >= 2;

-- Q7: Sponsor in almeno 3 giorni diversi
SELECT S.NomeSponsor FROM Sponsor S JOIN Sponsorizzazione SP ON S.IdSponsor = SP.IdSponsor
JOIN Performance P ON SP.IdPerf = P.IdPerf GROUP BY S.NomeSponsor HAVING COUNT(DISTINCT DATE(P.DataOra)) >= 3;

-- Q8: Per ogni giorno il palco con incasso più alto
SELECT Giorno, Nome, MaxIncasso FROM (
    SELECT DATE(P.DataOra) as Giorno, PA.Nome, SUM(B.Prezzo) as MaxIncasso,
    RANK() OVER(PARTITION BY DATE(P.DataOra) ORDER BY SUM(B.Prezzo) DESC) as rk
    FROM Palco PA JOIN Performance P ON PA.IdPalco = P.IdPalco JOIN Biglietto B ON P.IdPerf = B.IdPerf GROUP BY Giorno, PA.Nome
) as t WHERE rk = 1;

-- Q9: Variazione percentuale incasso giorno per giorno
SELECT Giorno, Totale, 
LAG(Totale) OVER (ORDER BY Giorno) as Ieri,
((Totale - LAG(Totale) OVER (ORDER BY Giorno)) / LAG(Totale) OVER (ORDER BY Giorno)) * 100 as VariazionePerc
FROM (SELECT DATE(DataOra) as Giorno, SUM(Prezzo) as Totale FROM Performance P JOIN Biglietto B ON P.IdPerf = B.IdPerf GROUP BY Giorno) as d;