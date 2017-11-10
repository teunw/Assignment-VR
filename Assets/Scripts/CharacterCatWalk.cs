using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterCatWalk : MonoBehaviour
{
	public Collider TeleportCollider;
	public Vector3 TeleportLocation;
	public Rigidbody Rigidbody;
	public float WalkSpeed;

	public void Start()
	{
		this.Rigidbody = GetComponent<Rigidbody>();
	}
	
	public void Update()
	{
		Rigidbody.velocity = new Vector3(-WalkSpeed, 0f, 0f);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other == TeleportCollider)
		{
			this.transform.position = TeleportLocation;
		}
	}
}
