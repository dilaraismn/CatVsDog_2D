using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatPlayer : MonoBehaviour
{
    [SerializeField] private GameObject fishbonePrefab;
    [SerializeField] private Transform fishboneParent;
    [SerializeField] private Image forceBar;
    [SerializeField] private GameObject forceBarObject;
    private float throwPower = 1000f;
    private float holdDownStartTime;
    private Animator _animator;
    private Fishbone _fishbone;
    private GameObject currentFishbone { get; set; }
    private bool canThrow { get; set; }
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        forceBar =forceBar.GetComponent<Image>();
        forceBar.fillAmount = 0;
        CreateFishbone();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canThrow)
            {
                holdDownStartTime = Time.time;
                forceBarObject.SetActive(true);
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            forceBar.fillAmount += 0.0015f;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (canThrow)
            {
                forceBar.fillAmount = 0;
                float holdDownTime = Time.time - this.holdDownStartTime;
                _animator.Play("Jump");
                _fishbone.ThrowFishbone(CalculateForce(holdDownTime));
                forceBarObject.SetActive(false);
                canThrow = false;
            }
        }
        
        if(Fishbone.canRespawnFishbone)
        {
            CreateFishbone();
        }
    }
    
    private void CreateFishbone()
    {
        currentFishbone = Instantiate(fishbonePrefab, fishboneParent.transform.position,Quaternion.identity, fishboneParent.transform);
        _fishbone = currentFishbone.GetComponent<Fishbone>();
        canThrow = true;
        forceBar.fillAmount = 0;
    }
    
    private float CalculateForce(float holdTime)
    {
        float maxForceHoldTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldTime);
        float throwForce = holdTimeNormalized * throwPower;
        return throwForce;
    }
}
