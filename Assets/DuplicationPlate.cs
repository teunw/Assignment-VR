using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;

[RequireComponent(typeof(VRTK_BaseHighlighter))]
public class DuplicationPlate : MonoBehaviour
{

	public Transform DuplicateTransform;
	
	private VRTK_BaseHighlighter Highlighter;
	private GameObject ObjectInHighlighter;
	
	
	// Use this for initialization
	void Start ()
	{
		Highlighter = GetComponent<VRTK_BaseHighlighter>();
	}

	public void Duplicate()
	{
		if (ObjectInHighlighter == null) return;
		var newObject = Instantiate(ObjectInHighlighter, ObjectInHighlighter.transform.parent);
		newObject.transform.position = DuplicateTransform.position;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<Dupeable>() == null) return;
		ObjectInHighlighter = other.gameObject;
		Highlighter.Highlight();
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<Dupeable>() == null) return;
		ObjectInHighlighter = null;
		Highlighter.Unhighlight();
	}
}
