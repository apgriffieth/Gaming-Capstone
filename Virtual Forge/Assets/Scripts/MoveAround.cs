using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    private Vector2 rotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    
    void Update()
    {
        transform.position += transform.right * Input.GetAxis("Horizontal") * 5 * Time.deltaTime;
        transform.position += transform.forward * Input.GetAxis("Vertical") * 5 * Time.deltaTime;


        rotation.y += Input.GetAxis("Mouse X");
        Mathf.Clamp(rotation.y, -6, 6);
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * 10;
    }
}
