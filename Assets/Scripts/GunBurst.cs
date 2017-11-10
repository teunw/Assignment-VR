using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class GunBurst : BallPistol {
	
	public bool IsFiring { get; private set; }
	public float BurstFireRate = 0.03f;
	public int BulletsPerBurst = 3;
	public float FireRate = 0.2f;

	private int BulletsFiredThisBurst;
	private float NextBulletTimer;
	private float NewBurstTimer;
	
	public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
	{
		IsFiring = true;
	}

	public override void OnInteractableObjectUnused(InteractableObjectEventArgs e)
	{
		IsFiring = false;
	}

	public void Update()
	{
		NewBurstTimer -= Time.deltaTime;
		NextBulletTimer -= Time.deltaTime;
		if (!IsFiring) return;
		if (NewBurstTimer > 0f) return;

		if (NextBulletTimer <= 0f && BulletsFiredThisBurst <= BulletsPerBurst)
		{
			Shoot();
			BulletsFiredThisBurst += 1;
			NextBulletTimer = BurstFireRate;
		}
		if (BulletsFiredThisBurst >= BulletsPerBurst)
		{
			NewBurstTimer = FireRate;
			BulletsFiredThisBurst = 0;
			NextBulletTimer = 0f;
		}
	}
}
