using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class RaritySort : MonoBehaviour
{
    public Node[] items = new Node[1];
    public int pointer = 0;
    public string[] RarityOrder = {"Common", "Uncommon", "Rare", "Epic", "Legendary"};

    public void Add(Node node)
    {
        if (pointer > items.Length-1)
        {
            Node[] newList = new Node[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                newList[i] = items[i];
            }

            items = newList;
        }
        items[pointer] = node;
        pointer++;
    }
    public void SortRarity()
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < items.Length; j++)
            {
                if (RaritySearch(items[min].Rarity) > RaritySearch(items[j].Rarity))
                {
                    min = j;
                }
            }
            Node n = items[i];
            items[i] = items[min];
            items[min] = n;
        }
    }
    public int RaritySearch(string itemRarity)
    {
        for (int i = 0; i < RarityOrder.Length; i++)
        {
            if (RarityOrder[i] == itemRarity)
            {
                return i;
            }
        }
        return -1;
    }

    private void Start()
    {
        Add(new Node("hp", 1, "Rare"));
        Add(new Node("Atk", 1, "Epic"));
        Add(new Node("stone", 1, "Common"));
        Add(new Node("stick", 1, "Common"));
        SortRarity();

        foreach (Node node in items)
        {
            Debug.Log(node.Name);
        }
        

    }
    void Update()
    {
        
    }
}
