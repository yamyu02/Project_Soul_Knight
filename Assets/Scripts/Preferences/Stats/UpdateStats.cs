using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateStats : MonoBehaviour
{
    public TMP_Text KillsText;
    public TMP_Text DamageText;
    public TMP_Text WinsText;
    public TMP_Text LossesText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KillsText.text = PlayerPrefs.GetInt("Kills", 0).ToString();
        DamageText.text = PlayerPrefs.GetInt("Damage", 0).ToString();
        WinsText.text = PlayerPrefs.GetInt("Wins", 0).ToString();
        LossesText.text = PlayerPrefs.GetInt("Losses", 0).ToString();
    }
}
