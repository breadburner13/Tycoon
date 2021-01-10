using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Card> hand; 

    public void dealCards(Player target)
    {
        for(int i = 0; i < 14; i++)
        {
            int cardIndex = Random.Range(0, this.hand.Count);
            Card thisCard = hand[cardIndex];
            this.hand.RemoveAt(cardIndex);
            target.hand[i] = thisCard;
            // Debug.Log("Kimi wa ne tashika ni ano toki watashi no soba ni ita Itsudatte itsudatte itsudatte sugu yoko de waratteita nakushitemo"); 
            // Debug.Log("Torimodosu kimi wo I will never leave you. If you wanna battle, then Ill take it to the streets Where theres no rules Take off the gloves ref,"); 
            // Debug.Log("please step down Gotta prove my skills so get down My lyrical dempsey roll about to smack down now Gotta shoot to kill and shoot the skill Dont you be afraid,");
            // Debug.Log("mans gotta do how it feels Six to seven to eight to nine ten I flip the script to make it to the top ten, go Dreamless dorm, ticking clock I walk away from the");
            // Debug.Log("soundless room Windless night, moonlight melts My ghostly shadow into the lukewarm gloom Nightly dance of bleeding swords Reminds me that I still live Every mans ");
            // Debug.Log("gotta fight the fear Im the first to admit it Sheer thoughts provoke the new era Become a big terror, but my only rival is my shadow Rewind then play it back and");
            // Debug.Log("fix my own error Get low to the ground, its getting better Like I told you before, double up and take more cheddar L to the J, say stay laced, heres my card, B Royal flush and Im the ace");
        }
        target.OrganizeHand();
    }

    public void OrganizeHand()
      {
          Dictionary<string, int> suit_to_val = new Dictionary<string, int>();
          suit_to_val.Add("Clubs", 1);
          suit_to_val.Add("Diamonds", 2);
          suit_to_val.Add("Hearts", 3);
          suit_to_val.Add("Spades", 4);
          suit_to_val.Add("Joker", 5);
          //suit_to_val["Hearts"] = 3
          //compare values of each card. If the most recent min is equal in value to the previous min, compare suit values to determine true min. After this func is 
          //done, use it in playable cards function to find index of which any card greater than that index can be played 
          for(int i = 0; i < this.hand.Count - 1; i++)
          {
            Card min = this.hand[i];
            int minIndex = i;
            for(int e = i + 1; e < this.hand.Count; e++)
            {
                if(this.hand[e].getValue() < min.getValue())
                {
                    min = this.hand[e];
                    minIndex = e;
                }
                else if(this.hand[e].getValue() == min.getValue())
                {
                    if(suit_to_val[this.hand[e].getSuit()] < suit_to_val[min.getSuit()])
                    {
                        // min(card1, card2, key = lambda x: x.getCardValue())
                        // cards[1,13]
                        min = this.hand[e];
                        minIndex = e;
                    }
                }
            }
            Card temp = this.hand[i];
            this.hand[i] = min;
            this.hand[minIndex] = temp;
          }
      }

    public bool compareValues(Card card1, int value2)
    {
        if(value2 == 0) //When any card can be played
        {
            return true;
        }
        int value1 = card1.getValue(); //The card we're going to play
        if(value1 == 666 && value2 != 666)
        {
            return true;
        }
        if(value2 == 666 && value1 == 3)
        {
            return card1.getSuit() == "Spades";
        }
        if(GameManager.isRevolution)
        {
            return value2 > value1;
        }
        return value1 > value2;
    }

    public bool sameValue(Card card, int value2)
    {
        int value1 = card.getValue();
        return value1 == value2 || value1 == 666;
    }

    public List<Card> play(int value) //value is the value of last card played
    {
        List<Card> playedCards = new List<Card>();
        foreach (Card card in this.hand)
        {
            if(compareValues(card, value))
            {
                playedCards.Add(card);
                hand.Remove(card);
                break;
            }
        }
        return playedCards;
    }
}