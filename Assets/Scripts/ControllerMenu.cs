using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ControllerMenu : VRTK_UIPointer
{

	public PlayerMenuStateHolder PlayerMenuStateHolder;

	public override void OnActivationButtonPressed(ControllerInteractionEventArgs e)
	{
		base.OnActivationButtonPressed(e);
		this.PlayerMenuStateHolder.ToggleMenu();
	}
}
