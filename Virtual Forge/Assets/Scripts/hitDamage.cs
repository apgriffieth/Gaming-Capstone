using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDamage : MonoBehaviour
{
    public Transform Spawnpoint;
    public Rigidbody Ore;
    public Rigidbody Sword;
    private float currentTime = 0f;
    public float startingTime = 10f;

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody RigidPrefab;
        if (other.tag == "Melee")
            RigidPrefab = Instantiate(Ore, Spawnpoint.position, Spawnpoint.rotation)as Rigidbody;

        if (other.tag == "Forgable")
        {
            RigidPrefab = Instantiate(Sword, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
            currentTime = startingTime;
        }

        //if (other.tag == "Forgable" && currentTime <= 0)
        //{
        //    RigidPrefab = Instantiate(Sword, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
        //}
    }
    
}
