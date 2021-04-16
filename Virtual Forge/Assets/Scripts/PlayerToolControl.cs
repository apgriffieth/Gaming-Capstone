using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerToolControl : MonoBehaviour
{
    private GameObject playerItems;
    private Transform hammer;
    private Transform tongs;
    private Transform pickaxe;
    public Texture2D cursorPic;
    private Transform player;
    private PhotonView PV;

    void Awake()
    {
	PV = GetComponent<PhotonView>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
	player = this.gameObject.transform;
	//Transform FPSCamera = player.Find("FPSCamera");
        playerItems = player.Find("itemContainer").gameObject;
	Transform playerItemsTransform = playerItems.transform;
	hammer = playerItemsTransform.Find("smithing_hammer");
	tongs = playerItemsTransform.Find("tongs");
        pickaxe = playerItemsTransform.Find("pickax");

	hammer.gameObject.SetActive(true);
	tongs.gameObject.SetActive(false);
        pickaxe.gameObject.SetActive(false);

        Cursor.visible = true;
        Cursor.SetCursor(cursorPic, Vector2.zero, CursorMode.ForceSoftware);

    }

    // Update is called once per frame
    void Update()
    {
	if (!PV.IsMine) 
	{
	    return;
	}

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
