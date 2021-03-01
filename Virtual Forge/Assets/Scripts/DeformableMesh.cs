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
        var worldPos4 = this.transform.worldToLocalMatrix * contactPoint;
        var worldPos = new Vector3(worldPos4.x, worldPos4.y, worldPos4.z);

        for (int i = 0; i < vertices.Length; ++i)
        {
            var distance = (worldPos - (vertices[i] + Vector3.down) * 10f).magnitude;
            
            if (distance < radius)
            {
                //print("Old vertex: " + vertices[i]);
                var newVert = vertices[i] + Vector3.down * strength;
                vertices[i] = newVert;
                //print("New vertex: " + vertices[i]);
            }
        }

    }


    public void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        //mesh.RecalculateBounds();

        //meshCollider.

        print("Mesh Updated");
    }
}
