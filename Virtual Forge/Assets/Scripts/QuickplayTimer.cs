using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuickplayTimer : MonoBehaviour
{

    public GameObject textDisplay;
    public int secondsLeft = 59;
    public int minutesLeft = 5;
    public bool takingAway = false;
    public Text finalGold;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "Shop closes in: " + minutesLeft + ": " + secondsLeft;
        textDisplay.SetActive(true);
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

       

        
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft <= 0)
        {
            minutesLeft -= 1;
            secondsLeft = 59;
        }

        if (minutesLeft < 0)
        {
            finalGold.GetComponent<Text>().text = "Final Gold: " + gameObject.GetComponent<CraftingManager>().gold;
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(0);
        }


        textDisplay.GetComponent<Text>().text = "Shop closes in: " + minutesLeft + ": " + secondsLeft;
        takingAway = false;
    }

}
