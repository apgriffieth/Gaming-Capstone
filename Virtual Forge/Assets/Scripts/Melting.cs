using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting : MonoBehaviour
{
    public Transform Spawnpoint;
    public Rigidbody Sword;
    private float timer = 0f;
    private GameObject collidingObject;

    void Update()
    {
	if (collidingObject != null && collidingObject.tag == "Melt") 
	{
	    timer += Time.deltaTime;
	    if (timer > 5f)
	    {
		SpawnSword(collidingObject);
	    }
	}
    }
    private void OnTriggerEnter(Collider other)
    {
	collidingObject = other.gameObject;
    }

    private void SpawnSword(GameObject other)
    {
	Rigidbody RigidPrefab = Instantiate(Sword, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
	collidingObject = null;
	other.SetActive(false);
	timer = 0f;
    }
}
