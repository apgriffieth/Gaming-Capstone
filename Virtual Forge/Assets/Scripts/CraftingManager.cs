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

    public int craftTime;
    private float seconds;
    private float value;

    public Text timer;
    public GameObject button;
    private Sprite ticket;
    public Image ticketDisplay;
    public GameObject orderCanvas;
    public GameObject playerCanvas;

    public Sprite[] sprites;
    private float bounce = 0.001f;
    private float bounceOffset = 0;

    public int uiState;

    public Transform player;
    private List<GameObject> labels;

    //grading specs
    private float thickness;

    void Start()
    {
        isCrafting = false;
        inShop = false;
        

        labels = new List<GameObject>(FindObjectsOfType<GameObject>(true));

        foreach (GameObject gameObject in labels)
        { 
            if (!gameObject.CompareTag("UI Label"))
            {
                labels.Remove(gameObject);
            }
        }

        
    }

    
    void Update()
    {

        Bounce();
        

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

        if (!inShop && noOrder)
        {
            orderCanvas.transform.rotation = player.rotation;


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
                foreach(GameObject canvas in labels)
                    canvas.SetActive(false);
            }
            else
                playerCanvas.SetActive(true);

            
            if (uiState == 2)
            {
                foreach (GameObject canvas in labels)
                    canvas.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inShop = true;
            //print("In Shop");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inShop = false;
            //print("Out of shop");
        }
    }

    private void Bounce()
    {
        bounceOffset += bounce;
        if (Mathf.Abs(bounceOffset) >= 0.3f)
        {
            bounce = -bounce;
            bounceOffset = 0;
        }
        //print(bounceOffset);

        orderCanvas.transform.position += new Vector3(0, bounce, 0);
    }

    private void Timer()
    {
        seconds += Time.deltaTime;

        int sec = craftTime - (int)seconds;
        timer.text = "Time Remaining: " + sec.ToString();
        
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
                craftTime = 80;
                thickness = 0.1f;
                value = 10;
                break;
            case Order.i_sword:
                ticket = sprites[material];
                craftTime = 100;
                thickness = 0.15f;
                value = 30;
                break;
            case Order.s_sword:
                ticket = sprites[material];
                craftTime = 120;
                thickness = 0.15f;
                value = 60;
                break;
            case Order.t_sword:
                ticket = sprites[material];
                craftTime = 150;
                thickness = 0.175f;
                value = 100;
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

    public float GradeItem(GameObject item, int matID)
    {
        isCrafting = false;

        if (matID != (int)order)
        {
            return 0;
        }

        float margin = item.transform.localScale.y - thickness;
        margin = 1 / Mathf.Abs(margin);
        print(margin);

        float grade = value * margin + seconds;

        return grade;
    }
}
