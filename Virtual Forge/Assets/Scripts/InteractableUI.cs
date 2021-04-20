using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour
{
    public int playerIndex;

    private Transform item;
    public Transform player;
    public Vector3 displacement;
    private bool haveCamera = true;

    public Text label;


    void Start()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();
	if (cameras.Length < 1)
	{
	    haveCamera = false;
	}

        if (cameras.Length < playerIndex)
        {
            gameObject.SetActive(false);
            //print("yeet");
        }
        else
        {
            GetComponent<Canvas>().worldCamera = cameras[playerIndex - 1];
            player = cameras[playerIndex - 1].transform;

            item = transform.parent.transform;
            label.text = transform.parent.gameObject.name;

            transform.SetParent(null, true);
            transform.localScale = new Vector3(0.001f, 0.001f, 1);
        }
                
    }

    
    void Update()
    {
	if (!haveCamera) 
	{
	    Camera[] cameras = FindObjectsOfType<Camera>();
	    GetComponent<Canvas>().worldCamera = cameras[playerIndex - 1];
            player = cameras[playerIndex - 1].transform;

            item = transform.parent.transform;
            label.text = transform.parent.gameObject.name;

            transform.SetParent(null, true);
            transform.localScale = new Vector3(0.001f, 0.001f, 1);
	    haveCamera = true;
	}

        transform.position = item.position + displacement;
        transform.rotation = player.rotation;
    }
}
