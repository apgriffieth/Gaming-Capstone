using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public static int unlockIndex = 0;

    public bool isCrafting;
    public Order order;

    public int craftTime;
    private float value;

    public Text timer;
    private Sprite itemSprite;
    public Image ticketDisplay;
    public GameObject orderCanvas;
    public GameObject playerCanvas;

    public Sprite[] sprites;
    private float bounce = 0.001f;
    private float bounceOffset = 0;

    public Transform player;
    public GameObject playerManager1;
    public GameObject playerManager2;

    //grading specs
    private float thickness;
    private float width;
    public GameObject testItem;

    void Start()
    {
        isCrafting = false;


    }


    void Update()
    {

        Bounce();

        //FOR TESTING
        /*
        if (Input.GetKeyDown(KeyCode.N))
        {
            NewOrder();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            float grade = GradeItem(testItem, 0);
            print("Grade: " + grade.ToString());
        }
        */



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

        order = (Order)material;
        print(order.ToString());

        string name = "";

        switch (order)
        {
            case Order.c_sword:
                itemSprite = sprites[material];
                craftTime = 80;
                thickness = Random.Range(0.2f, 0.25f);
                thickness = Mathf.Round(thickness * 100f) / 100f;
                width = Random.Range(0.8f, 1.2f);
                width = Mathf.Round(width * 100f) / 100f;
                value = 10;
                name = "Copper Sword";
                break;
            case Order.i_sword:
                //itemSprite = sprites[material];
                craftTime = 100;
                thickness = 0.15f;
                width = Random.Range(0.5f, 1);
                value = 30;
                name = "Iron Sword";
                break;
            case Order.s_sword:
                //itemSprite = sprites[material];
                craftTime = 120;
                thickness = 0.15f;
                width = Random.Range(0.5f, 1);
                value = 60;
                name = "Steel Sword";
                break;
            case Order.t_sword:
                //itemSprite = sprites[material];
                craftTime = 150;
                thickness = 0.175f;
                width = Random.Range(0.5f, 1);
                value = 100;
                name = "Titanium Sword";
                break;
            default:
                break;
        }

        GetComponentInChildren<PlayerUIManager>().UpdateOrder(name, thickness, width, value, craftTime, itemSprite);
        isCrafting = true;
        
        //noOrder = false;
    }

    public float GradeItem(GameObject item, int matID)
    {
        isCrafting = false;

        float seconds = GetComponentInChildren<PlayerUIManager>().secondsLeft;
        GetComponentInChildren<PlayerUIManager>().isCrafting = false;

        if (matID != (int)order)
        {
            return 0;
        }

        float yMargin = item.transform.localScale.y - thickness;
        yMargin = 1 / Mathf.Abs(yMargin);
        print(yMargin);

        float xMargin = item.transform.localScale.x - width;
        xMargin = 1 / Mathf.Abs(xMargin);
        print(xMargin);

        float grade = 100 - (yMargin * xMargin);

        timer.text = "Grade: " + grade;

        print("Grade: " + grade.ToString());
        return grade;
    }
}
