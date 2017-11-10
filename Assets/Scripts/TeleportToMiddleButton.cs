using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK;

public class TeleportToMiddleButton : VRTK_BasicTeleport
{
	public GameObject RootComponent;
	public Button Button;

	private void Start()
	{
		if (Button == null) Button = GetComponent<Button>();
		Button.onClick.AddListener(() =>
		{
			Debug.Log("Tset");
			DoTeleport(this, BuildTeleportArgs(RootComponent.transform, new Vector3(0f, 0f, 0f)));
		});
	}

	protected override Vector3 GetNewPosition(Vector3 tipPosition, Transform target, bool returnOriginalPosition)
	{
		var basePos = base.GetNewPosition(tipPosition, target, returnOriginalPosition);
		basePos.x = 0f;
		basePos.z = 0f;
		return basePos;
	}
}
