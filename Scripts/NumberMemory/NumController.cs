using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NumController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject numberText;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject menuButton;
    bool hitEnter = false;
    bool gameOver = false;
    int level = 0;
    int playerInput;
    int randomNum;

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
            level++;
            levelText.text = $"Level: {level}";
            inputField.SetActive(false);
            numberText.SetActive(true);
            randomNum = UnityEngine.Random.Range(0, (int)Math.Pow(10, level));
            numText.text = randomNum.ToString();
            yield return new WaitForSeconds(5);
            numberText.SetActive(false);
            inputField.SetActive(true);
            while (!hitEnter)
            {
                yield return null;
            }
            hitEnter = false;
            if (playerInput != randomNum)
            {
                gameOver = true;
            }
        }
        inputField.SetActive(false);
        numberText.SetActive(false);
        menuButton.SetActive(true);
        againButton.SetActive(true);
        gameOverText.text = "Game Over";
    }

    public void InputConverter(string input)
    {
        playerInput = Convert.ToInt32(input);
        hitEnter = true;
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
