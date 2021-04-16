using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Swing : MonoBehaviour
{
    Transform player;
    PhotonView PV;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
	player = this.gameObject.transform.root;
	PV = player.GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
	if (!PV.IsMine)
	{
	    return;
	}

        if (Input.GetButtonDown("Fire1"))
            anim.SetBool("Swinging", true);
        else if (Input.GetButtonUp("Fire1"))
            anim.SetBool("Swinging", false);
    }
}
