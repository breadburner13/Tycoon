using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComparison : MonoBehaviour
{
    public bool isRevolution = false;
    public PlayedCards lastCardsPlayed;
    void Start()
    {
        lastCardsPlayed = new PlayedCards(new List<Card>());
    }
    public class PlayedCards
    {
        List<Card> cards = new List<Card>();
        public PlayedCards(List<Card> cards) //A list of the most recently played cards. 
        {
            this.cards = cards;
        }
        public int GetLength()
        {
            return cards.Count;
        }
        public List<Card> GetCards()
        {
            return this.cards;
        }
        public void addCard()
        {
            
        }
        public int GetValPlayed()
        {
            return cards[0].getValue();
        }
    }
    public class PlayerCards
    {
        List<Card> cards = new List<Card>();
        public void checkPlayable()
        {
            
            for(int i = 0; i < cards.Count; i++)
            {
                //bool urmom = CompareValues(cards[i], PlayedCards.GetValPlayed())
            }
        }
    }
    public class SelectedCards
    {
        List<Card> cards = new List<Card>();
    }
    public bool CompareValues(Card card1, int value2)
    {
        //Iterate through hand, compare each card to value of whatever was last played
        int value1 = card1.getValue(); //The card we're going to play
        if(value1 == 666)
        {
            return true;
        }
        if(value2 == 666 && value1 == 3)
        {
            return card1.getSuit() == "Spades";
        }
        if(isRevolution)
        {
            return value2 > value1;
        }
        return value1 > value2;
    }   
}
