using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;
using VRTK;

public class DashTeleportSynchronizer : MonoBehaviour
{
    public VRTK_BasicTeleport[] VrtkBasicTeleport;
    public Slider Slider;

    private void Start()
    {
        if (Slider == null) Slider = GetComponent<Slider>();
        Slider.onValueChanged.AddListener(value =>
        {
            VrtkBasicTeleport.ForEach(bt => bt.blinkTransitionSpeed = value);
            Debug.Log(value);
        });
    }
}