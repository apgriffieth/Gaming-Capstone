using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsDeformer : MonoBehaviour
{
    public float collisionRadius = 1f;
    public DeformableMesh deformableMesh;

    //testing
    private Vector3 startPosition;

    void Start()
    {
        //testing
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            //print("Contact");
            deformableMesh.Flatten(contact.point, contact.normal, collisionRadius);
        }

        deformableMesh.UpdateMesh();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPosition;
            transform.rotation = new Quaternion(0,0,0,0);
        }
    }
}
