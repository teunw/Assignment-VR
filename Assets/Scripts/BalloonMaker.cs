using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using VRTK;

[RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
public class BalloonMaker : VRTK_InteractableObject
{
    public Balloon BalloonPrefab;
    public GameObject BalloonParent;
    public float HeightOffset = 0.2f;
    public float BalloonSizeIncrement = 0.02f;
    public float BalloonStartSize = 0.5f;
    public float DestroyThreshold = 1.16f;
    public Color[] PossibleColors = { Color.black };
    public SoundPlayOneshot InflateClip;
    public AudioClip[] StretchAudioClips;

    private float BalloonSize;
    private Balloon CurrentBalloon;
    private AudioSource _audioSource;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnInteractableObjectUsed(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUsed(e);
        StartMakingBalloon();
    }

    public override void OnInteractableObjectUnused(InteractableObjectEventArgs e)
    {
        base.OnInteractableObjectUnused(e);
        StopMakingBalloon();
    }

    public void StartMakingBalloon()
    {
        BalloonSize = BalloonStartSize;
        this.CurrentBalloon = Instantiate(BalloonPrefab, BalloonParent.transform);
        this.CurrentBalloon.transform.position = this.transform.position + (this.transform.up * HeightOffset);

        this.CurrentBalloon.gameObject.GetComponent<Renderer>().material.color = PossibleColors.GetRandomElement();

        var fixedJoint = this.CurrentBalloon.gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = this.GetComponent<Rigidbody>();
        InflateClip.Play();
    }

    public void StopMakingBalloon()
    {
        if (CurrentBalloon == null) return;
        InflateClip.Pause();
        Destroy(this.CurrentBalloon.GetComponent<FixedJoint>());
        CurrentBalloon = null;
        PlayStretchSound();
    }

    public void DestroyBalloon()
    {
        CurrentBalloon.Pop();
        Destroy(CurrentBalloon.gameObject);
        CurrentBalloon = null;
    }

    public void Update()
    {
        if (CurrentBalloon == null) return;
        if (BalloonSize >= DestroyThreshold)
        {
            DestroyBalloon();
            return;
        }
        BalloonSize += BalloonSizeIncrement;
        this.CurrentBalloon.transform.localScale = new Vector3(BalloonSize, BalloonSize, BalloonSize);
    }

    private void PlayStretchSound()
    {
        _audioSource.Stop();
        _audioSource.clip = StretchAudioClips.GetRandomElement();
        _audioSource.loop = false;
        _audioSource.Play();
    }
}
