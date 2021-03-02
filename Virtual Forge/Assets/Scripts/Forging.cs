using System;
using UnityEngine;
using Valve.VR;

public class Forging : MonoBehaviour
{
    private GameObject collidingObject;
    private bool canHit = true;

    public SteamVR_Input_Sources handType;
    public bool isHeld;
    public SteamVR_Action_Vibration hapticAction;
    private float vibrationDuration = 0.25f;
    private float vibrationFrequency = 150f;
    private float vibrationAmplitude = 75f;

    private void OnTriggerEnter(Collider other)
    {
        if (collidingObject || !other.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = other.gameObject;
        if (collidingObject.tag == "Forgable" && isHeld && canHit)
        {
            canHit = false;
            hapticAction.Execute(0, vibrationDuration, vibrationFrequency, vibrationAmplitude, handType);
            DescaleObject(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        canHit = true;
        collidingObject = null;
    }

    private void DescaleObject(Collider collidingObject)
    {
        float xScaler = 0.005f;
        float zScaler = 0.05f;
        float volume = collidingObject.transform.localScale.x * collidingObject.transform.localScale.y * collidingObject.transform.localScale.z;
        float yScaler = volume / ((collidingObject.transform.localScale.x + xScaler) * (collidingObject.transform.localScale.z * zScaler)) - collidingObject.transform.localScale.y;
        Vector3 scale = new Vector3(xScaler, yScaler, zScaler);

        if (collidingObject.transform.localScale.y > (Math.Abs(scale.y) * 2))
        {
            collidingObject.transform.localScale += scale;
            collidingObject.transform.position += new Vector3(0f, scale.y * 0.5f, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
