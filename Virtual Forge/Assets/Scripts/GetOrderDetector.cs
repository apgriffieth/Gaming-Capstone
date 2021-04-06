using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOrderDetector : MonoBehaviour
{
    public GameObject interact;
    public bool canOrder = false;
    public CraftingManager manager;

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
            interact.SetActive(true);
            canOrder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interact.SetActive(false);
        }
    }
}
