using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the resolution to an iPhone resolution, e.g., iPhone 11 resolution
        int width = 2048; // Width of iPhone 11
        int height = 2732; // Height of iPhone 11
        bool fullScreen = false; // Not full screen 2732 x 2048

        Screen.SetResolution(width, height, fullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AimTrainer()
    {
        SceneManager.LoadScene(1);
    }

    public void SequenceMemory()
    {
        SceneManager.LoadScene(2);
    }

    public void VisualMemory()
    {
        SceneManager.LoadScene(3);
    }

    public void NumberMemory()
    {
        SceneManager.LoadScene(4);
    }

    public void VerbalMemory()
    {
        SceneManager.LoadScene(5);
    }

    public void ReactionTimer()
    {
        SceneManager.LoadScene(6);
    }
}
