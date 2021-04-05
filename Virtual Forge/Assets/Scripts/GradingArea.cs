using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradingArea : MonoBehaviour
{

    public Text prompt;
    public GameObject canvas;
    public GameObject manager;

    private bool itemIn;
    private GameObject item;
    private int matID;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemIn && !canvas.activeInHierarchy)
            canvas.SetActive(true);

        if (itemIn && Input.GetKeyDown(KeyCode.Space))
        {
            manager.GetComponent<CraftingManager>().GradeItem(item, matID);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Forgable")) 
        {
            item = other.gameObject;
            prompt.text = "Grade " + item.name + "?\nPress Space to confirm" ;

            itemIn = true;

            matID = 0;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Forgable"))
        {
            item = null;
            matID = 0;

            prompt.text = gameObject.name;

            itemIn = false;
        }


    }
}
