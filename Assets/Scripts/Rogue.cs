using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : Character
{
    
    public Rogue(int Health, int Armor) : base(Health, Armor)
    {
        
    }

    void Start()
    {
        SetHealth(6);
        SetArmor(4);
    }
    void Update()
    {
        Call();
    }
}
