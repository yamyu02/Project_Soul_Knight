using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateGameStats : MonoBehaviour
{
    public Rogue rogue;

    public TMP_Text HealthText;
    public TMP_Text ArmorText;
    public TMP_Text ManaText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = rogue.GetHealth().ToString();
        ArmorText.text = rogue.GetArmor().ToString();
        ManaText.text = rogue.GetMana().ToString();

    }
}
