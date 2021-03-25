using UnityEngine;

public class GrabWithTongs : MonoBehaviour
{
    private GameObject tongs;
    private GameObject objectInTongs;
    private Transform itemContainer;

    // Start is called before the first frame update
    void Start()
    {
        itemContainer = GameObject.Find("itemContainer").transform;
        Transform[] childrenTransforms = itemContainer.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in childrenTransforms)
        {
            if (t.name == "tongs")
            {
                tongs = t.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && tongs.activeSelf)
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 3f))
            {
                if (raycastHit.transform != null && raycastHit.transform.gameObject.tag == "Forgable")
                {
                    PickupObject(raycastHit.transform.gameObject);
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && tongs.activeSelf)
        {
            DropObject();
        }

    }

    private void PickupObject(GameObject clickedObject)
    {
        objectInTongs = clickedObject;
        objectInTongs.transform.SetParent(tongs.transform);
        objectInTongs.GetComponent<Rigidbody>().useGravity = false;
        Vector3 curpos = objectInTongs.transform.localPosition;
        objectInTongs.transform.localPosition = new Vector3(curpos.x, 0f, curpos.z);
        //objectInTongs.transform.position = tongs.transform.position;
        //objectInTongs.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    private void DropObject()
    {
        if (objectInTongs == null)
        {
            return;
        }

        objectInTongs.transform.SetParent(null);
        objectInTongs.GetComponent<Rigidbody>().useGravity = true;
        objectInTongs = null;
    }
}
