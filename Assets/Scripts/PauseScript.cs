using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public Character character;
    public UnityEngine.UI.Button ResumeButton;
    private bool _gameEnded = false; //this isn't encapsulation or anything it's so the game over screen works as intended

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        ResumeButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p") & _gameEnded == false)
        {
            if (Time.timeScale == 1) // if game is unpaused
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                Debug.Log("game paused");
            }
            else if (Time.timeScale == 0) // if game is paused
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
                Debug.Log("game unpaused");
            }
        }
        if (character.GetHealth() <= 0)
        {
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
            _gameEnded = true;
            character.SetHealth(-1); // code to prevent the code from looping
        }
    }
    
    void TaskOnClick()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Debug.Log("game unpaused");
    }
}
