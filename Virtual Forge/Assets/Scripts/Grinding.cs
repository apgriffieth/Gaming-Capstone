using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Grinding : MonoBehaviour
{
    private GameObject collidingObject;
    private float xScaler = -0.000656197f;
    private float timer = 0f;

    public ParticleSystem sparkEmitter;
    public GameObject spark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (collidingObject != null && collidingObject.tag == "Forgable")
        {
	        timer += Time.deltaTime;
	        if (timer > 2f)
	        {
		        timer = 0f;
		        DescaleObject(collidingObject);
	        }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collidingObject != null)
        {
            return;
        }

        collidingObject = other.gameObject;
        spark.SetActive(true);
        sparkEmitter.enableEmission = true;
        sparkEmitter.Play();
    }

    private void OnTriggerStay(Collider other)
    {
       if (collidingObject == null)
        {
            return;
        }

        collidingObject = other.gameObject;
        spark.SetActive(true);
        sparkEmitter.enableEmission = true;
        sparkEmitter.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (collidingObject == null)
        {
            return;
        }

        collidingObject = null;

        sparkEmitter.enableEmission = false;
    }

    private void DescaleObject(GameObject other)
    {
        if (other.transform.localScale.x > 0.0625f)
        {
            other.transform.localScale += new Vector3(xScaler, 0f, 0f);
        }
    }
}
