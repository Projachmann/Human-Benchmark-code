using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SequenceController : MonoBehaviour
{
    public GameObject[] buttons = new GameObject[9];
    [SerializeField]TextMeshProUGUI levelCounter;
    int level = 1;
    int randomNum;
    bool firstClick = false;
    private bool gameOver = false;
    private UnityEngine.UI.Image image;
    List<int> buttonsToPress = new List<int>();
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject menuButton;

    void Start()
    {
        StartCoroutine(Game());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Game()
    {
        while (!gameOver)
        {
            levelCounter.text = $"Level: {level}";
            randomNum = UnityEngine.Random.Range(1, 10);
            buttonsToPress.Add(randomNum);
            foreach (int button in buttonsToPress)
            {
                image = buttons[button - 1].GetComponent<UnityEngine.UI.Image>();
                image.color = Color.red;
                yield return new WaitForSeconds(1);
                image.color = Color.white;
                yield return new WaitForSeconds((float)0.25);
            }
            foreach (int button in buttonsToPress)
            {
                ButtonScript script = null;
                while (!firstClick)
                {
                    yield return null;
                }
                firstClick = false;
                foreach (GameObject buttonsScripts in buttons)
                {
                    script = buttonsScripts.GetComponent<ButtonScript>();
                    if (script.wasClicked)
                    {
                        break;
                    }
                }
                while (!script.wasClicked)
                {
                    yield return null;
                }
                script.wasClicked = false;
                if (script.buttonNum != button)
                {
                    gameOver = true;
                    break;
                }
            }
            yield return new WaitForSeconds((float)0.5);
            level++;
        }
        gameOverText.SetActive(true);
        menuButton.SetActive(true);
        againButton.SetActive(true);
    }

    void StopGame()
    {
        Console.WriteLine("Game Over!");
    }

    public void FirstClick()
    {
        firstClick = true;
    }

    public void Again()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
