using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting : MonoBehaviour
{
    public Transform Spawnpoint;
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

        if (other.tag == "Melt")
        {
            currentTime = startingTime;
            RigidPrefab = Instantiate(Sword, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;


            other.gameObject.SetActive(false);
        }

    }
}
