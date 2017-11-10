using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardwiredToSelfDestruct : MonoBehaviour, IGrabbedByController
{
    public const float HardwiredDefaultTimer = 10f;

    [Tooltip("Should this object be reset when picked up?")]
    public bool ResetOnPickup = true;

    public float TimerAtStart
    {
        get;
        private set;
    }

    public bool IsDestructible = true;
        
    public float Timer = HardwiredDefaultTimer;

    public void ResetTimer(float? to = null)
    {
        Timer = to ?? TimerAtStart;
    }

    void Start()
    {
        TimerAtStart = Timer;
    }

	// Update is called once per frame
	void Update ()
	{
	    if (!IsDestructible) return;

	    Timer -= Time.deltaTime;
	    if (Timer <= 0f)
	    {
            Destroy(this.gameObject);
	    }
	}

    public void GrabbedByController(GameObject grabController)
    {
        ResetTimer();
    }
}
