using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private PhotonView PV;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    void Awake()
    {
	    PV = GetComponent<PhotonView>();
    }

    void Start()
    {
	    if (!PV.IsMine)
	    {
	        Destroy(GetComponentInChildren<Camera>().gameObject);
	    }
    }

    void Update()
    {
	    if (!PV.IsMine) 
	    {
	        return;
	    }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            print("jumped");
            
        }

        if (Input.GetKeyDown("p") && isGrounded)
        {
            print("sideways");

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}
