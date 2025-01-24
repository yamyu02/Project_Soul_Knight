using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SfxController : MonoBehaviour
{
    public AudioSource clickAudio;
    public AudioSource shootAudio;

    private Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentScene.name != "SampleScene")
            {
                clickAudio.Play();
            }
            else if (currentScene.name == "SampleScene")
            {
                shootAudio.Play();
            }
        }
    }
}
