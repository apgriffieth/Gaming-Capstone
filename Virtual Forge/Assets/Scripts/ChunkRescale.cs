using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChunkRescale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
	{
	    OnMouseDown();
	}
    }

    private void OnMouseDown()
    {
	Vector3 scale = new Vector3(0.01f, -0.01f, 0.05f);
	foreach (Transform child in transform)
	{
	    if (child.localScale.y > Math.Abs(scale.y)) 
	    {
		child.localScale += scale;
	        child.position += new Vector3(0f, scale.y * 0.5f, 0);
	    }
	}
    }
}
