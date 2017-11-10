using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Timers;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class CharacterAnimationScript : MonoBehaviour
{
    public float WalkingTurn = 0.1f;
    public float WalkingSpeed = 1.5f;
    public float ScareTimer = 10f;
    public Avatar WalkingAvatar;
    public Avatar ScaredAvatar;
    
    private Rigidbody _rigidbody;
    private Animator _animator;
    private float CurrentScareTimer = 0f;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScareTimer -= Time.deltaTime;
        if (CurrentScareTimer < 0f)
        {
            UpdateWalking();
        }
        if (CurrentScareTimer < 0f)
        {
            _animator.avatar = WalkingAvatar;
            _animator.Play("Walking");
        }
    }

    public void UpdateWalking()
    {
        transform.Rotate(0f, WalkingTurn, 0f);
        _rigidbody.velocity = (transform.forward * WalkingSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentScareTimer < 0f)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void Scared()
    {
        _animator.avatar = ScaredAvatar;
        _animator.Play("Scared");
        _rigidbody.velocity = new Vector3();
        transform.Rotate(new Vector3(0f, 0f, 0f));
        CurrentScareTimer = ScareTimer;
    }
}