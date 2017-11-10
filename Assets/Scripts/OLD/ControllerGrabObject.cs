using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using VRTK.Highlighters;

public interface IGrabbedByController
{
    void GrabbedByController(GameObject grabController);
}

public interface IControllerEnter
{
    void OnControllerEnter(GameObject controller);
    void OnControllerLeave(GameObject controller);
}
public class ControllerGrabObject : MonoBehaviour
{

    public const string GrabbedByController = "GrabbedByController";
    public const string ControllerEnter = "OnControllerEnter";
    public const string ControllerLeave = "OnControllerLeave";

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // 1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
        other.gameObject.SendMessage(ControllerEnter, gameObject, SendMessageOptions.DontRequireReceiver);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        collidingObject.SendMessage(ControllerLeave, gameObject, SendMessageOptions.DontRequireReceiver);      
        collidingObject = null;
    }

    private void GrabObject()
    {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        // Make object able to react to being grabbed
        objectInHand.SendMessage(ControllerGrabObject.GrabbedByController, gameObject, SendMessageOptions.DontRequireReceiver);
    }

    // 3
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 1
        if (GetComponent<FixedJoint>())
        {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 4
        objectInHand.SendMessage(ControllerLeave, gameObject, SendMessageOptions.DontRequireReceiver);
        objectInHand = null;
    }

    
	// Update is called once per frame
	void Update () {
	    // 1
	    var btnToPress = EVRButtonId.k_EButton_SteamVR_Trigger;
	    if (Controller.GetPressDown(btnToPress) && collidingObject)
	    {
	        GrabObject();
	    }

	    // 2
	    if (Controller.GetPressUp(btnToPress) && objectInHand)
	    {
	        ReleaseObject();
	    }
    }
}
