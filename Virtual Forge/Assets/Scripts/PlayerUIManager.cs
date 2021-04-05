using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public int playerIndex;

    public bool isCrafting;
    public int craftTime;
    private float seconds;
    public float secondsLeft;

    public Text timer;
    private Sprite itemImage;
    public Image ticketDisplay;
    public Text orderName, orderThickness, orderWidth, orderValue;

    public GameObject playerCanvas;
    public GameObject detailCanvas;
    private enum UIState { none, overlay, all, reset };
    private UIState uiState;

    private List<GameObject> labels;


    void Start()
    {
        isCrafting = false;

        string tag = "UI Label " + playerIndex.ToString();
        labels = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));

        uiState = UIState.none;

        playerCanvas.SetActive(false);
        foreach (GameObject canvas in labels)
            canvas.SetActive(false);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            
            uiState++;
            if (uiState == UIState.reset)
                uiState = UIState.none;
            

            switch(uiState)
            {
                case UIState.none:
                    playerCanvas.SetActive(false);
                    detailCanvas.SetActive(false);
                    foreach (GameObject canvas in labels)
                        canvas.SetActive(false);
                    break;
                case UIState.overlay:
                    playerCanvas.SetActive(true);
                    detailCanvas.SetActive(false);
                    foreach (GameObject canvas in labels)
                        canvas.SetActive(false);
                    break;
                case UIState.all:
                    playerCanvas.SetActive(true);
                    detailCanvas.SetActive(true);
                    foreach (GameObject canvas in labels)
                        canvas.SetActive(true);
                    break;
            }
        }

        if (isCrafting)
        {
            Timer();

        }
        else
        {
            timer.text = "";
        }

    }

    private void Timer()
    {
        seconds += Time.deltaTime;

        secondsLeft = craftTime - (int)seconds;
        timer.text = "Time Remaining: " + secondsLeft.ToString();

    }

    public void UpdateOrder(string itemName, float thickness, float width, float value, int craftingTime)
    {
        isCrafting = true;

        orderName.text = itemName;
        orderThickness.text = "Thickness: " + thickness.ToString();
        orderWidth.text = "Width: " + width.ToString();
        orderValue.text = "Value: " + value.ToString();

        craftTime = craftingTime;
        seconds = 0;

        if (uiState == UIState.none)
        {
            playerCanvas.SetActive(true);
            uiState = UIState.overlay;
        }
    }
}
