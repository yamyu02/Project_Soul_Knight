using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                Debug.Log("game paused");
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                Debug.Log("game unpaused");
            }
        }
    }
}
