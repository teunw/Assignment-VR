using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class DupeGun : HitscanPistol
{
    public Transform NewObjectTransform;
    public List<GameObject> DupedObjects = new List<GameObject>();

    public override void HitscanTargets()
    {
        var gm = gameObject;
        var r = new Ray(AimObject.transform.position, AimObject.transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(r, out raycastHit, 200f))
        {
            var target = raycastHit.collider.gameObject;
            if (target.transform.GetComponent<Dupeable>() == null)  return;
            var gmTarget = target.transform.gameObject;
            var dupeable = gmTarget.GetComponent<Dupeable>();
            if (dupeable.IsDupeable)
            {
                var newObject = Instantiate(gmTarget, gmTarget.transform.parent, true);
                newObject.transform.position = NewObjectTransform.position;
                DupedObjects.Add(newObject);
            }
        }
    }

    public virtual void RemoveAffectedObjects()
    {
        DupedObjects.ForEach(Destroy);
        DupedObjects.Clear();
    }
}