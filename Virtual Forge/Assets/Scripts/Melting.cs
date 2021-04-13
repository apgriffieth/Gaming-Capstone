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
				int matID = collidingObject.GetComponentInChildren<MaterialID>().matID;
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
		if (mat == 0)
		{
			RigidPrefab.name = "Copper Sword";
		}
		else if (mat == 1)
		{
			RigidPrefab.name = "Iron Sword";
		}
		else if (mat == 2)
		{
			RigidPrefab.name = "Titanium Sword";
		}
		else if (mat == 3)
		{
			RigidPrefab.name = "Capstonium Sword";
		}

		collidingObject = null;
	    other.SetActive(false);
	    timer = 0f;
    }
}
