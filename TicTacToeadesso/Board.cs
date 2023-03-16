namespace TicTacToeadesso
{
    internal class Board
    {
        static char[,] board = new char[3, 3]; // Spielfeld
        static bool gameover = false;
        static Player currentPlayer; // Aktueller Spieler
        public void Start(Player spieler1, Player spieler2)
        {
            // Initialisiere das Spielfeld
            InitializeBoard();
           
            currentPlayer=spieler1;
            // Schleife, bis das Spiel beendet ist
            while (!gameover)
            {
                // Spielfelderstellung
                Console.Clear();
                DrawBoard();

                // Aufforderung zum spielen
                Console.WriteLine("Spieler " + currentPlayer.Name + " ist am Zug. Geben Sie eine Zeile von 1-3 und Spalte von 1-3 ein:");
                Console.Write("Zeile:");
                int row = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Spalte:");
                int col = int.Parse(Console.ReadLine()) - 1;

                // Überprüfe, ob der Zug gültig ist
                if (IsValidMove(row, col))
                {
                    // Setze das Zeichen des Spielers auf das Feld
                    board[row, col] = currentPlayer.Symbol;

                    // Überprüfe, ob das Spiel beendet ist
                    if (IsGameOver())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Das Spiel ist beendet! Spieler " + currentPlayer.Name + " hat gewonnen.");
                        gameover=true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Das Spiel ist beendet! Unentschieden.");
                        gameover=true;
                    }

                    // Spielerwechsel
                    if (currentPlayer==spieler1)
                    {
                        currentPlayer=spieler2;
                    }
                    else
                    {
                        currentPlayer=spieler1;
                    }
                }
                else
                {
                    Console.WriteLine("Ungültiger Zug! Bitte geben Sie eine andere Position ein.");
                }
            }

            //Abfrage ob nochmal gespielt werden soll
            Console.WriteLine("Möchten sie noch eine Runde spielen ? J/N");
            Console.Write("Eingabe:");
            string eingabe = Console.ReadLine();
            if (eingabe=="J" || eingabe=="Ja" || eingabe=="ja")
            {
                //Bool zurücksetzen
                gameover=false;
                //Spiel erneut starten
                Start(spieler1, spieler2);
            }
            //Spiel wird beendet
            else if (eingabe=="N" || eingabe=="Nein" || eingabe=="nein")
            {
                Console.WriteLine("Danke fürs Mitspielen!");
            }

            Console.WriteLine("Drücken sie eine beliebige taste zum beenden");
            Console.ReadLine();
        }
        // Initialisiert das Spielfeld mit Leerzeichen
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        // Zeichnet das Spielfeld
        static void DrawBoard()
        {
            Console.WriteLine("  1 2 3");
            Console.WriteLine(" -------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write((i + 1) + "|");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + "|");
                }
                Console.WriteLine();
                Console.WriteLine(" -------");
            }
        }

        // Überprüft, ob ein Zug gültig ist
        static bool IsValidMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                return false; // Außerhalb des Spielfelds
            }
            else if (board[row, col] != ' ')
            {
                return false; // Bereits belegt
            }
            else
            {
                return true; // Gültig
            }
        }
        // Überprüft, ob das Spiel beendet ist
        static bool IsGameOver()
        {
            // Überprüfe Zeilen
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true; // Eine Zeile ist vollständig belegt
                }
            }

            // Überprüfe Spalten
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    return true; // Eine Spalte ist vollständig belegt
                }
            }

            // Überprüfe Diagonalen
            if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true; // Hauptdiagonale ist vollständig belegt
            }
            else if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true; // Nebendiagonale ist vollständig belegt
            }

            // Das Spiel ist nicht beendet
            return false;
        }

        // Überprüft, ob das Spielfeld vollständig belegt ist
        static bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        return false; // Es gibt mindestens ein leeres Feld
                    }
                }
            }

            // Das Spielfeld ist vollständig belegt
            return true;
        }
    }
}

