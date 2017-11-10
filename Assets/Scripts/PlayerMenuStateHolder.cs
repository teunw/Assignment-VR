
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerMenuStateHolder : MonoBehaviour
{

	public bool MenuVisible;
	public GameObject PlayerObject;
	public float MenuDistance;
	public float MenuUpOffset;
	public GameObject ObjectToSpawn;
	public float NotUsedTimerThreshold = 5f;

	private float _notUsedForTimer = 0f;
	
	private void Update()
	{
		_notUsedForTimer += Time.deltaTime;
	}

	public void ToggleMenu()
	{
		_notUsedForTimer += Time.deltaTime;
		if (_notUsedForTimer > NotUsedTimerThreshold)
		{
			MenuVisible = true;
			_notUsedForTimer = 0f;
		}
		else
		{
			MenuVisible = !MenuVisible;
		}

		var spawnPosition = PlayerObject.transform.position + (PlayerObject.transform.forward * MenuDistance) + (PlayerObject.transform.up * MenuUpOffset);
		ObjectToSpawn.transform.position = spawnPosition;
		ObjectToSpawn.SetActive(MenuVisible);
		ObjectToSpawn.transform.LookAt(PlayerObject.transform);
	}
}
