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
	    Rigidbody RigidPrefab = Instantiate(Sword[0], Spawnpoint.position, Spawnpoint.rotation);
		RigidPrefab.name = "Copper Sword";
	    collidingObject = null;
	    other.SetActive(false);
	    timer = 0f;
    }
}
