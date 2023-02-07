using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject bonePrefab;
    [SerializeField] private Transform boneParent;
    [SerializeField] private Image forceBar;
    private float throwPower = 2000f;
    private float holdDownStartTime;
    private Bone _bone;
    private GameObject currentBone { get; set; }

    private void Awake()
    {
    }

    private void Start()
    {
        forceBar =forceBar.GetComponent<Image>();
        forceBar.fillAmount = 0;
        
       CreateBone();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
        }

        if (Input.GetMouseButton(0))
        {
            forceBar.fillAmount +=0.0015f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            forceBar.fillAmount = 0;
            float holdDownTime = Time.time - this.holdDownStartTime;
            // THROW
            _bone.ThrowBone(CalculateForce(holdDownTime));
        }
        
        if(Bone.canRespawn)
        {
            CreateBone();
        }
    }

    private void CreateBone()
    {
        currentBone = Instantiate(bonePrefab, boneParent.transform.position,Quaternion.identity, boneParent.transform);
        _bone = currentBone.GetComponent<Bone>();
    }
    private float CalculateForce(float holdTime)
    {
        float maxForceHoldTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldTime);
        float throwForce = holdTimeNormalized * throwPower;
        return throwForce;
    }
}
