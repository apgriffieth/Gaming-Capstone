using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public static int unlockIndex = 4;

    public bool isCrafting;
    public Order order;
    public int gold;
    public Text currentGold;

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
    private float length;
    public GameObject testItem;

    void Start()
    {
        isCrafting = false;
        currentGold.text = "Gold: 0";

    }


    void Update()
    {

        
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

    /* CALL THIS IN UPDATE IF YOU WANT A UI ELEMENT TO BOUNCE UP AND DOWN
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
    */

    public enum Order
    {
        c_sword,
        i_sword,
        t_sword,
        cap_sword,
    }

    public void NewOrder()
    {
        int material = Random.Range(0, unlockIndex);
        //0 = copper, 1 = iron, 2 = titanium, 3 = capstonium
        //int type = Random.Range(0, 0);

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
                length = Random.Range(1f, 1.5f);
                length = Mathf.Round(length * 100f) / 100f;
                value = 10;
                name = "Copper Sword";
                break;
            case Order.i_sword:
                itemSprite = sprites[material];
                craftTime = 100;
                thickness = 0.15f;
                length = Random.Range(1f, 1.5f);
                length = Mathf.Round(length * 100f) / 100f;
                value = 30;
                name = "Iron Sword";
                break;
            case Order.t_sword:
                itemSprite = sprites[material];
                craftTime = 120;
                thickness = 0.15f;
                length = Random.Range(1f, 1.5f);
                length = Mathf.Round(length * 100f) / 100f;
                value = 60;
                name = "Titanium Sword";
                break;
            case Order.cap_sword:
                itemSprite = sprites[material];
                craftTime = 150;
                thickness = 0.175f;
                length = Random.Range(1f, 1.5f);
                length = Mathf.Round(length * 100f) / 100f;
                value = 100;
                name = "Capstonium Sword";
                break;
            default:
                break;
        }

        GetComponentInChildren<PlayerUIManager>().UpdateOrder(name, thickness, length, value, craftTime, itemSprite);
        isCrafting = true;
    }

    public void GradeItem(GameObject item, int matID)
    {
        isCrafting = false;

        float seconds = GetComponentInChildren<PlayerUIManager>().secondsLeft;
        GetComponentInChildren<PlayerUIManager>().isCrafting = false;

        float yMargin = item.transform.localScale.y - thickness;
        yMargin = Mathf.Abs(yMargin) * 10;
        print(yMargin);

        float xMargin = item.transform.localScale.z - length;
        xMargin = Mathf.Abs(xMargin) * 10;
        print(xMargin);

        float grade = 100 - (yMargin * xMargin * 10);
        grade = Mathf.Round(grade * 100f) / 100f;
        string letter = "";
        int addGold = 0;



        if (matID != (int)order)
        {
            letter = "Wrong Item!";
            grade = 0;
            addGold = 0;
        }
        else if (grade < 60)
        {
            letter = "Fail";
            addGold = 0;
        }
        else if (grade >= 60 && grade < 70)
        {
            letter = "D";
            addGold = (int) (value * 0.75f);
        }
        else if (grade >= 70 && grade < 80)
        {
            letter = "C";
            addGold = (int)(value * 0.9f);
        }
        else if (grade >= 80 && grade < 90)
        {
            letter = "B";
            addGold = (int)(value * 1);
        }
        else if (grade >= 90 && grade < 100)
        {
            letter = "A";
            addGold = (int)(value * 1.5f);
        }
        else if (grade >= 100)
        {
            letter = "A+";
            addGold = (int)(value * 2);
        }

        gold += addGold;

        currentGold.text = "Gold: " + gold;

        timer.text = "Grade: " + grade + "%";

        print("Grade: " + grade.ToString());
    }
}
