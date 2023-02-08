using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogPlayer : MonoBehaviour
{
    [SerializeField] private GameObject bonePrefab;
    [SerializeField] private Transform boneParent;
    [SerializeField] private Image forceBar;
    [SerializeField] private GameObject forceBarObject;
    private float throwPower = 1000f;
    private float holdDownStartTime;
    private Animator _animator;
    private Bone _bone;
    private GameManager _gameManager;
    private GameObject currentBone { get; set; }
    private bool canThrow { get; set; }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _gameManager = FindObjectOfType<GameManager>();
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
                _bone.ThrowBone(CalculateForce(holdDownTime));
                forceBarObject.SetActive(false);
                canThrow = false;
                _gameManager.canChangePlayer = false;
            }
        }
        
        if(Bone.canRespawnBone)
        {
            CreateBone();
            _gameManager.canChangePlayer = true;
        }
    }

    private void CreateBone()
    {
        currentBone = Instantiate(bonePrefab, boneParent.transform.position,Quaternion.identity, boneParent.transform);
        _bone = currentBone.GetComponent<Bone>();
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
