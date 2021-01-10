using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    //public Player player1;
    //public Player player2;
    //public Player player3;
    //public Player player4;
    public int turn;
    public int pass;
    public Player dealer;
    public static bool isRevolution = false;
    public List<Player> players = new List<Player>(); 
    public List<List<Card>> pile = new List<List<Card>>();

    void Awake()
    {
        // dealer.dealCards(player1);
        // dealer.dealCards(player2);
        // dealer.dealCards(player3);
        // dealer.dealCards(player4);
        foreach (Player player in players)
        {
            dealer.dealCards(player);
        }
        turn = 2;
        pass = 0;
        Destroy(dealer);
        //delete this later
        // List<Card> dummyList = new List<Card>();
        // dummyList.Add(new Card(0, "Spades", "placeholder"));
        // pile.Add(dummyList);
        Mafreidyne();
        for(int i = 0; i < 1000; i++)
        {
            foreach (Player player in players)
            {
                updatePile(player);
                Debug.Log(pile[pile.Count - 1][0].getCardID());
            }
        }
    }

    #region Compare
     
    #endregion

    public void Mafreidyne()   //clears the deck
    {
        pile.Clear();
        List<Card> dummyList = new List<Card>();
        dummyList.Add(new Card(0, "Spades", "placeholder"));
        pile.Add(dummyList);
        Debug.Log("Charge, Johanna!");
    }

    public void updatePile(Player currentPlayer)  
    {
        List<Card> playedCards = currentPlayer.play(pile[pile.Count - 1][0].getValue()); //fix this later
        if(playedCards.Count == 0) 
        {
            pass += 1;
            if(pass == 4) 
            {
                pass = 0;
                Mafreidyne();
            }
            return;
        }
        pass = 0; 
        pile.Add(playedCards);
        if(playedCards[0].getCardID() == "Three of Spades" && pile.Count >= 2 && pile[pile.Count - 2][0].getValue() == 666) 
        {
            Debug.Log("Three of Spades");
            Mafreidyne();
        }
    }

    public void takeTurn()
    {

    }
    

}

//     // public Card singleCard = new Card(4, "Diamonds");
//     public static void shuffle(int[] card,
//                                int n)
//     {

//         System.Random rand = new System.Random();

//         for (int i = 0; i < n; i++)
//         {

//             // Random for remaining positions.
//             int r = i + rand.Next(56 - i);

//             //swapping the elements
//             int temp = card[r];
//             card[r] = card[i];
//             card[i] = temp;

//         }
//     }
//     public static List<Card> Shuffle()
//     {                                                               // Spades, Diamonds, Clubs, Hearts
//         Card[] withJokersUnshuffled = new Card[] {new Card(14, "Spades", "Ace of Spades"), new Card(14, "Diamonds", "Ace of Diamonds"), new Card(14, "Clubs", "Ace of Clubs"),
//         new Card(14, "Hearts", "Ace of Hearts"), new Card(15, "Spades", "Two of Spades"), new Card(15, "Diamonds", "Two of Diamonds"), new Card(15, "Clubs", "Two of Clubs"),
//         new Card(15, "Hearts", "Two of Hearts"), new Card(3, "Spades", "Three of Spades"), new Card(3, "Diamonds", "Three of Diamonds"), new Card(3, "Clubs", "Three of Clubs"),
//         new Card(3, "Hearts", "Three of Hearts"), new Card(4, "Spades", "Four of Spades"), new Card(4, "Diamonds", "Four of Diamonds"), new Card(4, "Clubs", "Four of Clubs"),
//         new Card(4, "Hearts", "Four of Hearts"), new Card(5, "Spades", "Five of Spades"), new Card(5, "Diamonds", "Five of Diamonds"), new Card(5, "Clubs", "Five of Clubs"),
//         new Card(5, "Hearts", "Five of Hearts"), new Card(6, "Spades", "Six of Spades"), new Card(6, "Diamonds", "Six of Diamonds"), new Card(6, "Clubs", "Six of Clubs"),
//         new Card(6, "Hearts", "Six of Hearts"), new Card(7, "Spades", "Seven of Spades"), new Card(7, "Diamonds", "Seven of Diamonds"), new Card(7, "Clubs", "Seven of Clubs"),
//         new Card(7, "Hearts", "Seven of Hearts"), new Card(8, "Spades", "Eight of Spades"), new Card(8, "Diamonds", "Eight of Diamonds"), new Card(8, "Clubs", "Eight of Clubs"),
//         new Card(8, "Hearts", "Eight of Hearts"), new Card(9, "Spades", "Nine of Spades"), new Card(9, "Diamonds", "Nine of Diamonds"), new Card(9, "Clubs", "Nine of Clubs"),
//         new Card(9, "Hearts", "Nine of Hearts"), new Card(10, "Spades", "Ten of Spades"), new Card(10, "Diamonds", "Ten of Diamonds"), new Card(10, "Clubs", "Ten of Clubs"),
//         new Card(10, "Hearts", "Ten of Hearts"), new Card(11, "Spades", "Jack of Spades"), new Card(11, "Diamonds", "Jack of Diamonds"), new Card(11, "Clubs", "Jack of Clubs"),
//         new Card(11, "Hearts", "Jack of Hearts"), new Card(12, "Spades", "Queen of Spades"), new Card(12, "Diamonds", "Queen of Diamonds"), new Card(12, "Clubs", "Queen of Clubs"),
//         new Card(12, "Hearts", "Queen of Hearts"), new Card(13, "Spades", "King of Spades"), new Card(13, "Diamonds", "King of Diamonds"), new Card(13, "Clubs", "King of Clubs"),
//         new Card(13, "Hearts", "King of Hearts"), new Card(666, "Joker", "Joker1"), new Card(666, "Joker", "Joker2"), new Card(666, "Joker", "Joker3"), new Card(666, "Joker", "Joker4")};

//     // Array of cards from 0 to 55
//         int[] withJokerIndices = new int[56]; 
//         for(int i = 0; i < 56; i++)
//         {
//             withJokerIndices[i] = i;
//         } 
//         shuffle(withJokerIndices, 56);
//         List<Card> withJokers = new List<Card>();
//         for (int i = 0; i < 56; i++)
//         {
//             withJokers.Add(withJokersUnshuffled[withJokerIndices[i]]);
//             //Debug.Log(withJokers[withJokerIndices[i]].getCardID() + withJokers[withJokerIndices[i]].getValue());
//         }
//         //PlayerHand player1 = new PlayerHand(withJokers);
//         return withJokers;
//     }
//     public class PlayerHand
//     {
//       List<Card> cards = new List<Card>();
//       public PlayerHand(List<Card> cards)
//       {
//           //organize by value, then for same value organize by clubs, diamonds, hearts, spades
//         this.cards = cards;
//       }
//       public void OrganizeHand()
//       {
//           Dictionary<string, int> suit_to_val = new Dictionary<string, int>();
//           suit_to_val.Add("Clubs", 1);
//           suit_to_val.Add("Diamonds", 2);
//           suit_to_val.Add("Hearts", 3);
//           suit_to_val.Add("Spades", 4);
//           suit_to_val.Add("Joker", 5);
//           //suit_to_val["Hearts"] = 3
//           //compare values of each card. If the most recent min is equal in value to the previous min, compare suit values to determine true min. After this func is 
//           //done, use it in playable cards function to find index of which any card greater than that index can be played 
//           for(int i = 0; i < this.cards.Count - 1; i++)
//           {
//             Card min = this.cards[i];
//             int minIndex = i;
//             for(int e = i + 1; e < this.cards.Count; e++)
//             {
//                 if(this.cards[e].getValue() < min.getValue())
//                 {
//                     min = this.cards[e];
//                     minIndex = e;
//                 }
//                 else if(this.cards[e].getValue() == min.getValue())
//                 {
//                     if(suit_to_val[this.cards[e].getSuit()] < suit_to_val[min.getSuit()])
//                     {
//                         // min(card1, card2, key = lambda x: x.getCardValue())
//                         // cards[1,13]
//                         min = this.cards[e];
//                         minIndex = e;
//                     }
//                 }
//             }
//             Card temp = this.cards[i];
//             this.cards[i] = min;
//             this.cards[minIndex] = temp;
//           }
//       }
//       public void showCards()
//       {
//         for(int i = 0; i < 56; i++)
//         {
//             Debug.Log(cards[i].getCardID());
//         }
//       }
//       /*public List<Card> PlayableCards(PlayedCards playedCards, List<Card> selected)
//       {
//         List<Card> lastPlayed = playedCards.GetCards();
//         int ValueConstraint = lastPlayed[0].getValue();
//         int NumConstraint = lastPlayed.Count;
//       }*/
//     }

//     // Start is called before the first frame update
//     void Start()
//     {
//         PlayerHand player1 = new PlayerHand(Shuffle());
//         player1.showCards();
//         player1.OrganizeHand();
//         player1.showCards();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

