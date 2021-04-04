using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolControl : MonoBehaviour
{
    private GameObject playerItems;
    private Transform hammer;
    private Transform tongs;
    private Transform pickaxe;
    
    // Start is called before the first frame update
    void Start()
    {
        playerItems = GameObject.Find("itemContainer");
	Transform playerItemsTransform = playerItems.transform;
	hammer = playerItemsTransform.Find("smithing_hammer");
	tongs = playerItemsTransform.Find("tongs");
        pickaxe = playerItemsTransform.Find("shovel");

	hammer.gameObject.SetActive(true);
	tongs.gameObject.SetActive(false);
        pickaxe.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
	{
	    hammer.gameObject.SetActive(true);
	    tongs.gameObject.SetActive(false);
            pickaxe.gameObject.SetActive(false);
        }

	else if (Input.GetKeyDown(KeyCode.Alpha2))
	{
	    hammer.gameObject.SetActive(false);
	    tongs.gameObject.SetActive(true);
            pickaxe.gameObject.SetActive(false);
        }

    else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hammer.gameObject.SetActive(false);
            tongs.gameObject.SetActive(false);
            pickaxe.gameObject.SetActive(true);
        }
    }
}
