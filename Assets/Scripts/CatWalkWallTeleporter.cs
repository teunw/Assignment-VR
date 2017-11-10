using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CatWalkWallTeleporter : MonoBehaviour
{
	public Transform TeleportTransform;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<CharacterAnimationScript>() != null)
		{
			other.gameObject.transform.position = this.TeleportTransform.position;
		}
	}
}
