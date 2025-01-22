using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priestess : Character
{
    // Start is called before the first frame update
    void Start()
    {
        SetMana(200);
        SetHealth(4);
        SetMaxHealth(4);
        SetArmor(6);
        SetMaxArmor(6);
        SetiFrame(false);

        Debug.Log($"Health is {GetHealth()}");
        Debug.Log($"Armor is {GetArmor()}");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetHealth() > 0)
        {
            Call();
        }
    }
}
