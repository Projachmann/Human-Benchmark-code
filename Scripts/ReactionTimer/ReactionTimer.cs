using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class ReactionTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clickToStart;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject menuButton;
    bool clicked = false;
    bool canBeClicked = true;
    private Renderer renderer;
    double startTime;
    double endTime;
    double averageTime;
    // Start is called before the first frame update
    void Start()
    {
        clickToStart.text = "Click to start";
        renderer = gameObject.GetComponent<Renderer>();
        StartCoroutine(Waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Waiter()
    {
        for (int i = 0; i < 5; i++)
        {
            while (!clicked)
            {
                yield return null;
            }
            clicked = false;
            canBeClicked = false;
            clickToStart.text = "";
            renderer.material.color = Color.green;
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 5));
            canBeClicked = true;
            startTime = Time.time;
            renderer.material.color = Color.red;
            while (!clicked)
            {
                yield return null;
            }
            clicked = false;
            endTime = Time.time;
            Debug.Log(endTime - startTime);
            averageTime += endTime - startTime;
            clickToStart.text = $"{Math.Round(endTime - startTime, 3)}";
            yield return new WaitForSeconds(2);
            clickToStart.text = "Click to start";
            renderer.material.color = Color.white;
        }
        averageTime = averageTime / 5;
        clickToStart.text = $"Your average time was {Math.Round(averageTime, 3)}";
        menuButton.SetActive(true);
        againButton.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (canBeClicked)
        {
            clicked = true;
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
