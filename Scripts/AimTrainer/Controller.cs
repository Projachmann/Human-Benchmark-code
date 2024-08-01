using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Controller : MonoBehaviour
{
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject againButton;
    public GameObject target;
    public TextMeshProUGUI gameText;
    double averageTime = 0;
    bool started = false;
    public bool destroy = false;

    void Start()
    {
        StartCoroutine(Game());
    }

    void Update()
    {
        
    }

    IEnumerator Game()
    {
        float randomNumX;
        float randomNumY;
        double startTime;
        double endTime;
        while (!started)
        {
            yield return null;
        }
        gameText.text = null;
        for (int i = 0; i < 30; i++)
        {
            randomNumX = UnityEngine.Random.Range((float)- 3.0, (float)3.0);
            randomNumY = UnityEngine.Random.Range((float)-4.25, (float)4.35);
            startTime = Time.time;
            Instantiate(target, new Vector2(randomNumX, randomNumY), Quaternion.identity);
            while (!destroy)
            {
                yield return null;
            }
            endTime = Time.time;
            averageTime += endTime - startTime;
            destroy = false;
        }
        averageTime /= 30;
        gameText.text = $"Average time: {Math.Round(averageTime, 3)}";
        menuButton.SetActive(true);
        againButton.SetActive(true);
    }

    private void OnMouseDown()
    {
        started = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
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
