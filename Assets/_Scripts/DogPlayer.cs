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
    private float holdDownStartTime;
    private Animator _animator;
    private Bone _bone;
    private GameManager _gameManager;
    private Wind _wind;
    private GameObject currentBone { get; set; }
    private bool canThrow { get; set; }
    private bool mouseDown;
    private float windValue;
    public static float windForceValue;
    public static float catWindForceValue;
    private float holdTimeNormalized;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _gameManager = FindObjectOfType<GameManager>();
        _wind = FindObjectOfType<Wind>();
    }

    private void Start()
    {
        forceBar =forceBar.GetComponent<Image>();
        forceBar.fillAmount = 0;

        if (_gameManager.isPlayerDog)
        {
            CreateBone();
        }
    }

    private void Update()
    {
        if (_gameManager.isGameOver || !GameManager.isGameStarted) return;

        if (Input.GetMouseButtonDown(0) && canThrow && _gameManager.isPlayerDog)
        {
            holdDownStartTime = Time.time;
            forceBarObject.SetActive(true);
            mouseDown = true;
        }

        if (Input.GetMouseButton(0))
        {
            if (mouseDown)
            {
                forceBar.fillAmount += 0.002f;
            }
        }
        
        if (Input.GetMouseButtonUp(0) && canThrow && _gameManager.isPlayerDog && mouseDown)
        {
            forceBar.fillAmount = 0;
            _animator.Play("Jump");

            float holdDownTime = Time.time - this.holdDownStartTime;
            float calculatedForce = CalculateForce(holdDownTime);
            float fixedHight = Mathf.Clamp(calculatedForce, .5f, 7.5f);               
            float fixedPosX = Mathf.Clamp(calculatedForce, 3, 10);
            //bone.ThrowBone(fixedForce , (fixedForce - windForceValue));
            _bone.ThrowBone(fixedHight, (fixedPosX * 2));
          
            forceBarObject.SetActive(false);
            canThrow = false;
            mouseDown = false;
        }
        
        if(Bone.canRespawnBone && _gameManager.isPlayerDog)
        {
            CreateBone();
        }
    }

    private float GetWindForce()
    {
        if (_wind.IsWindRight())
        {
            windValue = _wind.SetWindForce(windValue);
            catWindForceValue = -_wind.SetWindForce(windValue);
        }
        else
        {
            windValue = -_wind.SetWindForce(windValue);
            catWindForceValue = _wind.SetWindForce(windValue);
        }
        return windValue;
    }
    
    private void CreateBone()
    {
        windForceValue = GetWindForce();
        currentBone = Instantiate(bonePrefab, boneParent.transform.position,Quaternion.identity, boneParent.transform);
        _bone = currentBone.GetComponent<Bone>();
        canThrow = true;
        forceBar.fillAmount = 0;
    }
    private float CalculateForce(float holdTime)
    {
        float maxForceHoldTime = 2f;
        holdTimeNormalized = Mathf.Clamp(holdTime, 0.1f, maxForceHoldTime);
        //float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldTime);
        float throwForce = holdTimeNormalized * 10;
        return throwForce;
    }
}
