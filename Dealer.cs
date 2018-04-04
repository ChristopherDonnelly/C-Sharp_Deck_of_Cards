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
            
            Console.WriteLine($"Get Score for: {name}");
            int score = player.getScore();
            
            Console.WriteLine($"Player # {playerNum}: {name}");
            Console.WriteLine(score);

            if(score > 21){
                Console.WriteLine($"{player.name} Busted");
                this.nextTurn();
            }else if(score == 21){
                this.nextTurn();
            }
        }

        public void startRound() {
            List<Player> players = this.table.players;
            Player dealer = players[players.Count-1];
            Console.WriteLine($"Get Score for: {dealer.name}");
            int score = dealer.getScore();

            if(score == 21){
                Console.WriteLine($"{dealer.name} Blackjack!");
                this.endRound(score);
            }else{
                this.nextPlay();
            }
        }

        public void nextPlay(){
            Player player = this.table.players[this.turn];

            Console.WriteLine($"Get Score for: {player.name}");
            int score = player.getScore();

            if(this.turn == this.table.players.Count-1){
                this.checkDealer();
            }else{
                if(score == 21){
                    Console.WriteLine($"Player {player.name} Blackjack!");
                    this.nextTurn();
                }else{
                    Console.WriteLine($"Ask Player {player.name} to 'Hit' or 'Stand'!");
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
            
            Console.WriteLine($"Get Score for: {dealer.name}");
            int dealerScore = dealer.getScore();
            int playerNum = players.Count;
            string name = dealer.name;

            Console.WriteLine("Dealer's hand: ");
            for(int i=0; i<dealer.hand.Count; i++){
                Console.WriteLine(dealer.hand[i]);
            }

            if(dealerScore >= 17){
                this.endRound(dealerScore);
            }else{
                while(dealerScore < 17){
                    Card card = this.deck.deal_card();

                    dealer.hand.Add(card);
                    Console.WriteLine($"{dealer.name} Received: {card}");

                    Console.WriteLine($"Get Score for: {dealer.name}");
                    dealerScore = dealer.getScore();
                }

                if(dealerScore > 21){
                    Console.WriteLine($"{dealer.name} Busted!");
                }
                this.endRound(dealerScore);
            }
        }

        public void endRound(int dealerScore) {
            List<Player> players = this.table.players;
            Console.WriteLine($"Dealers Score: {dealerScore}");
            foreach(Player player in players){

                Console.WriteLine($"Get Score for: {player.name}");
                int score = player.getScore();

                Console.WriteLine($"Checking Player: {player.name} - Score: {score}");
                
                if(dealerScore > 21 && score <= 21 || dealerScore < score && score <= 21){
                    Console.WriteLine($"Player {player.name} Won!");
                }else if(dealerScore == score && score <= 21){
                    Console.WriteLine($"Player {player.name} Push!");
                }else if(dealerScore > score && score < 21){
                    Console.WriteLine($"Player {player.name} Lost!");
                }
            }
        }
    }
}