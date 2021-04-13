using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooling : MonoBehaviour
{
    public Transform Spawnpoint;
    public Rigidbody Sword;
    public GameObject smoke;
    private bool cooled = false;
    private float timer = 0;
    private Rigidbody RigidPrefab;
    public ParticleSystem smokeEmitter;

    private Vector3 swordScale;

    // Start is called before the first frame update
    void Start()
    {
	
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && cooled == true)
        {
            cooled = false;
            RigidPrefab = Instantiate(Sword, Spawnpoint.position, Spawnpoint.rotation);
            RigidPrefab.gameObject.name = "Finished Copper Sword";
            RigidPrefab.transform.localScale = swordScale;
	        smokeEmitter.enableEmission = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Forgable"))
        {
            smoke.SetActive(true);
            smokeEmitter.enableEmission = true;
	        smokeEmitter.Play();
            timer = 5;
            cooled = true;

            swordScale = other.transform.lossyScale;
            other.gameObject.SetActive(false);
        }

    }
}
