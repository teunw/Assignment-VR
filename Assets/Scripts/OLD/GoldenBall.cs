using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;

public class GoldenBall : MonoBehaviour, IGrabbedByController
{
    public HoveringBallPickup Master;

    public bool UseGravityWhenPickedUp = true;
    public bool BeKinematicWhenPickedUp = false;

    public void GrabbedByController(GameObject grabController)
    {
        Master.SpawnNextBall(this.gameObject);

        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = UseGravityWhenPickedUp;
        rigidBody.isKinematic = BeKinematicWhenPickedUp;
    }
}
