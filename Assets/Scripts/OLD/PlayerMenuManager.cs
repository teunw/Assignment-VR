using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMenuManager : MonoBehaviour
{
    public PlayerMenuStateHolder PlayerMenuState;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int) trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start()
    {
        this.HideMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetPressDown(EVRButtonId.k_EButton_ApplicationMenu))
        {
            PlayerMenuState.MenuVisible = !PlayerMenuState.MenuVisible;
            Debug.Log("Spawning menu");
            if (PlayerMenuState.MenuVisible)
            {
                SpawnMenu();
            }
            else
            {
                HideMenu();
            }
        }
    }

    private void HideMenu()
    {
        PlayerMenuState.ObjectToSpawn.SetActive(false);
    }

    private void SpawnMenu()
    {
        PlayerMenuState.ObjectToSpawn.SetActive(true);

        var t = PlayerMenuState.ObjectToSpawn.transform;
        t.position = PlayerMenuState.PlayerObject.transform.position + (PlayerMenuState.PlayerObject.transform.forward * PlayerMenuState.MenuDistance);
        t.LookAt(PlayerMenuState.PlayerObject.transform);
    }
}