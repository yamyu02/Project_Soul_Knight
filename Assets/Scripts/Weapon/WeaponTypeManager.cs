using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponTypeManager : MonoBehaviour
{
    public string CurrentType = "Mary";
    public string CurrentWeapon = "Daggers";
    public GameObject Mary;
    public GameObject Jack;
    public GameObject Staff;
    public Character character;
    public int Price;

    public string[] Weapons = {"Daggers",}; 
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            this.CurrentWeapon = Weapons[0]; 
        }

        if (Input.GetKeyDown("2"))
        {
            this.CurrentWeapon = Weapons[1];
        }

        MaryandJack();
        StaffCheck();
    }

    private void MaryandJack()
    {
        if (CurrentWeapon == "Daggers")
        {
            Mary.SetActive(true);
            Jack.SetActive(true);
        }
        else
        {
            Mary.SetActive(false);
            Jack.SetActive(false);
        }
    }

    private void StaffCheck()
    {
        if (CurrentWeapon == "Staff")
        {
            Staff.SetActive(true);
        }
        else
        {
            Staff.SetActive(false);
        }
    }

    public void WeaponSlot2(string weapon)
    {
        if (character.GetCoin() >= Price)
        {
            Weapons[1] = weapon;
            character.SetCoin(character.GetCoin() - Price);
        }
        
    }

    public void ItemPrice(int price)
    {
        this.Price = price;
    }

    public void ItemShop2()
    {
        if (character.GetCoin() >= Price)
        {
            character.SetMana(character.GetMana() + 50);
            if (character.GetMana() > 200)
            {
                character.SetMana(200);
            }
            character.SetCoin(character.GetCoin() - Price);
        }
    }

    public void ItemShop1()
    {
        if (character.GetCoin() >= Price)
        {
            character.SetMaxHealth(character.GetMaxHealth() + 2);
            character.SetHealth(character.GetMaxHealth());
            character.SetCoin(character.GetCoin() - Price);
        }
    }
}
