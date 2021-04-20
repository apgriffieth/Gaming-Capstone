using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting : MonoBehaviour
{
    public Transform Spawnpoint;
    public Rigidbody[] Sword;
    private float timer = 0f;
    private GameObject collidingObject;

    void Update()
    {
	    if (collidingObject != null && collidingObject.CompareTag("Melt")) 
	    {
	        timer += Time.deltaTime;
			if (timer > 5f)
			{
				int matID = collidingObject.GetComponent<MaterialTracker>().matID;
				SpawnSword(collidingObject, matID);
			}
	    }
	}
    private void OnTriggerEnter(Collider other)
    {
	    collidingObject = other.gameObject;
    }

    private void SpawnSword(GameObject other, int mat)
    {
	    Rigidbody RigidPrefab = Instantiate(Sword[mat], Spawnpoint.position, Spawnpoint.rotation);
		RigidPrefab.name = Sword[mat].name;

		collidingObject = null;
	    other.SetActive(false);
	    timer = 0f;
    }
}
