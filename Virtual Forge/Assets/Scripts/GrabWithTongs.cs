using UnityEngine;
using Photon.Pun;

public class GrabWithTongs : MonoBehaviour
{
    private GameObject tongs;
    private GameObject objectInTongs = null;
    private Transform itemContainer;
    private Transform player;
    private Transform cameraHolder;
    private PhotonView PV;

    void Awake()
    {
	PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
	player = this.gameObject.transform;
	cameraHolder = player.Find("CameraHolder").transform;
        itemContainer = cameraHolder.Find("itemContainer").transform;
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
	if (!PV.IsMine)
	{
	    return;
	}

        if (Input.GetMouseButton(0) && tongs.activeSelf)
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 5f))
            {
                if (raycastHit.transform != null && (raycastHit.transform.gameObject.tag == "Forgable" || raycastHit.transform.gameObject.tag == "Melt" || raycastHit.transform.gameObject.tag == "Finished"))
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
	if (objectInTongs != null)
	{
	    return;
	}

        objectInTongs = clickedObject;
        objectInTongs.transform.SetParent(tongs.transform);
        objectInTongs.GetComponent<Rigidbody>().useGravity = false;
        Vector3 curpos = objectInTongs.transform.localPosition;
        objectInTongs.transform.localPosition = tongs.transform.GetChild(0).transform.localPosition + new Vector3(0, 0, .1f);

        objectInTongs.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void DropObject()
    {
        if (objectInTongs == null)
        {
            return;
        }

        objectInTongs.GetComponent<Rigidbody>().isKinematic = false;
        objectInTongs.transform.SetParent(null);
        objectInTongs.GetComponent<Rigidbody>().useGravity = true;
        objectInTongs = null;
    }
}
