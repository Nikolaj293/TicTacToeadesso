namespace TicTacToeadesso
{
    class Program
    {
        static void Main(string[] args)
        {
            Board spielfeld = new Board();
           
            //Anlegen von Spielern
            Player spielerX = new Player("SpielerX", 'X');
            Player spielerO = new Player("SpielerO", 'O');

            //Starte Spiel
            spielfeld.Start(spielerX, spielerO);
        }   
    }
}