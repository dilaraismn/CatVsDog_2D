using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject dogPlayerObject, catPlayerObject;
    private DogPlayer _dogPlayer;
    private CatPlayer _catPlayer;
    private bool isPlayerDog { get; set; }
    public bool canChangePlayer { get; set; }//isDog's turn
    void Start()
    {
        _dogPlayer = dogPlayerObject.GetComponent<DogPlayer>();
        _catPlayer = catPlayerObject.GetComponent<CatPlayer>();
        canChangePlayer = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canChangePlayer)
        {
            isPlayerDog = !isPlayerDog;
        }
        
        if (isPlayerDog)
        {
            _dogPlayer.enabled = false;
            _catPlayer.enabled = true;
        }
        else
        {
            _dogPlayer.enabled = true;
            _catPlayer.enabled = false;
        }
    }
}
