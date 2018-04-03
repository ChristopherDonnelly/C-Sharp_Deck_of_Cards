namespace Deck_of_Cards
{
    
    class Card
    {
        string suit;
        
        int value;

        public Card(string suit, int value)
        {
            this.suit = suit;
            this.value = value;
        }

        public string getCardSuit(){
            return this.suit;
        }

        public string getCardValue(){
            return (this.value==1)?"Ace":(this.value==11)?"Jack":(this.value==12)?"Queen":(this.value==13)?"King":this.value.ToString();
        }

        public int getCardWeight(){
            return (this.value==1)?11:(this.value==11)?10:(this.value==12)?10:(this.value==13)?10:this.value;
        }

        public string showCard() {
            return "Card - " + this.getCardValue() + " of " + this.suit.ToString();
        }

    }
}