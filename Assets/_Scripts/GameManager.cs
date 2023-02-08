using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dogPlayerObject, catPlayerObject;
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
        }
        else
        {
            _dogPlayer.enabled = false;
            _catPlayer.enabled = true;
        }
    }

    public void ChangePlayer()
    {
        isPlayerDog = !isPlayerDog;
    }
}