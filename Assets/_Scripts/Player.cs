using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float throwPower = 500f;
    private float holdDownStartTime;
    private Bone _bone;

    private void Awake()
    {
        _bone = FindObjectOfType<Bone>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - this.holdDownStartTime;
            _bone.ThrowBone(CalculateForce(holdDownTime));
            // THROW
        }
    }

    private float CalculateForce(float holdTime)
    {
        float maxForceHoldTime = 1f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldTime);
        float throwForce = holdTimeNormalized * throwPower;
        print(throwForce);
        return throwForce;
    }
}
