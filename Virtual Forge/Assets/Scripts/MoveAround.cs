using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0, 0, 3) * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
    }
}
