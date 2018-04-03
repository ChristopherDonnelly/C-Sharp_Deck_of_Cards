using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    
    class Table
    {
        public List<Player> players = new List<Player>();

        public Table(Player[] players)
        {
            foreach(Player player in players){
                this.players.Add(player);
            }
            this.addPlayersToTable();
        }

        public void addPlayersToTable(){
            int playerCount = 0;
            foreach(Player player in this.players){
                playerCount++;
                Console.WriteLine("Player #{0}: {1}", playerCount, player.name);
            }
        }

        public void addDealerToTable(Player dealer){
            this.players.Add(dealer);
            Console.WriteLine("Dealer: {0}", dealer.name);
        }

        public void clearBoard(){
            foreach(Player player in this.players){
                // player.hand.Count = 0;
            }
        }
    }
}