using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CubeSpawnButton : MonoBehaviour
{
    public ObjectSpawner ObjectSpawner;

    private Button button;

	// Use this for initialization
	void Start ()
	{
	    button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
		button.onClick.AddListener(() =>
		{
		    this.ObjectSpawner.Spawn();
		});
	}
}
