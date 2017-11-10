using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletFollower : MonoBehaviour
{

	public GameObject BulletToFollow;

	private Rigidbody _rigidbody;

	private void Start()
	{
		this._rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (BulletToFollow == null) return;
		this._rigidbody.MovePosition(BulletToFollow.transform.position);
	}
}
