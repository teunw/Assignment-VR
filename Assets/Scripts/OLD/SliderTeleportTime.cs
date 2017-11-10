using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class SliderTeleportTime : MonoBehaviour
{

	public Slider Slider;

	private VRTK_BasicTeleport _teleport;

	void Start () {
		_teleport = GetComponent<VRTK_BasicTeleport>();
	}

	private void Update()
	{
		_teleport.blinkTransitionSpeed = Slider.value;
	}
}
