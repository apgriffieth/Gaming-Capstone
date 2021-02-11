using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerHitObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    private GameObject collidingObject;
    private GameObject objectInHand;
    private bool canHit = true;
    private float vibrationDuration = 0.25f;
    private float vibrationFrequency = 150f;
    private float vibrationAmplitude = 75f;
    
    public SteamVR_Action_Vibration hapticAction;

    private void SetCollidingObject(Collider col) 
    {
	if (collidingObject || !col.GetComponent<Rigidbody>())
	{
	    return;
	}

	collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
	//SetCollidingObject(other);
	if (collidingObject || !other.GetComponent<Rigidbody>())
	{
	    return;
	}

	collidingObject = other.gameObject;
	if (collidingObject.tag == "Forgable" && canHit) 
	{
	    canHit = false;
	    hapticAction.Execute(0, vibrationDuration, vibrationFrequency, vibrationAmplitude, handType);
	    DescaleObject(collidingObject);
	}
    }

    public void OnTriggerStay(Collider other)
    {
	SetCollidingObject(other);
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

    private void GrabObject()
    {
	objectInHand = collidingObject;
	collidingObject = null;

	var joint = AddFixedJoint();
	joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
	FixedJoint fx = gameObject.AddComponent<FixedJoint>();
	fx.breakForce = 20000;
	fx.breakTorque = 20000;
	return fx;
    }

    private void ReleaseObject() 
    {
	if (GetComponent<FixedJoint>())
	{
	    GetComponent<FixedJoint>().connectedBody = null;
	    Destroy(GetComponent<FixedJoint>());

	    objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
	    objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
	}

	objectInHand = null;
    }

    // Update is called once per frame
    void Update()
    {
	/*
        if (collidingObject) 
	{
	    if (collidingObject.tag == "Forgable")
	    {
		DescaleObject(collidingObject);
	    }
	}
	*/
    }
    
    private void DescaleObject(GameObject collidingObject)
    {
	Vector3 scale = new Vector3(0.005f, -0.01f, 0.05f);

	if (collidingObject.transform.localScale.y > (Math.Abs(scale.y) * 2))
	{
	    collidingObject.transform.localScale += scale;
	    collidingObject.transform.position += new Vector3(0f, scale.y * 0.5f, 0);
	}
    }
}
