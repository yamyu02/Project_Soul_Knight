using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int Amount;
    public string Name;
    public string Rarity;
    public Node Next; 
    public Node(string name, int amount, string rarity)
    {
        this.Name = name;
        this.Amount = amount;
        this.Rarity = rarity;
    }
    // sort item by rarity first, and alphabet order. sort them into different list of rarity from the main list. 
}
