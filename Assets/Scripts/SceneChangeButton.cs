using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeButton : MonoBehaviour
{
    public Button button;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        // this code is from the unity docs
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // Debug.Log("button clicked");
        ChangeScene();
    }

    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
