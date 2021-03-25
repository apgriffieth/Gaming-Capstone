using UnityEngine;

public class Forging : MonoBehaviour
{
    private float xScaler = 0.05f;
    private float zScaler = 0.005f;
    public AudioSource audioSource;
    private GameObject hammer;
    private Transform itemContainer;

    void Start()
    {
        itemContainer = GameObject.Find("itemContainer").transform;
        Transform[] childrenTransforms = itemContainer.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in childrenTransforms)
        {
            if (t.name == "smithing_hammer")
            {
                hammer = t.gameObject;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hammer.activeSelf)
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 3f))
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

        if (clickedObject.transform.localScale.y > 0.1f)
        {
            audioSource.Play();
            clickedObject.transform.localScale += scale;
            clickedObject.transform.localPosition += new Vector3(0f, scale.y * 0.5f, 0f);
        }

    }
}
