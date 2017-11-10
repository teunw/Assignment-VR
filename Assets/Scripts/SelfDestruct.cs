using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    public float Timer = 10f;

    private float CurrentTime;

    public void Start()
    {
        CurrentTime = Timer;
    }

    public void ResetTimer()
    {
        CurrentTime = Timer;
    }

	// Update is called once per frame
	public void Update ()
	{
	    CurrentTime -= Time.deltaTime;
	    if (CurrentTime < 0f)
	    {
	        Destroy(gameObject);
	    }
	}
}
