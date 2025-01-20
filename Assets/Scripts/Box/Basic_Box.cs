using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Box : Box
{
    // Start is called before the first frame update
    void Start()
    {
        SetHpDrop(5);
        SetManaDrop(10);
        SetCoinDrop(10);
        SetNothingDrop(75);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
