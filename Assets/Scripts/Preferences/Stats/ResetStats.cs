using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetStats : MonoBehaviour
{
    public Button button;
    private int _clickCounter = 2;
    // Start is called before the first frame update
    void Start()
    {
        // this code is from the unity docs
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (_clickCounter > 0)
        {
            _clickCounter -= 1;
        }
        else
        {
            Debug.Log("Stats reset");
            PlayerPrefs.SetInt("Kills", 0);
            PlayerPrefs.SetInt("Damage", 0);
            PlayerPrefs.SetInt("Wins", 0);
            PlayerPrefs.SetInt("Losses", 0);
            _clickCounter = 2;
        }
    }
}
