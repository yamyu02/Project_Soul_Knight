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
    void Start()
    {
        RaritySort ItemList = new RaritySort();
        ItemList._Start = new Node("Hp Potion", 1, "Rare");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
