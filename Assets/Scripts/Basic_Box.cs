using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Box : Box
{
    // Start is called before the first frame update
    void Start()
    {
        SetHpDrop(10);
        SetManaDrop(30);
        SetCoinDrop(30);
        SetNothingDrop(30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
