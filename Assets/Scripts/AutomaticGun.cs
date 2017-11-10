using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using VRTK;

public class AutomaticGun : BallPistol {

	public bool IsFiring { get; private set; }

	public float TimeBetweenShots = .4f;

	private float ShotTimer = 0f;

	public override void OnInteractableObjectUnused(InteractableObjectEventArgs e)
	{
		IsFiring = false;
	}

	public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
	{
		IsFiring = true;
	}

	private void Update()
	{
		ShotTimer -= Time.deltaTime;
		if (ShotTimer < 0 && IsFiring)
		{
			Shoot();
			ShotTimer = TimeBetweenShots;
		}
	}
}
