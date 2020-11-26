    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public static void shuffle(int[] cardindex, int n)
    {
        System.Random rand = new System.Random();

        for (int i = 0; i < n; i++)
        {

            // Random for remaining positions.
            int r = i + rand.Next(56 - i);

            //swapping the elements
            int temp = cardindex[r];
            cardindex[r] = cardindex[i];
            cardindex[i] = temp;
        }
    }
    public static List<Card> Shuffle()
    {                                                               // Spades, Diamonds, Clubs, Hearts
        Card[] withJokersUnshuffled = new Card[] {new Card(14, "Spades", "Ace of Spades"), new Card(14, "Diamonds", "Ace of Diamonds"), new Card(14, "Clubs", "Ace of Clubs"),
        new Card(14, "Hearts", "Ace of Hearts"), new Card(15, "Spades", "Two of Spades"), new Card(15, "Diamonds", "Two of Diamonds"), new Card(15, "Clubs", "Two of Clubs"),
        new Card(15, "Hearts", "Two of Hearts"), new Card(3, "Spades", "Three of Spades"), new Card(3, "Diamonds", "Three of Diamonds"), new Card(3, "Clubs", "Three of Clubs"),
        new Card(3, "Hearts", "Three of Hearts"), new Card(4, "Spades", "Four of Spades"), new Card(4, "Diamonds", "Four of Diamonds"), new Card(4, "Clubs", "Four of Clubs"),
        new Card(4, "Hearts", "Four of Hearts"), new Card(5, "Spades", "Five of Spades"), new Card(5, "Diamonds", "Five of Diamonds"), new Card(5, "Clubs", "Five of Clubs"),
        new Card(5, "Hearts", "Five of Hearts"), new Card(6, "Spades", "Six of Spades"), new Card(6, "Diamonds", "Six of Diamonds"), new Card(6, "Clubs", "Six of Clubs"),
        new Card(6, "Hearts", "Six of Hearts"), new Card(7, "Spades", "Seven of Spades"), new Card(7, "Diamonds", "Seven of Diamonds"), new Card(7, "Clubs", "Seven of Clubs"),
        new Card(7, "Hearts", "Seven of Hearts"), new Card(8, "Spades", "Eight of Spades"), new Card(8, "Diamonds", "Eight of Diamonds"), new Card(8, "Clubs", "Eight of Clubs"),
        new Card(8, "Hearts", "Eight of Hearts"), new Card(9, "Spades", "Nine of Spades"), new Card(9, "Diamonds", "Nine of Diamonds"), new Card(9, "Clubs", "Nine of Clubs"),
        new Card(9, "Hearts", "Nine of Hearts"), new Card(10, "Spades", "Ten of Spades"), new Card(10, "Diamonds", "Ten of Diamonds"), new Card(10, "Clubs", "Ten of Clubs"),
        new Card(10, "Hearts", "Ten of Hearts"), new Card(11, "Spades", "Jack of Spades"), new Card(11, "Diamonds", "Jack of Diamonds"), new Card(11, "Clubs", "Jack of Clubs"),
        new Card(11, "Hearts", "Jack of Hearts"), new Card(12, "Spades", "Queen of Spades"), new Card(12, "Diamonds", "Queen of Diamonds"), new Card(12, "Clubs", "Queen of Clubs"),
        new Card(12, "Hearts", "Queen of Hearts"), new Card(13, "Spades", "King of Spades"), new Card(13, "Diamonds", "King of Diamonds"), new Card(13, "Clubs", "King of Clubs"),
        new Card(13, "Hearts", "King of Hearts"), new Card(666, "Joker", "Joker1"), new Card(666, "Joker", "Joker2"), new Card(666, "Joker", "Joker3"), new Card(666, "Joker", "Joker4")};

    // Array of Cards from 0 to 55
        int[] withJokerIndices = new int[56]; 
        for(int i = 0; i < 56; i++)
        {
            withJokerIndices[i] = i;
        } 
        shuffle(withJokerIndices, 56);
        List<Card> withJokers = new List<Card>();
        for (int i = 0; i < 56; i++)
        {
            withJokers.Add(withJokersUnshuffled[withJokerIndices[i]]);
            //Debug.Log(withJokers[withJokerIndices[i]].getCardID() + withJokers[withJokerIndices[i]].getValue());
        }
        //PlayerHand player1 = new PlayerHand(withJokers);
        return withJokers;
    }
}
