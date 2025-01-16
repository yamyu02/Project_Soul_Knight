using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaritySort : MonoBehaviour
{
    public Node _Start;
    public Node _End;
    public RaritySort()
    {

    }
    RaritySort ItemList = new RaritySort();
    RaritySort CommonList = new RaritySort();
    RaritySort UncommonList = new RaritySort();
    RaritySort RareList = new RaritySort();
    RaritySort EpicList = new RaritySort();
    RaritySort LegendaryList = new RaritySort();

    public void AddByRarity(string name, int amount, string rarity)
    {
        Node Temp = new Node(name,amount,rarity);

        if (rarity == "Common")
        {
            CommonList.Add(Temp, CommonList);
        }

        if (rarity == "Uncommon")
        {
            UncommonList.Add(Temp, UncommonList);
        }

        if (rarity == "Rare")
        {
            RareList.Add(Temp, RareList);
        }

        if (rarity == "Epic")
        {
            EpicList.Add(Temp, EpicList);
        }

        if (rarity == "Legendary")
        {
            LegendaryList.Add(Temp, LegendaryList);
        }
    }

    public void Add(Node node, RaritySort list)
    {
        if (list._Start == null)
        {
            list._Start = node;
            list._End = list._Start;
        }
        else
        {
            list._End = node;
        }

        list._End = list._End.Next;
    }
    void Update()
    {
        
    }
}
