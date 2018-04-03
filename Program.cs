using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Table gameTable = new Table(new Player[] {new Player("Chris"), new Player("Lawyer"), new Player("Ashley"), new Player("Mark")});
            Dealer dealer = new Dealer(gameTable);
            
            // gameTable.clearBoard();
            // dealer.reset().dealAll().startRound();
            //Player chris = new Player("Chris");

        }
    }
}
