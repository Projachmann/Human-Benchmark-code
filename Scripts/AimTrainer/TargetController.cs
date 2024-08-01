using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private GameObject controller;
    private Controller controllerScript;

    void Start()
    {
        controller = GameObject.Find("Controller");
        controllerScript = controller.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        controllerScript.destroy = true;
        Destroy(gameObject);
    }
}
