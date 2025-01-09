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
            Debug.Log("Stats reset (this is a lie right now there are no stats to reset)");
            _clickCounter = 2;
        }
    }
}
