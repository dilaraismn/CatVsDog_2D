using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dogPlayerObject, catPlayerObject;
    [SerializeField] private GameObject dogIndicator, catIndicator;
    private DogPlayer _dogPlayer;
    private CatPlayer _catPlayer;
    public bool isPlayerDog { get; set; }

    private void Awake()
    {
        _dogPlayer = dogPlayerObject.GetComponent<DogPlayer>();
        _catPlayer = catPlayerObject.GetComponent<CatPlayer>();
        isPlayerDog = true;
    }

    void Update()
    {
        if (isPlayerDog)
        {
            _dogPlayer.enabled = true;
            _catPlayer.enabled = false;
            dogIndicator.SetActive(true);
            catIndicator.SetActive(false);
        }
        else
        {
            _catPlayer.enabled = true;
            _dogPlayer.enabled = false;
            dogIndicator.SetActive(false);
            catIndicator.SetActive(true);
        }
    }

    public void ChangePlayer()
    {
        isPlayerDog = !isPlayerDog;
    }
}