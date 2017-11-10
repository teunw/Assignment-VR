using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRTK;

[RequireComponent(typeof(AudioSource))]
public class HitscanPistol : VRTK_InteractableObject
{
    public GameObject AimObject;
    public BalloonScoreKeeper BalloonScoreKeeper;
    public GameObject Laser;

    public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUsed(e);
        Shoot();
        GetComponent<AudioSource>().Play();
    }

    public override void OnInteractableObjectGrabbed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectGrabbed(e);
        Laser.SetActive(true);
    }

    public override void OnInteractableObjectUngrabbed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUngrabbed(e);
        Laser.SetActive(false);
    }

    public virtual void Shoot()
    {
        var animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("ShootAnim");
        }
        HitscanTargets();
    }

    public virtual void HitscanTargets()
    {
        var gm = gameObject;
        var raycastAll = Physics.RaycastAll(AimObject.transform.position, AimObject.transform.forward, 200f);
        raycastAll.Where(ho => ho.transform.gameObject.GetComponent<Balloon>() != null)
            .ForEach(ho =>
            {
                ho.transform.gameObject.GetComponent<Balloon>().Pop();
                if (BalloonScoreKeeper != null) BalloonScoreKeeper.AddPoint(1);
            });
        raycastAll.Where(ho => ho.transform.gameObject.GetComponent<CharacterAnimationScript>())
            .ForEach(r => r.transform.gameObject.GetComponent<CharacterAnimationScript>().Scared());
    }
}