using System;
using UnityEngine;

public class Forging : MonoBehaviour
{
    private float xScaler = 0f;
    private float zScaler = 0.005f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && raycastHit.transform.gameObject.tag == "Forgable")
                {
                    DescaleObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    private void DescaleObject(GameObject clickedObject)
    {
        float volume = clickedObject.transform.localScale.x * clickedObject.transform.localScale.y * 
            clickedObject.transform.localScale.z;
        float yScaler = volume / ((clickedObject.transform.localScale.x + xScaler) * 
            (clickedObject.transform.localScale.z + zScaler)) - clickedObject.transform.localScale.y;
        Vector3 scale = new Vector3(xScaler, yScaler, zScaler);

        if (clickedObject.transform.localScale.y > 0.015f)
        {
            clickedObject.transform.localScale += scale;
            clickedObject.transform.localPosition += new Vector3(0f, scale.y * 0.5f, 0f);
        }

    }
}
