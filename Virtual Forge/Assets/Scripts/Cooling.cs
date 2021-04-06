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
            RigidPrefab = Instantiate(Sword, Spawnpoint.position, Spawnpoint.rotation) as Rigidbody;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Forgable")
        {
            smoke.SetActive(true);
            timer = 5;
            cooled = true;
            other.gameObject.SetActive(false);

        }

    }
}
