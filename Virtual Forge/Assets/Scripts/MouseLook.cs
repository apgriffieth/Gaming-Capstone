using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    private float mouseSensitivity = 1f;
    float verticalLookRotation;
    private Transform player;
    private PhotonView PV;

    void Awake()
    {
	PV = GetComponent<PhotonView>();
    }

    void Start()
    {
	player = this.gameObject.transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        if (!PV.IsMine)
	{
	    return;
	}
	Look();
    }

    void Look()
    {
	transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

	verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
	verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

	cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
   }
}
