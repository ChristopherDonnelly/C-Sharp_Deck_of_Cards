using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    
    class Player
    {
        string _name;
        public string name {
            get { return _name; }
            set { _name = value; }
        }
        public List<Card> hand = new List<Card>();

        public Player(string name)
        {
            this._name = name;
        }

        public int getScore(){
            int score = 0, cardVal = 0, aces = 0;

            Console.WriteLine("*********************");

            foreach(Card card in this.hand){
                cardVal = (card.getCardWeight());

                Console.WriteLine($"Card Value: {cardVal} ({card})");
                if(cardVal == 11) {
                    aces += 1;
                }
                score += cardVal;
            }

            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"Aces: {aces}");

            while(score > 21 && aces > 0){
                score -= 10;
                aces -=1;
            }

            Console.WriteLine($"Score: {score}");
            Console.WriteLine("*********************");

            return score;
        }

        public override string ToString(){
            return $"Info for {this.name}\n********************";
        }
    }
}