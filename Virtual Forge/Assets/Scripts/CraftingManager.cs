using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    

    public bool isCrafting;
    private bool inShop;

    public float craftTime = 60;
    private float seconds;

    public Text timer;
    public Sprite ticket;
    public GameObject viewPrompt;
    
    void Start()
    {
        isCrafting = false;
        inShop = false;

    }

    
    void Update()
    {
        if (inShop && !isCrafting)
        {
            viewPrompt.SetActive(true);
        }
        else viewPrompt.SetActive(false);


        if (isCrafting)
        {
            Timer();
            
        }
        else
        {
            timer.text = "";
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inShop = true;
            print("In Shop");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inShop = false;
            print("Out of shop");
        }
    }


    private void Timer()
    {
        seconds += Time.deltaTime;

        int sec = (int)seconds;
        timer.text = "Time: " + sec.ToString();
        
    }

    public void NewOrder()
    {
        isCrafting = true;
    }
}
