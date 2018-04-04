using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    class Deck
    {
    
        List<string> suits = new List<string>();

        List<Card> cards = new List<Card>();

        public Deck()
        {
            this.suits.Add("Spade");
            this.suits.Add("Heart");
            this.suits.Add("Diamond");
            this.suits.Add("Club");

            this.reset();
        }

        public Deck reset() {
            foreach(string suit in this.suits){
                for(int j=0; j<13; j++){
                    this.cards.Add(new Card(suit, j+1));
                }
            }

            this.shuffle();
            return this;
        }

        public Deck shuffle() {
            List<Card> shuffled = new List<Card>();
            Random rand = new Random();
            
            while(this.cards.Count > 0){
                int idx = rand.Next(0, this.cards.Count);
                Card card = this.cards[idx];
                this.cards.RemoveAt(idx);
                
                shuffled.Add(card);
            }

            this.cards = shuffled;
            return this;
        }

        public Card deal_card(){
            Card card = this.cards[0];
            this.cards.RemoveAt(0);
            Console.WriteLine($"Drew card: {card}s");
            return card;
        }

        public void display() {
            foreach(Card card in this.cards){
                Console.WriteLine($"Card - {card}s");
            }
        }
    }
}