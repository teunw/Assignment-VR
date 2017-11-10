using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class BallBulletBalloon : MonoBehaviour
{

    public BalloonScoreKeeper BalloonScoreKeeper;
    
    public void OnCollisionEnter(Collision collision)
    {
        var hitBalloon = collision.gameObject.GetComponent<Balloon>();
        if (hitBalloon != null)
        {
            Physics.IgnoreCollision(GetComponent<SphereCollider>(), collision.collider);
            hitBalloon.Pop();
            
            if (BalloonScoreKeeper != null) BalloonScoreKeeper.AddPoint(1);
        }
    }
}
