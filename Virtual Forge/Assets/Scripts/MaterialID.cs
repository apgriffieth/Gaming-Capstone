using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialID : MonoBehaviour
{
    public int playerIndex;

    private Transform item;
    public Transform player;
    public GameObject[] manager;
    public Vector3 displacement;

    public Text label;
    public Text scaler;
    public int matID;


    void Start()
    {
        Camera[] cameras = FindObjectsOfType<Camera>();

        if (cameras.Length < playerIndex)
        {
            gameObject.SetActive(false);
            //print("yeet");
        }
        else
        {
            GetComponent<Canvas>().worldCamera = cameras[playerIndex - 1];
            player = cameras[playerIndex - 1].transform;

            manager = GameObject.FindGameObjectsWithTag("UI Manager");
            manager[playerIndex - 1].GetComponent<PlayerUIManager>().labels.Add(gameObject);

            item = transform.parent.transform;
            label.text = transform.parent.gameObject.name;

            transform.SetParent(null, true);
            transform.localScale = new Vector3(0.001f, 0.001f, 1);
        }

    }


    void Update()
    {
        transform.position = item.position + displacement;
        transform.rotation = player.rotation;

        float length = Mathf.Round(item.lossyScale.z * 100f) / 100f;
        float thick = Mathf.Round(item.lossyScale.y * 100f) / 100f;

        scaler.text = "Length: " + length + ", Thickness: " + thick;
    }
}
