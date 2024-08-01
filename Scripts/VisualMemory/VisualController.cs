using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class VisualController : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject menuButton;
    private List<int> sequence = new List<int>();
    private int currentStep = 0;
    private bool clicked = false;
    private bool gameOver = false;
    private int round = 1;

    void Start()
    {
        InitializeButtonNumbers();
        StartCoroutine(Game());
    }

    private void InitializeButtonNumbers()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            ClickController clickController = buttons[i].GetComponent<ClickController>();
            if (clickController != null)
            {
                clickController.buttonNum = i + 1;
            }
        }
    }

    IEnumerator Game()
    {
        while (!gameOver)
        {
            yield return ShowSequence();
            yield return new WaitUntil(() => gameOver || currentStep >= sequence.Count);

            if (!gameOver)
            {
                round++;
                currentStep = 0;
                clicked = false;
            }
        }

        menuButton.SetActive(true);
        againButton.SetActive(true);
        gameOverText.SetActive(true);
    }

    private IEnumerator ShowSequence()
    {
        sequence.Clear();
        HashSet<int> usedIndices = new HashSet<int>();

        for (int i = 0; i < round + 3; i++)
        {
            int randomIndex;

            // Ensure the randomIndex is unique
            do
            {
                randomIndex = UnityEngine.Random.Range(0, buttons.Length);
            } while (usedIndices.Contains(randomIndex));

            usedIndices.Add(randomIndex);
            sequence.Add(randomIndex + 1);

            TextMeshProUGUI buttonText = buttons[randomIndex].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = $"{i + 1}";
            buttons[randomIndex].SetActive(true);
        }

        while (!clicked)
        {
            yield return null;
        }

        // Clear the text on all buttons
        foreach (GameObject button in buttons)
        {
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = "";
        }
    }

    public void HandleButtonClick(int buttonNum)
    {
        if (gameOver)
            return;
        clicked = true;

        if (buttonNum == sequence[currentStep])
        {
            Debug.Log("Correct button clicked!");
            buttons[buttonNum - 1].SetActive(false);
            currentStep++;
        }
        else
        {
            Debug.Log($"Game Over (Clicked: {buttonNum}, Expected: {sequence[currentStep]})");
            gameOver = true;
        }
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
