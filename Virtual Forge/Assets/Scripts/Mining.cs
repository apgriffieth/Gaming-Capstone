using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private GameObject collidingObject;
    private int numHits = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (collidingObject || !other.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = other.gameObject;
        if (collidingObject.tag == "Pickaxe")
        {
            numHits++;
        }

        if (numHits == 2)
        {
            numHits = 0;
            //GetCopper();
        }
    }

    /*private void GetCopper();
    {
        
    }*/
}
