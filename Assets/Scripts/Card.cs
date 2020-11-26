using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int value;
    public string suit;
    public string cardid;
    public bool playable;
    public bool selected;

    public int sortingOrder;
    private SpriteRenderer sprite;
    public Card(int val, string su, string cid) // Constructor for a single card
    {
        this.value = val;
        this.suit = su;
        this.cardid = cid;
        this.playable = false;
        this.selected = false;
        this.sortingOrder = 0;
    }
    public int getValue() // Returns value of card
    {
        return value;
    }

    public string getSuit() // Returns suit of card
    {
        return suit;
    }
    public string getCardID()
    {
        return cardid;
    }

    public void play(int order)
    {
        this.sortingOrder = order;
        sprite.sortingOrder = sortingOrder;
    }
    public void setPlayable()
    {
        playable = !playable;
    }
    public void setSelected()
    {
        selected = !selected;
    }
    public bool getPlayable()
    {
        return playable;
    }
    public bool getSelected()
    {
        return selected; 
    }
}
