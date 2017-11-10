using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallPickup : MonoBehaviour {
	
	public GameObject BallCopy;
	
	private List<GameObject> Spawned = new List<GameObject>();
	private List<GameObject> HasSpawnedNewList = new List<GameObject>();


	private void Start()
	{
		SpawnNext();
	}

	void SpawnNext()
	{
		var instance = Instantiate(BallCopy, this.transform.parent);
		instance.transform.position = transform.position;
		instance.SetActive(true);
		Spawned.Add(instance);
	}
	
	void OnTriggerExit(Collider other)
	{
		if (!Spawned.Contains(other.gameObject))
		{
			return;
		}
		if (HasSpawnedNewList.Contains(other.gameObject))
		{
			return;
		}
		HasSpawnedNewList.Add(other.gameObject);
       	SpawnNext();
    }
}
