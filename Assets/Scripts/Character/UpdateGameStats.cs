using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateGameStats : MonoBehaviour
{
    public Character character;

    public TMP_Text HealthText;
    public TMP_Text ArmorText;
    public TMP_Text ManaText;
    public TMP_Text CoinText;
    public TMP_Text MaxHpText;
    public TMP_Text MaxArmorText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = character.GetHealth().ToString();
        ArmorText.text = character.GetArmor().ToString();
        ManaText.text = character.GetMana().ToString();
        CoinText.text = character.GetCoin().ToString();
        MaxArmorText.text = character.GetMaxArmor().ToString();
        MaxHpText.text = character.GetMaxHealth().ToString();


    }
}
