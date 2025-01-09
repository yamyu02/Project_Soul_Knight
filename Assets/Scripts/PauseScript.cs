using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
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
        if (character.GetHealth() == 0)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
            Debug.Log("game over");
            character.SetHealth(character.GetHealth() - 1); // code to prevent the code from looping
        }
    }
}
