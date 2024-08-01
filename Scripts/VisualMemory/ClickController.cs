using UnityEngine;

public class ClickController : MonoBehaviour
{
    public int buttonNum;
    private VisualController visualController;

    void Start()
    {
        visualController = FindObjectOfType<VisualController>();
    }

    public void OnClick()
    {
        visualController.HandleButtonClick(buttonNum);
    }
}
