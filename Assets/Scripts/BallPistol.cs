using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(AudioSource), typeof(Animator))]
public class BallPistol : VRTK_InteractableObject
{
    public GameObject Projectile;
    public GameObject BulletParent;
    public GameObject Trail;
    public GameObject AimObject;
    public float StartSpeed = 10f;
    public float StartPositionOffset;
    public float StartPositionUpOffset;

    [HideInInspector]
    public Vector3 StartPosition;

    private Animator _animator;
    
    void Start()
    {
        StartPosition = GetStartPosition();
        _animator = GetComponent<Animator>();
    }

    public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUsed(e);
        Shoot();
    }

    public void Shoot()
    {
        GetComponent<AudioSource>().Play();

        var newProjectile = Instantiate(Projectile, GetStartPosition(), this.transform.rotation);
        newProjectile.SetActive(true);
        newProjectile.GetComponent<Rigidbody>().velocity = AimObject.transform.forward * StartSpeed;
        newProjectile.transform.parent = BulletParent.transform;

        var selfDestruct = newProjectile.AddComponent<SelfDestruct>();
        selfDestruct.Timer = 10f;

        var trail = Instantiate(Trail, this.BulletParent.transform);
        trail.transform.position = newProjectile.transform.position;
        trail.GetComponent<Rigidbody>().velocity = (AimObject.transform.forward * 2f);
        trail.GetComponent<BulletFollower>().BulletToFollow = newProjectile;
        trail.SetActive(true);
        
        _animator.Play("ShootAnim");
    }

    public Vector3 GetStartPosition()
    {
        return AimObject.transform.position
               + (AimObject.transform.forward * StartPositionOffset)
               + (AimObject.transform.up * StartPositionUpOffset);
    }

    void OnDrawGizmos()
    {
        StartPosition = GetStartPosition();

        Gizmos.DrawWireSphere(StartPosition, Projectile.transform.localScale.x);
        Gizmos.DrawLine(StartPosition, AimObject.transform.forward * StartSpeed + AimObject.transform.position);
    }
}
