using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformableMesh : MonoBehaviour
{
    private Mesh mesh;
    private Collider meshCollider;

    private Vector3[] vertices;
    private int[] triangles;

    private float strength = 0.2f;
    private float volume;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshCollider = GetComponent<MeshCollider>();
        

        vertices = mesh.vertices;
        triangles = mesh.triangles;
    }

    public void Flatten(Vector3 contactPoint, Vector3 normal, float radius)
    {
        var worldPos4 = transform.worldToLocalMatrix * contactPoint;
        var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);

        

        for (int i = 0; i < vertices.Length; ++i)
        {
            var distance = (worldPos - (vertices[i])).magnitude;
            var direction = vertices[i] - worldPos;
            //print(distance);
            //print("Direction " + direction);

            if (distance < radius)
            {
                print("Old vertex: " + vertices[i]);
                var newVert = vertices[i] + (direction * strength * Time.deltaTime);
                vertices[i] = newVert;
                print("New vertex: " + vertices[i]);
            }
        }

    }


    public void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        //InvokeRepeating("UpdateCollider", 0.5f, 0.5f);

        print("Mesh Updated");
    }
    /*
    void UpdateCollider()
    {
        
    }
    */
}
