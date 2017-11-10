using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using VRTK;

public class ToggleTooltips : MonoBehaviour
{

	public Toggle Toggle;

	public VRTK_ControllerTooltips[] Tooltips;

	void Awake()
	{
		if (GetComponent<Toggle>())
		{
			Toggle = GetComponent<Toggle>();
		}
	}
	
	// Use this for initialization
	void Start () {
		Toggle.onValueChanged.AddListener(toggleValue =>
		{
			Tooltips.ForEach(tp =>
			{
				tp.gameObject.SetActive(toggleValue);
			});
		});
	}
}
