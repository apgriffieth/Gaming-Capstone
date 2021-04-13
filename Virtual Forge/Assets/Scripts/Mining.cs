using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private int hit = 0;
    public int maxHits;
    public Transform Spawnpoint;
    public Rigidbody Ore;
    public GameObject hitEffect;
    public float timer = 0;
    public bool effect = false;
    private GameObject effectObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(effectObj);
            effect = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody RigidPrefab;
        if (other.tag == "Melee")
        {
            if (hit >= maxHits)
            {
                RigidPrefab = Instantiate(Ore, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
                hit = 0;
            }
            if (effect == false)
            {
                effectObj = Instantiate(hitEffect, other.transform);
                timer = 1;
                effect = true;
            }
            
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Melee")
        {
            hit++;
        }

        Destroy(effectObj);
    }
}
