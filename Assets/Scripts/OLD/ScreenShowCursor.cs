using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShowCursor : MonoBehaviour
{

	public bool ShowCursor = true;
	
	// Use this for initialization
	void Start ()
	{
		Cursor.visible = this.ShowCursor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
