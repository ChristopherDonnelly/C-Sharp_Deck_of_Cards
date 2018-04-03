using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    
    class Dealer: Player
    {
        Deck deck = new Deck();
        Table table;

        int turn;

        public Dealer(Table table): base("Dealer")
        {
            this.deck.reset().shuffle();
            this.table = table;
            this.turn = 0;

            this.addDealerToTable();
            this.dealAll();
            this.startRound();
        }

        public void addDealerToTable(){
            this.table.addDealerToTable(this);
        }
        
        public Dealer reset(){
            this.deck.reset();
            this.turn = 0;
            return this;
        }

        public Dealer dealAll(){

            int counter = 0; 

            for(int i=0; i<2; i++){
                foreach(Player player in this.table.players){
                    int playerNum = counter + 1;
                    Card card = this.deck.deal_card();
                    string name = player.name;

                    player.hand.Add(card);

                    //If dealer then show 1 card and the back of the other
                    //If Player then
                    card.showCard();
                }
            }
            return this;
        }
            
        public void dealCard() {

            int counter = 0; 

            Player player = this.table.players[this.turn];
            string name = player.name;
            int playerNum = counter + 1;
            Card card = this.deck.deal_card();

            player.hand.Add(card);
            
            card.showCard();
            
            Console.WriteLine("Get Score for: {0}", name);
            int score = player.getScore();
            
            Console.WriteLine("Player #" + playerNum + ": " + name);
            Console.WriteLine(score);

            if(score > 21){
                Console.WriteLine(player.name + " Busted");
                this.nextTurn();
            }else if(score == 21){
                this.nextTurn();
            }
        }

        public void startRound() {
            List<Player> players = this.table.players;
            Player dealer = players[players.Count-1];
            Console.WriteLine("Get Score for: {0}", dealer.name);
            int score = dealer.getScore();

            if(score == 21){
                Console.WriteLine("{0} Blackjack!", dealer.name);
                this.endRound(score);
            }else{
                this.nextPlay();
            }
        }

        public void nextPlay(){
            Player player = this.table.players[this.turn];

            Console.WriteLine("Get Score for: {0}", player.name);
            int score = player.getScore();

            if(this.turn == this.table.players.Count-1){
                this.checkDealer();
            }else{
                if(score == 21){
                    Console.WriteLine("Player {0} Blackjack!", player.name);
                    this.nextTurn();
                }else{
                    Console.WriteLine("Ask Player {0} to 'Hit' or 'Stand'!", player.name);
                }
            }
        }

        public void nextTurn() {
            this.turn++;
            this.nextPlay();
        }

        public void checkDealer(){
            List<Player> players = this.table.players;
            Player dealer = players[players.Count-1];
            
            Console.WriteLine("Get Score for: {0}", dealer.name);
            int dealerScore = dealer.getScore();
            int playerNum = players.Count;
            string name = dealer.name;

            Console.WriteLine("Dealer's hand: ");
            for(int i=0; i<dealer.hand.Count; i++){
                Console.WriteLine(dealer.hand[i].showCard());
            }

            if(dealerScore >= 17){
                this.endRound(dealerScore);
            }else{
                while(dealerScore < 17){
                    Card card = this.deck.deal_card();

                    dealer.hand.Add(card);
                    Console.WriteLine("{0} Received: {1}", dealer.name, card.showCard());

                    Console.WriteLine("Get Score for: {0}", dealer.name);
                    dealerScore = dealer.getScore();
                }

                if(dealerScore > 21){
                    Console.WriteLine("{0} Busted", dealer.name);
                }
                this.endRound(dealerScore);
            }
        }

        public void endRound(int dealerScore) {
            List<Player> players = this.table.players;
            Console.WriteLine("Dealers Score: " + dealerScore);
            foreach(Player player in players){
                string playerName = player.name;

                Console.WriteLine("Get Score for: {0}", player.name);
                int score = player.getScore();

                Console.WriteLine("Checking Player: "+playerName+" - Score: "+score);
                
                if(dealerScore > 21 && score <= 21 || dealerScore < score && score <= 21){
                    Console.WriteLine("Player "+playerName+" Winner");
                }else if(dealerScore == score && score <= 21){
                    Console.WriteLine("Player "+playerName+" Push");
                }else if(dealerScore > score && score < 21){
                    Console.WriteLine("Player "+playerName+" Lost");
                }
            }
        }
    }
}