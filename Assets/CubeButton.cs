using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CubeButton : VRTK_InteractableObject
{

	public DuplicationPlate DuplicationPlate;
	
	public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
	{
		base.OnInteractableObjectUsed(e);
		DuplicationPlate.Duplicate();
	}
}
