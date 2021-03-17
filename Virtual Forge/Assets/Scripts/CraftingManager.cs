using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public static int unlockIndex = 0;

    public bool isCrafting;
    private bool noOrder = true;
    private bool inShop;
    public Order order;

    public float craftTime = 60;
    private float seconds;

    public Text timer;
    public GameObject button;
    private Sprite ticket;
    public Image ticketDisplay;
    public GameObject orderCanvas;
    public GameObject playerCanvas;

    public Sprite[] sprites;
    private float bounce = 0.1f;
    private float bounceOffset = 0;

    public int uiState;

    public Transform player;


    void Start()
    {
        isCrafting = false;
        inShop = false;
    }

    
    void Update()
    {
        /*
        bounceOffset += bounce;
        if (Mathf.Abs(bounceOffset) >= 3)
        {
            bounce = -bounce;
            bounceOffset = 3;
        }
        print(bounceOffset);

        orderCanvas.transform.position += new Vector3(0, bounce, 0);
        */

        if (inShop)
        {
            orderCanvas.transform.rotation = player.rotation;

            if (noOrder)
            {
                button.SetActive(true);
                ticketDisplay.gameObject.SetActive(false);
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NewOrder();
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isCrafting = true;
                }
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


        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //0 = none
            //1 = timer and ticket
            //2 = full (timer and ticket, labels on interactables, dimensions of model)

            uiState++;
            if (uiState == 3)
                uiState = 0;

            if (uiState == 0)
            {
                playerCanvas.SetActive(false);
            }
            else
                playerCanvas.SetActive(true);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inShop = true;
            orderCanvas.SetActive(true);
            print("In Shop");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inShop = false;
            print("Out of shop");
            orderCanvas.SetActive(false);
        }
    }


    private void Timer()
    {
        seconds += Time.deltaTime;

        int sec = (int)seconds;
        timer.text = "Time: " + sec.ToString();
        
    }
    public enum Order
    {
        c_sword,
        i_sword,
        s_sword,
        t_sword,
    }
    
    public void NewOrder()
    {
        int material = Random.Range(0, unlockIndex);
        //0 = copper, 1 = iron, 2 = steel, 3 = titanium?
        //int type = Random.Range(0, 0);
        //0 = sword, 1 = dagger, 2 = axe?

        order = (Order) material;
        print(order.ToString());


        switch (order)
        {
            case Order.c_sword:
                ticket = sprites[material];
                //all the specs for the grading system go here?
                break;
            case Order.i_sword:
                ticket = sprites[material];
                break;
            case Order.s_sword:
                ticket = sprites[material];
                break;
            case Order.t_sword:
                ticket = sprites[material];
                break;
            default:
                ticket = null;
                break;
        }

        ticketDisplay.sprite = ticket;
        ticketDisplay.gameObject.SetActive(true);
        button.SetActive(false);
        noOrder = false;
    }
}
