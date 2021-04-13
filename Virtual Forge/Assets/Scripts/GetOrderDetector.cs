using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOrderDetector : MonoBehaviour
{
    public GameObject interact;
    public bool canOrder = false;
    public CraftingManager manager;
    public GameObject copper;
    public GameObject iron;
    public GameObject titanium;
    public GameObject capstonium;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOrder == true)
        {
            print("order");
            manager.NewOrder();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Shop Counter")
            {
                interact.SetActive(true);
                canOrder = true;
            }

            if (gameObject.tag == "cVein")
            {
                copper.SetActive(true);
            }
            if (gameObject.tag == "iVein")
            {
                iron.SetActive(true);
            }
            if (gameObject.tag == "tVein")
            {
                titanium.SetActive(true);
            }
            if (gameObject.tag == "caVein")
            {
                capstonium.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Shop Counter")
            {
                interact.SetActive(false);
                canOrder = true;
            }

            if (gameObject.tag == "cVein")
            {
                copper.SetActive(false);
            }
            if (gameObject.tag == "iVein")
            {
                iron.SetActive(false);
            }
            if (gameObject.tag == "tVein")
            {
                titanium.SetActive(false);
            }
            if (gameObject.tag == "caVein")
            {
                capstonium.SetActive(false);
            }
        }
    }
}
